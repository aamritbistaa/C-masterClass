using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entity
{
    public class Department:BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
