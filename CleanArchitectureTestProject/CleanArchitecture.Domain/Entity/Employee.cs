using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entity
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
    }
}
