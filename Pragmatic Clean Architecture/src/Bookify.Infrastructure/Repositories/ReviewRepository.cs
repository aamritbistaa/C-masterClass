using System;
using Bookify.Domain.Review;

namespace Bookify.Infrastructure.Repositories;

public class ReviewRepository : Repository<Review>
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }
    public async Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await base.GetByIdAsync(id);
    }
    public async Task Add(Review review)
    {
        await base.Add(review);
    }
}
