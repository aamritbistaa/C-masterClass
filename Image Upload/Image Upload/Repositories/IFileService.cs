namespace Image_Upload.Repositories
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file, string[] allowedFileExtensions);
        void DeleteFile(string fileNameWithExtension);
    }
}
