using System;
using Mapster;

namespace Basket.Api.Basket.GetBasket;

public record GetBasketResponse(ShoppingCart cart);

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{username}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            return result.Adapt<GetBasketResponse>();
        })
        .WithName("GetBasketByUsername")
        .WithDescription("Get Basket By Username")
        .WithSummary("Get basket by username")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
