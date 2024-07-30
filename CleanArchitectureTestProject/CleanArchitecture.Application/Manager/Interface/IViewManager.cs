using CleanArchitecture.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Interface
{
    public interface IViewManager
    {
        Task<ServiceResult<List<ViewEmployeeResponse>>> GetAllEmployeeDetails();
    }
}
