using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Service.Implementation
{
    public class AddressService:IAddressService
    {
        private readonly IEmployeeRepository<Address> _addressRepository;

        public AddressService(IEmployeeRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<Address>> GetAllAddress()
        {
            var result = await _addressRepository.ListAsync();
            return result;
        }
        public async Task<Address> GetAddressById(int id)
        {
            var result = await _addressRepository.FindAsync(id);
            return result;
        }
        public async Task<Address> AddAddress(Address request)
        {
            var result = await _addressRepository.AddAsync(request);
            return result;
        }
        public async Task<bool> UpdateAddress(Address request)
        {
            var result = await _addressRepository.UpdateAsync(request);
            return result;
        }
    }
}
