
namespace Image_Upload.Repositories
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void DeleteFile(string fileNameWithExtension)
        {
            if(fileNameWithExtension == null)
            {
                throw new Exception("File name is empty");
            }
            var contentPath = _environment.ContentRootPath;
            var fileNameWithPath = Path.Combine(contentPath,"Uploads" ,fileNameWithExtension);
            if (!File.Exists(fileNameWithPath))
            {
                throw new Exception($"Unable to find the file {fileNameWithExtension}");

            }
            File.Delete(fileNameWithPath);
 }

        public async Task<string> UploadFile(IFormFile file, string[] allowedFileExtensions)
        {
            if (file == null)
            {
                throw new Exception("File you are trying to upload is null.");
            }
            var contentPath = _environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var extension = Path.GetExtension(file.FileName);
            if (!allowedFileExtensions.Contains(extension))
            {
                throw new Exception($"Not an allowed file format, must be in format{string.Join(',', allowedFileExtensions)}");
            }
            var fileName = $"{Guid.NewGuid().ToString()}{extension}";
            var fileNameWithPath = Path.Combine(path, fileName);
            using var stream = new FileStream(fileNameWithPath, FileMode.CreateNew);
            await file.CopyToAsync(stream);
            return fileName;
        }
        
    }
}
