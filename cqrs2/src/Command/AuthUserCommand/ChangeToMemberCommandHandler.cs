using CQRSApplication.Context;
using CQRSApplication.Model;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Serilog;

namespace CQRSApplication.Command.AuthUserCommand
{
    public class ChangeToMemberCommandHandler : IRequestHandler<ChangeToMemberCommand, User>
    {
        private readonly CQRSDbContext _dbContext;
        private readonly IMediator _mediator;

        public ChangeToMemberCommandHandler(CQRSDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<User> Handle(ChangeToMemberCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                        .Include(u => u.userCredentials)
                        .FirstOrDefaultAsync(c => request.Id == c.Id, cancellationToken);

            if (user == null)
            {
                Log.Error("Unable to find User {@Id}", request.Id);
                throw new Exception("User with specified Id does not exist");
            }

            if (user.userCredentials.Role == RoleType.Vendor)
            {
                user.userCredentials.Role = RoleType.Customer;
                var vendor = await _dbContext.Vendors
                            .FirstOrDefaultAsync(v => v.UserId == user.Id, cancellationToken);
                if (vendor != null)
                {
                    _dbContext.Vendors.Remove(vendor);
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                Log.Information("User {@Id} updated", request.Id);
            }
            else if (user.userCredentials.Role == RoleType.Customer)
            {
                Log.Information("User {@Id} is already a Customer", request.Id);
                throw new Exception("Unable to assign 'Customer' to a customer");
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
