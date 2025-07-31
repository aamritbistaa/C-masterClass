using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Events;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderUpdatedDomainEventHandler : INotificationHandler<OrderUpdatedEvent>
{
    private readonly ILogger<OrderUpdatedDomainEventHandler> _logger;

    public OrderUpdatedDomainEventHandler(ILogger<OrderUpdatedDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain event handleded: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
