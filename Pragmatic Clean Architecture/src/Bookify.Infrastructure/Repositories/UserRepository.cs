using Bookify.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task Add(User user)
        {
           await base.Add(user);
        }
    }
}
