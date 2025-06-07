using System;

namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/product/{id:guid}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(id: id));
            return Results.Ok(result);
        })
        .WithName("DeleteProduct")
        .WithDescription("Delete Product")
        .WithSummary("Delte product")
        .Produces<string>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
