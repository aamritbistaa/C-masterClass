using System;
using UserService.Domain.Entity;

namespace UserService.Domain.Service.Interface;

public interface IUserDocumentRepository
{
    Task AddUserDocument(EUserDocument reqeust);
    Task UpdateUserDocument(EUserDocument reqeust);
    Task<List<EUserDocument>> GetAllDocumentByUserId(Guid userId);
    Task<EUserDocument> GetDocumentId(Guid Id);
}
