using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.Document.Command;

public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, ServiceResult<string>>
{
    private readonly IUserDocumentRepository _userDocumentRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    public UploadDocumentCommandHandler(IUserDocumentRepository userDocumentRepository, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork)
    {
        _userDocumentRepository = userDocumentRepository;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<string>> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
    {
        //get existing document by userId
        var existingDocument = await _userDocumentRepository.GetAllDocumentByUserId(request.UserId);
        if (!existingDocument.Any())
        {
            foreach (var document in request.Documents)
            {
                await _userDocumentRepository.AddUserDocument(new EUserDocument
                {
                    UserId = request.UserId,
                    CreatedBy = request.ActionBy,
                    CreatedDate = _dateTimeProvider.CurrentDate,
                    DocumentType = document.DocumentType,
                    Description = document.Description,
                    DocumentName = document.FileName,
                    DocumentStatus = DocumentStatus.Pending
                });
                await _unitOfWork.SaveChangesAsync();
            }
        }
        else
        {
            foreach (var document in request.Documents)
            {
                var documentToDelete = existingDocument.Where(x => x.DocumentType == document.DocumentType);
                foreach (var item in documentToDelete)
                {
                    item.IsDeleted = true;
                    item.DeletedDate = _dateTimeProvider.CurrentDate;
                    item.UpdatedBy = request.ActionBy;
                    await _userDocumentRepository.UpdateUserDocument(item);
                }

                await _userDocumentRepository.AddUserDocument(new EUserDocument
                {
                    UserId = request.UserId,
                    CreatedBy = request.ActionBy,
                    CreatedDate = _dateTimeProvider.CurrentDate,
                    DocumentType = document.DocumentType,
                    Description = document.Description,
                    DocumentName = document.FileName,
                    DocumentStatus = DocumentStatus.Pending
                });
                await _unitOfWork.SaveChangesAsync();
            }
        }

        return new ServiceResult<string>
        {
            Data = "",
            Message = "Document uploaded successfully",
            StatusCode = 200
        };
    }
}
