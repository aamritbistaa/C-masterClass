using System;
using BuildingBlocks.Pagination;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest) : IQuery<GetOrderResult>;

public record GetOrderResult(PaginatedResult<OrderDto> Orders);
