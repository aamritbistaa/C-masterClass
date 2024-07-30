using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
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
        Task<ServiceResult<List<AddressResponse>>> GetAllAddress();
        Task<ServiceResult<AddressResponse>> GetAddressById(int id);
        Task<ServiceResult<AddressResponse>> AddAddress(CreateAddressRequest request);
        Task<ServiceResult<bool>> UpdateAddress(UpdateAddressRequest request);
        Task<ServiceResult<bool>> DeleteAddress(int id);
    }
}
