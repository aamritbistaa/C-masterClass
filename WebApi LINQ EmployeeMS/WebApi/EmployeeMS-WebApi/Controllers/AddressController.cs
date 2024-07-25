using EmployeeMS.AppDbContext;
using EmployeeMS.Dto.Request;
using EmployeeMS.Dto.Response;
using EmployeeMS.Mapper;
using EmployeeMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmployeeMS.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllAddress")]
        public async Task<List<AddressResponse>?> GetAllAddress()
        {
            var datas = await _context.Addresses.ToListAsync();
            if(datas == null)
            {
                return null;
            }
            var response = (from item in datas
                           select Mappers.AddressToAddressResponseMapper(item)).ToList();
            
            return response;
        }
        [HttpGet("GetAddressById")]
        public async Task<AddressResponse?> GetAddressById(int id)
        {
            var addressItem = await _context.Addresses.FindAsync(id);

            if (addressItem == null)
            {
                return null;
            }
            var response = Mappers.AddressToAddressResponseMapper(addressItem);
            return response;
        }
        [HttpPost]
        public async Task<AddressResponse?> CreateAddress(CreateAddressRequest request)
        {
            var address = new Address
            {
                City = request.City,
                Country = request.Country,
            };
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            var response = Mappers.AddressToAddressResponseMapper(address);

            return response;
        }

        [HttpPut]
        public async Task<AddressResponse?> UpdateAddress(UpdateAddressRequest request)
        {
            var addressItem = _context.Addresses.Find(request.Id);
            if (addressItem == null)
            {
                return null;
            }
            addressItem.City = request.City;
            addressItem.Country = request.Country;

            _context.Addresses.Update(addressItem);
            await _context.SaveChangesAsync();

            var response = Mappers.AddressToAddressResponseMapper(addressItem);
            return response;
        }

        [HttpDelete("DeleteAddressById")]
        public async Task<AddressResponse?> DeleteAddressById(int id)
        {
            var addressItem = await _context.Addresses.FindAsync(id);
            if (addressItem == null)
            {
                return null;
            }
            addressItem.IsDeleted = true;
            _context.Addresses.Update(addressItem);
            await _context.SaveChangesAsync();
            var response = Mappers.AddressToAddressResponseMapper(addressItem);
            return response;
        }
    }
}
