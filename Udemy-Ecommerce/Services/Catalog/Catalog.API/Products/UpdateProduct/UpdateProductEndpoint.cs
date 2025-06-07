using System;
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductResponse(Guid id);
public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/product/{id:guid}", async (Guid id, CreateProductCommand product, ISender sender) =>
        {
            var command = await sender.Send(new UpdateProductCommand(id, product.Name, product.Category, product.Description, product.ImageFile, product.Price));
            return Results.Ok(command.Adapt<UpdateProductResponse>());
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResult>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}
