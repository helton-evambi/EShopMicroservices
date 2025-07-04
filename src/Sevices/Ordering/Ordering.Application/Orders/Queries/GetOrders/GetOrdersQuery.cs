﻿using BuidingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest) 
    : IQuery<GetOrderResult>;

public record GetOrderResult(PaginatedResult<OrderDto> Orders);