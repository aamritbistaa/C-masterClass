using System;
using Mapster;

namespace Basket.Api.Basket.StoreBasket;

public record StoreBasketRequest(ShoppingCart cart);
public record StoreBasketResponse(string username);

public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
        {
            var command = new StoreBasketCommand(request.cart);
            var result = await sender.Send(command);
            var response = result.Adapt<StoreBasketResponse>();
            return Results.Created($"/basket/{response.username}", response);
        }).WithDescription("This api is used to store into shoppingcart")
        .WithName("CreateProduct")
        .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product");
    }
}
