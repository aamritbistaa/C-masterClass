using CQRSApplication.Context;
using CQRSApplication.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CQRSApplication.Command.AuthUserCommand
{
    public class ChangeToVendorCommandHandler : IRequestHandler<ChangeToVendorCommand, User>
    {
        private readonly CQRSDbContext _dbContext;
        private readonly IMediator _mediator;

        public ChangeToVendorCommandHandler(CQRSDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<User> Handle(ChangeToVendorCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(u => u.userCredentials)
                .Include(u => u.shippingAddress)
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user == null)
            {
                Log.Error("Unable to find User {@Id}", request.Id);
                throw new Exception("User with specified Id does not exist");
            }

            if (user.userCredentials.Role == RoleType.Customer)
            {
                user.userCredentials.Role = RoleType.Vendor;

                // Check if shippingAddress is null before accessing its properties
                if (user.shippingAddress != null)
                {
                    var address = $"{user.shippingAddress.StreetAddress}, {user.shippingAddress.City}, {user.shippingAddress.District}";
                    if (user.CartId != null)
                    {
                        var itemToDelete = await _dbContext.Carts.FirstOrDefaultAsync(c => c.Id == user.CartId, cancellationToken);
                        if (itemToDelete != null)
                        {
                            _dbContext.Carts.Remove(itemToDelete);
                            user.ShippingAddressId = null;
                            await _dbContext.SaveChangesAsync(cancellationToken);
                        }
                    }
                    Vendor vendor = new Vendor
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        ShopName = "Default Shop",
                        ShopAddress = address,
                        PanNo = "Default Pan Number",
                    };
                    _dbContext.Vendors.Add(vendor);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    Log.Information("User {@Id} updated", request.Id);
                }
                else
                {
                    throw new Exception("User's shipping address is not specified");
                }
            }
            else if (user.userCredentials.Role == RoleType.Vendor)
            {
                Log.Information("User {@Id} is already a vendor", request.Id);
                throw new Exception("Unable to assign 'Vendor' role to a vendor");
            }
            else
            {
                Log.Information("User {@Id} is not a vendor or customer", request.Id);
                throw new Exception("You don't have permission to do that");
            }
            return user;
        }
    }
}
