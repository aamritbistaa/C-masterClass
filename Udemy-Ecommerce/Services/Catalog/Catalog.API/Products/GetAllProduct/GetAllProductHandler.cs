using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using Marten.Pagination;

namespace Catalog.API.Products.GetAllProduct;

public record GetAllProductResult(
    Guid Id,
    string Name,
    IReadOnlyList<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);

public record GetAllProductQuery(int? pageNumber = 1, int? pageSize = 50)
    : IQuery<IEnumerable<GetAllProductResult>>;

public class GetAllProductQueryHandler(IDocumentSession session)
    : IQueryHandler<GetAllProductQuery, IEnumerable<GetAllProductResult>>
{
    public async Task<IEnumerable<GetAllProductResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var pageNumber = request.pageNumber is > 0 ? request.pageNumber.Value : 1;
        var pageSize = request.pageSize is > 0 ? request.pageSize.Value : 10;

        var allData = await session.Query<EProduct>()
            .ProjectToType<GetAllProductResult>()
            .ToPagedListAsync(pageNumber, pageSize, cancellationToken);


        return allData;
    }
}
