using System;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryResponse(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category", async (string category, ISender sender) =>
        {
            var query = await sender.Send(new GetProductsByCategoryQuery(category));

            var result = query.Adapt<IEnumerable<GetProductsByCategoryResponse>>();
            return Results.Ok(result);
        })
        .WithName("GetProductsByCategory")
        .WithDescription("Get Products By Category")
        .WithSummary("Get products by category")
        .Produces<IEnumerable<GetProductsByCategoryResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
