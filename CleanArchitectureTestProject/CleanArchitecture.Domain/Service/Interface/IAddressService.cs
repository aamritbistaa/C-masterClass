using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Service.Interface
{
    public interface IAddressService
    {
        Task<List<Address>> GetAllAddress();
        Task<Address> GetAddressById(int id);
        Task<Address> AddAddress(Address request);
        Task<bool> UpdateAddress(Address request);
    }
}
