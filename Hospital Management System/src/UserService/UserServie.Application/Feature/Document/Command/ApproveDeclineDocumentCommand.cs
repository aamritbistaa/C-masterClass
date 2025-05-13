using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserServie.Application.Common;

namespace UserServie.Application.Feature.Document.Command;

public class ApproveDeclineDocumentCommand : CommonCommandParameter, IRequest<ServiceResult<string>>
{
    public Guid Id { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
}
