using System;
using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdResult(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await session.LoadAsync<EProduct>(request.Id);

        if (data == null) throw new ProductNotFoundException(request.Id);

        var result = data.Adapt<GetProductByIdResult>();
        return result;
    }
}
