using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Dto.Response
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
    }
}
