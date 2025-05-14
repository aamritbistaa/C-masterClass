using System;
using MediatR;
using UserService.Domain.Abstraction;

namespace UserServie.Application.Feature.Document.Query;

public class GetAllDocumentByUserIdQuery : IRequest<ServiceResult<List<DocumentByUserIdResponse>>>
{
    public Guid UserId { get; set; }
}
