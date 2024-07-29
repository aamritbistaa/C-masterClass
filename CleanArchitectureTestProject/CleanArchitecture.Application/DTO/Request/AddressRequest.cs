using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Request
{
    public class CreateAddressRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
    }
    public class UpdateAddressRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
    }
}
