
using Basket.Api.Data;

namespace Basket.Api.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string username);
public class StoreBasketCommandHandler : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandHandler()
    {
        RuleFor(x => x.cart).NotNull().WithMessage("Cart cannot be null");
        RuleFor(x => x.cart.UserName).NotEmpty().WithMessage("Username is required");
    }
}
public class StoreBasketHandler(IBasketRepository basketRepository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        ShoppingCart cart = request.cart;
        await basketRepository.StoreBasket(cart);
        //Todo: update cache

        return new StoreBasketResult(request.cart.UserName);
    }
}
