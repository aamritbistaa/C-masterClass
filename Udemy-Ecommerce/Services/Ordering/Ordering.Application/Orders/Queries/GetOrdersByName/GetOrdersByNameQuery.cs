using System;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public record GetOrderByNameQuery(string name) : IQuery<GetOrdersByNameResult>;

public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);