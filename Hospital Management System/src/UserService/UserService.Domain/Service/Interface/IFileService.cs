using System;
using Microsoft.AspNetCore.Http;

namespace UserService.Domain.Service.Interface;

public interface IFileService
{
    Task<string> UploadFile(IFormFile file);
}
