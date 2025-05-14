using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.Document.Command;

public class ApproveDeclineDocumentCommandHandler : IRequestHandler<ApproveDeclineDocumentCommand, ServiceResult<string>>
{
    private readonly IUserDocumentRepository _userDocumentRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    public ApproveDeclineDocumentCommandHandler(IUserDocumentRepository userDocumentRepository, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork)
    {
        _userDocumentRepository = userDocumentRepository;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<string>> Handle(ApproveDeclineDocumentCommand request, CancellationToken cancellationToken)
    {
        var userDocument = await _userDocumentRepository.GetDocumentId(request.Id);
        if (userDocument == null)
        {
            return new ServiceResult<string>
            {
                Message = "Document not found",
                Data = "",
                StatusCode = 201
            };
        }
        userDocument.UpdatedDate = _dateTimeProvider.CurrentDate;
        userDocument.UpdatedBy = request.ActionBy;
        userDocument.DocumentStatus = request.DocumentStatus;
        await _userDocumentRepository.UpdateUserDocument(userDocument);
        await _unitOfWork.SaveChangesAsync();

        return new ServiceResult<string>
        {
            Data = "",
            Message = "Document status updated successfully",
            StatusCode = 200
        };
    }
}
