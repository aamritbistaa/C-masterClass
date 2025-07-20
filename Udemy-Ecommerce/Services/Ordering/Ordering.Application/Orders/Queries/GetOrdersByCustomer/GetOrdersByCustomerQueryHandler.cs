using System;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
{
    public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
    {
        var data = await dbContext.Orders
                                .Include(x => x.OrderItems)
                                .AsNoTracking()
                                .Where(x => x.CustomerId == CustomerId.Of(request.CustomerId))
                                .OrderBy(x => x.OrderName.Value)
                                .ToListAsync();
        return new GetOrdersByCustomerResult(data.ToOrderDtoList());
    }
}
