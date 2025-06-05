using System;

namespace Catalog.API.Products.GetAllProduct;

public record GetProductResponse(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = await sender.Send(new GetProduct());
            var result = query.Adapt<IEnumerable<GetProductResponse>>();
            return Results.Created($"/products", result);
        })
        .WithName("GetProduct")
        .Produces<IEnumerable<GetProductResponse>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product")
        .WithDescription("Get Product");
    }
}
