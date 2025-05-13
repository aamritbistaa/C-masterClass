using System;
using UserService.Domain.Abstraction;

namespace UserService.Domain.Entity;

public class EUserDocument : BaseEntity
{
    public Guid UserId { get; set; }
    public DocumentType DocumentType { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
    public string DocumentName { get; set; }
    public string Description { get; set; } = string.Empty;
}
public enum DocumentType
{
    NationalID,
    Passport,
    Liscence,
    Certificate,
    Other
}
public enum DocumentStatus
{
    Approved,
    Rejected,
    Pending
}