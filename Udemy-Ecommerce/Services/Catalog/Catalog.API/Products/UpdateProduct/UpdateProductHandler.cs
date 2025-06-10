using System;
using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductResult(Guid id);
public record UpdateProductCommand(Guid id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                            .Length(2, 150).WithMessage("Name must be between 2 and 150 chahracters");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IDocumentSession _session;

    public UpdateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var data = await _session.LoadAsync<EProduct>(request.id);
        if (data == null) throw new ProductNotFoundException();
        data.Name = request.Name;
        data.Category = request.Category;
        data.Description = request.Description;
        data.ImageFile = request.ImageFile;
        data.Price = request.Price;
        _session.Store<EProduct>(data);
        await _session.SaveChangesAsync();
        return new UpdateProductResult(data.Id);
    }
}
