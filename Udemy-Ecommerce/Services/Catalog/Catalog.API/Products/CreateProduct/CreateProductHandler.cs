using BuildingBlocks.CQRS;
using Catalog.API.Models;
using FastExpressionCompiler;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
public record CreateProductResult(Guid Id);

public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {        //map command object to product entity (EProduct)
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
