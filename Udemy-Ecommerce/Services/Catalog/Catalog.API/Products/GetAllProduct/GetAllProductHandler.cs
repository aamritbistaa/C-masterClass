using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.GetAllProduct;

public record GetAllProductResult(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
public record GetAllProductQuery() : IQuery<IEnumerable<GetAllProductResult>>;
public class GetAllProductQueryHandler(IDocumentSession session) : IQueryHandler<GetAllProductQuery, IEnumerable<GetAllProductResult>>
{
    public async Task<IEnumerable<GetAllProductResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var allData = await session.Query<EProduct>().ProjectToType<GetAllProductResult>().ToListAsync();
        return allData;
    }
}
