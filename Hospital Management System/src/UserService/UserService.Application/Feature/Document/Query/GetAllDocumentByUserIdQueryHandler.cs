using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.Document.Query;

public class GetAllDocumentByUserIdQueryHandler : IRequestHandler<GetAllDocumentByUserIdQuery, ServiceResult<List<DocumentByUserIdResponse>>>
{
    private readonly IUserDocumentRepository _userDocumentRepository;

    public GetAllDocumentByUserIdQueryHandler(IUserDocumentRepository userDocumentRepository)
    {
        _userDocumentRepository = userDocumentRepository;
    }

    public async Task<ServiceResult<List<DocumentByUserIdResponse>>> Handle(GetAllDocumentByUserIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _userDocumentRepository.GetAllDocumentByUserId(request.UserId);
        var response = data.Select(x => new DocumentByUserIdResponse
        {
            Id = x.Id,
            DocumentName = x.DocumentName,
            DocumentStatus = ((DocumentStatus)x.DocumentStatus).ToString(),
            DocumentType = ((DocumentType)x.DocumentType).ToString(),
            Description = x.Description,
        }).ToList();
        return new ServiceResult<List<DocumentByUserIdResponse>>
        {
            Data = response,
            Message = "Data fetched successfully",
            StatusCode = 200
        };
    }
}
