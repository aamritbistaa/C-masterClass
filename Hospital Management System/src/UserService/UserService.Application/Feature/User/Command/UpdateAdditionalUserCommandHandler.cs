using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserService.Application.Feature.User.Command;

public class UpdateAdditionalUserCommandHandler : IRequestHandler<UpdateAdditionalUserCommand, ServiceResult<string>>
{
    private readonly IUserDetailRepository _userDetailRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateAdditionalUserCommandHandler(IUserDetailRepository userDetailRepository, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork)
    {
        _userDetailRepository = userDetailRepository;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }
    public async Task<ServiceResult<string>> Handle(UpdateAdditionalUserCommand request, CancellationToken cancellationToken)
    {
        var existingData = await _userDetailRepository.GetById(request.Id);
        if (existingData == null)
        {
            return new ServiceResult<string>()
            {
                Message = "Data not found"
            };
        }
        existingData.AdditionalContactNumber = request.AdditionalContactNumber;
        existingData.DateOfBirth = request.DateOfBirth;
        existingData.BloodGroup = request.BloodGroup;
        existingData.UpdatedBy = request.ActionBy;
        existingData.UpdatedDate = _dateTimeProvider.CurrentDate;
        await _userDetailRepository.UpdateUserDetail(existingData);
        await _unitOfWork.SaveChangesAsync();
        return new ServiceResult<string>
        {
            StatusCode = 200,
            Message = "updated successfully",
            Data = ""
        };
    }
}
