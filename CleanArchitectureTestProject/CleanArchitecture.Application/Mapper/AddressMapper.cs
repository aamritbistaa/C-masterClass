using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    public class AddressMapper
    {
        public static Address CreateAddressRequestToAddressMapper(CreateAddressRequest request)
        {
            return new Address
            {
                City = request.City,
                Country = request.Country,
                StreetAddress = request.StreetAddress,
            };
        }
    }
}
