using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager _addressManager;

        public AddressController(IAddressManager addressManager)
        {
            _addressManager = addressManager;
        }

        [HttpGet("GetAllAddress")]
        public async Task<ServiceResult<List<Address>>> GetAllAddress()
        {
            var result = await _addressManager.GetAllAddress();
            return result;
        }

        [HttpGet("GetAddressById")]
        public async Task<ServiceResult<Address>> GetAddressById(int id)
        {
            var result = await _addressManager.GetAddressById(id);
            return result;
        }

        [HttpPost("AddAddress")]
        public async Task<ServiceResult<Address>> AddAddress(CreateAddressRequest request)
        {
            var result = await _addressManager.AddAddress(request);
            return result;
        }
        [HttpPut("UpdateAddress")]
        public async Task<ServiceResult<bool>> UpdateAddress(UpdateAddressRequest request)
        {
            var result = await _addressManager.UpdateAddress(request);

            return result;
        }
        [HttpDelete("DeleteAddress")]
        public async Task<ServiceResult<bool>> DeleteAddress(int id)
        {
            var result = await _addressManager.DeleteAddress(id);
            return result;
        }
    }
}
