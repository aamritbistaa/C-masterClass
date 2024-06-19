using Image_Upload.Context;
using Image_Upload.Model;
using Image_Upload.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Image_Upload.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        public class CreateProduct
        {
            public string Name { get; set; }
            public FormFile? ImageFile { get; set; }
        }

        public class UpdateProduct
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public IFormFile? ImageFile { get; set; }

        }
        private readonly IFileService _fileService;
        private readonly ApplicationDbContext _context;
        public ProductController(IFileService fileService, ApplicationDbContext context)
        {
            _fileService = fileService;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProduct item)
        {
            try
            {
                var product = new Product();
                if (item.ImageFile != null)
                {
                    if (item.ImageFile.Length > 1 * 1024 * 1024)
                    {
                        return StatusCode(400, $"File size more than 1MB");
                    }
                    string[] allowedFileExtensions = [".jpg", ".jpeg", ".png"];
                    string createdImageName = await _fileService.UploadFile(item.ImageFile, allowedFileExtensions);
                    product.ImageName = createdImageName;
                }
                product.Id = Guid.NewGuid();
                product.Name = item.Name;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProduct item)
        {
            try
            {
                var existingProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == item.Id);

                if (existingProduct == null)
                {
                    throw new Exception("Unable to find the Product");
                }
                string oldImage = existingProduct.ImageName;

                if (item.ImageFile != null)
                {
                    if (item.ImageFile.Length > 1 * 1024 * 1024)
                    {
                        throw new Exception("File size exceeds 1MB");
                    }
                    string[] allowedFileExtensions = [".jpg", ".jpeg", ".png"];
                    string createdImageName = await _fileService.UploadFile(item.ImageFile, allowedFileExtensions);
                    existingProduct.ImageName = createdImageName;
                    if (oldImage != null)
                    {
                        _fileService.DeleteFile(oldImage);
                    }
                }
                else
                {
                    existingProduct.ImageName = oldImage;
                }
                existingProduct.Name = item.Name;
                await _context.SaveChangesAsync();
                return Ok(existingProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }
    }
}
