using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        
        public bool IsDeleted { get; set; } = false;
    }
}
