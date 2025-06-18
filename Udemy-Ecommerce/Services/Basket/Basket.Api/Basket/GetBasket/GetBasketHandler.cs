using System;

namespace Basket.Api.Basket.GetBasket;

public record GetBasketQuery(string userName) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart cart);
public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        //Todo: get basket from database


        return new GetBasketResult(new ShoppingCart(""));
    }
}
