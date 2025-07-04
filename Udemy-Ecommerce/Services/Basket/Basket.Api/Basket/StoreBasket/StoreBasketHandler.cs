
using Basket.Api.Data;
using Discount.Grpc;

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
public class StoreBasketComHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discountProtoService) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        //Todo: communicate with discount gRPC and calculate latest price of product
        foreach (var item in request.cart.Items)
        {
            var coupon = await discountProtoService.GetDiscountAsync(new GetDiscountRequest
            {
                ProductName = item.ProductName
            });
            item.Price = item.Price - coupon.Amount;
        }

        ShoppingCart cart = request.cart;
        await basketRepository.StoreBasket(cart);
        //Todo: update cache

        return new StoreBasketResult(request.cart.UserName);
    }
}
