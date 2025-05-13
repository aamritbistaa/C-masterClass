using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Abstraction;
using UserService.Domain.Service.Interface;
using UserServie.Application.Feature.Document.Command;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IFileService _fileService;

        public DocumentController(ISender sender, IFileService fileService)
        {
            _sender = sender;
            _fileService = fileService;
        }

        [HttpPost("File")]
        public async Task<string> Upload(IFormFile request)
        {
            var response = await _fileService.UploadFile(request);
            return response;
        }
        [HttpPost("Upload")]
        public async Task<ServiceResult<string>> UploadDocument(UploadDocumentCommand request)
        {
            var response = await _sender.Send(request);
            return response;
        }
        //Staff
        [HttpPost("ApproveDecline")]
        public async Task<ServiceResult<string>> ApproveDeclineDocument(ApproveDeclineDocumentCommand request)
        {
            var response = await _sender.Send(request);
            return response;
        }

    }
}
