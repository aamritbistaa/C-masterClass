using System;
using BuildingBlocks.Messaging.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Commands.CreateOrder;
using Ordering.Domain.Models;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType());
        //Create new order and start order fullfillment process
        var command = MapToCommandOrderCommand(context.Message);

        await sender.Send(command);
    }
    private CreateOrderCommand MapToCommandOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto(
                    message.FirstName,
                    message.LastName,
                    message.EmailAddress,
                    message.AddressLine,
                    message.Country,
                    message.State,
                    message.ZipCode
                );
        var paymentDto = new PaymentDto(
                    message.CardName,
                    message.CardNumber,
                    message.Expiration,
                    message.CVV,
                    message.PaymentMethod
                );
        var orderId = Guid.NewGuid();
        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Status: Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems: [
                new OrderItemDto(orderId, new Guid("aad4eee1-26e6-425b-82b1-1d3de7895807"), 2, 1000)
            ]
        );
        return new CreateOrderCommand(orderDto);
    }
}
