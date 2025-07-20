using System;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Dtos;
using Ordering.Application.Extensions;
using Ordering.Domain.Models;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrderByNameQueryHandler : IQueryHandler<GetOrderByNameQuery, GetOrdersByNameResult>
{
    private readonly IApplicationDbContext _dbContext;

    public GetOrderByNameQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetOrdersByNameResult> Handle(GetOrderByNameQuery request, CancellationToken cancellationToken)
    {
        var data = await _dbContext.Orders
                            .Include(x => x.OrderItems)
                            .AsNoTracking()
                            .Where(x => x.OrderName.Value.Contains(request.name))
                            .OrderBy(x => x.OrderName)
                            .ToListAsync();

        var orderDtos = data.ToOrderDtoList();
        return new GetOrdersByNameResult(orderDtos);
    }
}
