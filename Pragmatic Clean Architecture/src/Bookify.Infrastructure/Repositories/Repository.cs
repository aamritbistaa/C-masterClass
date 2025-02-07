using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repositories
{
    public abstract class Repository<T> where T:Entity
    {
        protected readonly ApplicationDbContext _context;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        protected async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id ==id);
        }
        protected async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
    }
}
