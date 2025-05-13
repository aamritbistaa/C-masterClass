using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using UserService.Domain.Service.Interface;

namespace UserService.Infrastructure.File;

public class FileService : IFileService
{
    private readonly IConfiguration _config;

    public FileService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        var extension = file.FileName.Split('.').Last();
        var fileName12 = file.Name;
        var fileName = Guid.NewGuid().ToString() + "." + extension;
        var directoryPath = _config["StoredFilesPath"];
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        var filePath = Path.Combine(directoryPath, fileName);

        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }
        return fileName;
    }
}
