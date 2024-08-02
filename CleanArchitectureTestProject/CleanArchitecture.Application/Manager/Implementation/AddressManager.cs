using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Service.Interface;
using static CleanArchitecture.Application.Common.CommonUtils;
using static CleanArchitecture.Application.Common.Message;

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
            
            if (response.Any())
            {
                var result = (
                from item in response
                select _mapper.Map<AddressResponse>(item)
                ).ToList();
                return new ServiceResult<List<AddressResponse>>
                {
                    Result = ResultStatus.Ok,
                    Message = AddressMessage.Displaying,
                    Data = result
                };
            }
            return new ServiceResult<List<AddressResponse>>
            {
                Result = ResultStatus.Error,
                Message = AddressMessage.Empty,
                Data = new List<AddressResponse>()
            };
        }
        public async Task<ServiceResult<AddressResponse>> GetAddressById(int id)
        {
            var response = await _addressService.GetAddressById(id);
            //var result = _mapper.Map<AddressResponse>(response);
           
            if (response == null)
            {
                return new ServiceResult<AddressResponse>
                {
                    Result = ResultStatus.Error,
                    Message = AddressMessage.ItemNotFound,
                    Data = new AddressResponse()
                };
            }
            var result = AddressMapper.AddressToAddressResponseMapper(response);
            return new ServiceResult<AddressResponse>
            {
                Result = ResultStatus.Ok,
                Message = AddressMessage.Displaying,
                Data = result
            };
        }
        public async Task<ServiceResult<AddressResponse>> AddAddress(CreateAddressRequest request)
        {
            try
            {
                _factory.BeginTransaction();
                var item = AddressMapper.CreateAddressRequestToAddressMapper(request);

                var response = await _addressService.AddAddress(item);
                var result = AddressMapper.AddressToAddressResponseMapper(response);
                if (result == null)
                {
                    _factory.RollBack();
                    return new ServiceResult<AddressResponse>
                    {
                        Result = ResultStatus.Error,
                        Message = AddressMessage.ErrorWhileAdding,
                        Data = null
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<AddressResponse>
                {
                    Result = ResultStatus.Ok,
                    Message = AddressMessage.SuccessAdding,
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
                    Message = AddressMessage.ItemNotFound,
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
                        Message = AddressMessage.ErrorWhileUpdating,
                        Data = result
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = AddressMessage.SuccessUpdating,
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
                    Message = AddressMessage.ItemNotFound,
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
                        Message = AddressMessage.ErrorWhileDeleting,
                        Data = false
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = AddressMessage.SuccessDeleting,
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
