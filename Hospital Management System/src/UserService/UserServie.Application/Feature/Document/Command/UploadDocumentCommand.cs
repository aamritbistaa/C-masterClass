using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using Microsoft.AspNetCore.Http;
using UserServie.Application.Common;

namespace UserServie.Application.Feature.Document.Command;

public class UploadDocumentCommand : CommonCommandParameter, IRequest<ServiceResult<string>>
{
    public Guid UserId { get; set; }
    public List<Document> Documents { get; set; } = new List<Document>();
}

public class Document
{
    public DocumentType DocumentType { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; } = string.Empty;
}