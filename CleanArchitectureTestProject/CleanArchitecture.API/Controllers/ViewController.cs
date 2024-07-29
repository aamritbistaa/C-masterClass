using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ViewController : ControllerBase
    {
        private readonly IViewManager _viewManager;

        public ViewController(IViewManager viewManager)
        {
            _viewManager = viewManager;
        }
        [HttpGet("DetailedListOfEmployees")]
        public async Task<ServiceResult<List<EmployeeResponse>>> GetAllEmployeeDetails()
        {
            var result = await _viewManager.GetAllEmployeeDetails();
            return result;
        }
    }
}
