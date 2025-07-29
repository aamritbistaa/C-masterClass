using System;
using Basket.Api.Data;
using Basket.Api.Dtos;
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.Api.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);
public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto is required");
    }
}
public class CheckoutBasketCommandHandler(IBasketRepository repository, IPublishEndpoint publishEndpoint) : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
    {
        //get existing basket with total price
        var basket = await repository.GetBasket(request.BasketCheckoutDto.UserName);
        if (basket == null)
        {
            return new CheckoutBasketResult(false);
        }

        //set total price on basket checkout event message
        var eventMessage = request.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        // send basket checkout event to rabbitmq using masstransit
        await publishEndpoint.Publish(eventMessage);

        //delete the basket
        await repository.DeleteBasket(request.BasketCheckoutDto.UserName);

        return new CheckoutBasketResult(true);
    }
}
