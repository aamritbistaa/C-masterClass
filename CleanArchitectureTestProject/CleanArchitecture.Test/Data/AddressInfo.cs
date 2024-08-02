using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Data
{
    public class AddressInfo
    {
        public static List<AddressResponse> AddressResponseList { get; set; }
        public static List<Address> AddressList { get; set; }

        public static CreateAddressRequest CreateAddressRequest { get; set; }
        public static AddressResponse CreateAddressResponse { get; set; }
        public static UpdateAddressRequest UpdateAddressRequest { get; set; }
        public static void Initialize()
        {
            AddressResponseList =
            new List<AddressResponse> {
                new AddressResponse {
                    City = "Kathmandu",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                },
                new AddressResponse {
                    City = "Baneshwor",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                }
            };

            AddressList = new List<Address> {
                new Address {
                    City = "Kathmandu",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                },
                new Address {
                    City = "Baneshwor",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                }
            };

            CreateAddressRequest = new CreateAddressRequest
            {
                StreetAddress = "Kamal Binayak",
                City = "Bhaktapur",
                Country = "Nepal",
            };

            CreateAddressResponse = new AddressResponse
            {
                Id = 10,
                City = CreateAddressRequest.City,
                Country = CreateAddressRequest.Country,
                StreetAddress = CreateAddressRequest.StreetAddress,
                IsDeleted = false,
            };

            UpdateAddressRequest = new UpdateAddressRequest
            {
                Id = 1,
                StreetAddress = "Kamal Binayak",
                City = "Bhaktapur",
                Country = "Nepal",
            };

        }
        
    }
}
