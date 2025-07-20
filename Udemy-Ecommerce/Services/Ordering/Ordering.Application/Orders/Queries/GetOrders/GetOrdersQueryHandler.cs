using System;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrderResult>
{
    public async Task<GetOrderResult> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var pageIndex = request.PaginationRequest.PageIndex;
        var pageSize = request.PaginationRequest.PageSize;

        var totalCount = await dbContext.Orders.LongCountAsync();

        var orders = await dbContext.Orders
                                .Include(x => x.OrderItems)
                                .OrderBy(x => x.OrderName.Value)
                                .Skip(pageSize * pageIndex)
                                .Take(pageSize)
                                .ToListAsync();

        return new GetOrderResult(
            new BuildingBlocks.Pagination.PaginatedResult<Dtos.OrderDto>(
                pageIndex,
                pageSize,
                totalCount,
                orders.ToOrderDtoList()
            )
        );
    }
}
