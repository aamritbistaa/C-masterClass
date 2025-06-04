using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //map command object to product entity (EProduct)
        var product = new EProduct
        {
            Name = command.Name,
            Category = command.Category,
            ImageFile = command.ImageFile,
            Description = command.Description,
            Price = command.Price
        };

        //save to database
        session.Store(product);

        await session.SaveChangesAsync();
        //return result
        return new CreateProductResult(product.Id);
    }
}
