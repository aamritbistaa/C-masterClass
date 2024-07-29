using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Implementation
{
    public class AddressManager:IAddressManager
    {
        public readonly IAddressService _addressService;

        public AddressManager(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<ServiceResult<List<Address>>> GetAllAddress()
        {
            var result = await _addressService.GetAllAddress();

            if (result.Any())
            {
                return new ServiceResult<List<Address>>
                {
                    Result=ResultStatus.Ok,
                    Message="Displaying all Address",
                    Data = result
                };
            }
            return new ServiceResult<List<Address>>
            {
                Result = ResultStatus.Error,
                Message = "No record found for Address",
                Data = new List<Address>()
            };
        }
        public async Task<ServiceResult<Address>> GetAddressById(int id)
        {
            var result = await _addressService.GetAddressById(id);
            if (result == null)
            {
                return new ServiceResult<Address>
                {
                    Result = ResultStatus.Error,
                    Message = "Address not found",
                    Data = new Address()
                };
            }
            return new ServiceResult<Address>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying Address",
                Data = result
            };
        }
        public async Task<ServiceResult<Address>> AddAddress(CreateAddressRequest request)
        {
            var item = AddressMapper.CreateAddressRequestToAddressMapper(request);
            var result = await _addressService.AddAddress(item);
            if (result == null) {
                return new ServiceResult<Address>
                {
                    Result = ResultStatus.Error,
                    Message = "Address cannot be added",
                    Data = null
                };
            }
            return new ServiceResult<Address>
            {
                Result = ResultStatus.Ok,
                Message = "Address has been added",
                Data = result
            };
        }
        public async Task<ServiceResult<bool>> UpdateAddress(UpdateAddressRequest request)
        {
            var item = await _addressService.GetAddressById(request.Id);   
            if(item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find address with specified id",
                    Data = false
                };
            }

            item.Country = request.Country;
            item.City = request.City;
            item.StreetAddress = request.StreetAddress;

            var result = await _addressService.UpdateAddress(item);
            if (result == false)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot update the address.",
                    Data = result
                };
            }
            return new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Address has been updated.",
                Data = result
            };
        }

        public async Task<ServiceResult<bool>> DeleteAddress(int id)
        {
            var item = await _addressService.GetAddressById(id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find Address",
                    Data = false
                };
            }
            item.IsDeleted = true;
            var result = await _addressService.UpdateAddress(item);
            if (!result)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot delete address",
                    Data = false
                };
            }
            return new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Address has been deleted",
                Data = false
            };
        }


    }
}
