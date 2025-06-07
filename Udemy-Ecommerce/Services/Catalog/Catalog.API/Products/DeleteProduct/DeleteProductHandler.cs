using System;
using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid id) : ICommand<string>;
public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, string>
{
    private readonly IDocumentSession _session;

    public DeleteProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        _session.Delete<EProduct>(id: request.id);
        await _session.SaveChangesAsync();
        return "Deleted successfully";
    }
}
