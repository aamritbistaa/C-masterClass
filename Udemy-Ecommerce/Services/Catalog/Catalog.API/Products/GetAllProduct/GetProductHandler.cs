using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.GetAllProduct;

public record GetProductResult(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
public record GetProduct() : IQuery<IEnumerable<GetProductResult>>;
public class GetProductHandler(IDocumentSession session) : IQueryHandler<GetProduct, IEnumerable<GetProductResult>>
{
    public async Task<IEnumerable<GetProductResult>> Handle(GetProduct request, CancellationToken cancellationToken)
    {
        var allData = await session.Query<EProduct>().ProjectToType<GetProductResult>().ToListAsync();
        return allData;
    }
}
