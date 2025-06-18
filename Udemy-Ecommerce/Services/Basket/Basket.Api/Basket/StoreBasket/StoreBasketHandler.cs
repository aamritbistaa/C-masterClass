
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
public class StoreBasketHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        ShoppingCart cart = request.cart;
        //Todo: sore basket in database(use marten upset - if exist => update, if not add)
        //Todo: update cache

        return new StoreBasketResult("");
    }
}
