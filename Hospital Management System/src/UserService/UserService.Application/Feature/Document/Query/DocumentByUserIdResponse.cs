using System;

namespace UserServie.Application.Feature.Document.Query;

public class DocumentByUserIdResponse
{
    public Guid Id { get; set; }
    public string DocumentType { get; set; }
    public string DocumentStatus { get; set; }
    public string DocumentName { get; set; }
    public string Description { get; set; } = string.Empty;
}
