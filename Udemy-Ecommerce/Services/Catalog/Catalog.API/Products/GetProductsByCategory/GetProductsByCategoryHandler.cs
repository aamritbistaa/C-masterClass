
using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryResult(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record GetProductsByCategoryQuery(string category) : IQuery<IEnumerable<GetProductsByCategoryResult>>;
public class GetProductsByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsByCategoryQuery, IEnumerable<GetProductsByCategoryResult>>
{
    public async Task<IEnumerable<GetProductsByCategoryResult>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var data = await session.Query<EProduct>().Where(x => x.Category.Contains(request.category)).ProjectToType<GetProductsByCategoryResult>().ToListAsync();
        return data;
    }
}
