using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Implementation
{
    public class AddressManager : IAddressManager
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly IEmployeeServiceFactory _factory;
        public AddressManager(IAddressService addressService, IMapper mapper, IEmployeeServiceFactory factory)
        {
            _addressService = addressService;
            _mapper = mapper;
            _factory = factory;
        }

        public async Task<ServiceResult<List<AddressResponse>>> GetAllAddress()
        {
            var response = await _addressService.GetAllAddress();
            var result = (
                from item in response
                select _mapper.Map<AddressResponse>(item)
                ).ToList();
            if (result.Any())
            {
                return new ServiceResult<List<AddressResponse>>
                {
                    Result = ResultStatus.Ok,
                    Message = "Displaying all Address",
                    Data = result
                };
            }
            return new ServiceResult<List<AddressResponse>>
            {
                Result = ResultStatus.Error,
                Message = "No record found for Address",
                Data = new List<AddressResponse>()
            };
        }
        public async Task<ServiceResult<AddressResponse>> GetAddressById(int id)
        {
            var response = await _addressService.GetAddressById(id);
            var result = _mapper.Map<AddressResponse>(response);
            if (result == null)
            {
                return new ServiceResult<AddressResponse>
                {
                    Result = ResultStatus.Error,
                    Message = "Address not found",
                    Data = new AddressResponse()
                };
            }
            return new ServiceResult<AddressResponse>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying Address",
                Data = result
            };
        }
        public async Task<ServiceResult<AddressResponse>> AddAddress(CreateAddressRequest request)
        {
            //var item = AddressMapper.CreateAddressRequestToAddressMapper(request);
            var item = _mapper.Map<Address>(request);
            try
            {
                _factory.BeginTransaction();
                var response = await _addressService.AddAddress(item);
                var result = _mapper.Map<AddressResponse>(response);
                if (result == null)
                {
                    _factory.RollBack();
                    return new ServiceResult<AddressResponse>
                    {
                        Result = ResultStatus.Error,
                        Message = "Address cannot be added",
                        Data = null
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<AddressResponse>
                {
                    Result = ResultStatus.Ok,
                    Message = "Address has been added",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> UpdateAddress(UpdateAddressRequest request)
        {
            var item = await _addressService.GetAddressById(request.Id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find address with specified id",
                    Data = false
                };
            }
            try
            {
                _factory.BeginTransaction();
                item.Country = request.Country;
                item.City = request.City;
                item.StreetAddress = request.StreetAddress;

                var result = await _addressService.UpdateAddress(item);
                if (result == false)
                {
                    _factory.RollBack();
                    return new ServiceResult<bool>
                    {
                        Result = ResultStatus.Error,
                        Message = "Cannot update the address.",
                        Data = result
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = "Address has been updated.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
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
            try
            {
                _factory.BeginTransaction();
                item.IsDeleted = true;
                var result = await _addressService.UpdateAddress(item);
                if (!result)
                {
                    _factory.RollBack();
                    return new ServiceResult<bool>
                    {
                        Result = ResultStatus.Error,
                        Message = "Cannot delete address",
                        Data = false
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = "Address has been deleted",
                    Data = false
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
        }


    }
}
