using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Interface
{
    public interface IAddressManager
    {
        Task<ServiceResult<List<Address>>> GetAllAddress();
        Task<ServiceResult<Address>> GetAddressById(int id);
        Task<ServiceResult<Address>> AddAddress(CreateAddressRequest request);
        Task<ServiceResult<bool>> UpdateAddress(UpdateAddressRequest request);
        Task<ServiceResult<bool>> DeleteAddress(int id);
    }
}
