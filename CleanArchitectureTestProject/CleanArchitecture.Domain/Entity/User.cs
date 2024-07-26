using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entity
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender{ get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }

    }
}
