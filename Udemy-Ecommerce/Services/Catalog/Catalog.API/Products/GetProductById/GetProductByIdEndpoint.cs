using System;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdResponse(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/{id:guid}", async (Guid id, ISender sender) =>
        {
            var query = await sender.Send(new GetProductByIdQuery(Id: id));
            return Results.Ok(query.Adapt<GetProductByIdResponse>());
        })
        .WithName("GetProductById")
        .WithDescription("Get Product By Id")
        .WithSummary("Get product by id")
        .Produces<GetProductByIdQuery>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
