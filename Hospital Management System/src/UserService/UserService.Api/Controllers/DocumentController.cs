using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Abstraction;
using UserService.Domain.Service.Interface;
using UserServie.Application.Feature.Document.Command;
using UserServie.Application.Feature.Document.Query;

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

        /// <summary>
        /// This api is used to upload file to the server and returns the file name.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("File")]
        public async Task<string> Upload(IFormFile request)
        {
            var response = await _fileService.UploadFile(request);
            return response;
        }
        /// <summary>
        /// This api is use to upload documents alson with descriptions of it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public async Task<ServiceResult<string>> UploadDocument(UploadDocumentCommand request)
        {
            var response = await _sender.Send(request);
            return response;
        }
        /// <summary>
        /// This api is use to approve or decline each document of staff.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ApproveDecline")]
        public async Task<ServiceResult<string>> ApproveDeclineDocument(ApproveDeclineDocumentCommand request)
        {
            var response = await _sender.Send(request);
            return response;
        }
        /// <summary>
        /// This is a api to get all document based on userId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ServiceResult<List<DocumentByUserIdResponse>>> GetAllDocument(Guid UserId)
        {
            var request = new GetAllDocumentByUserIdQuery
            {
                UserId = UserId
            };
            var response = await _sender.Send(request);
            return response;
        }

    }
}
