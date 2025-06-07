using System;

namespace Catalog.API.Products.GetAllProduct;

public record GetAllProductResponse(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
public class GetAllProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = await sender.Send(new GetAllProductQuery());
            var result = query.Adapt<IEnumerable<GetAllProductResponse>>();
            return Results.Ok(result);
        })
        .WithName("GetProduct")
        .Produces<IEnumerable<GetAllProductResponse>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product")
        .WithDescription("Get Product");
    }
}
