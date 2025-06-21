using System;
using Basket.Api.Data;

namespace Basket.Api.Basket.GetBasket;

public record GetBasketQuery(string userName) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart cart);
public class GetBasketHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var data = await basketRepository.GetBasket(request.userName);

        return new GetBasketResult(data);
    }
}
