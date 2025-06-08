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
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Prie must be greater than 0");
    }
}
public record CreateProductResult(Guid Id);

public class CreateProductCommandHandler(IDocumentSession session, IValidator<CreateProductCommand> validator) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(command);
        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        if (errors.Any())
        {
            throw new ValidationException(string.Join(", ", errors));
        }
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
