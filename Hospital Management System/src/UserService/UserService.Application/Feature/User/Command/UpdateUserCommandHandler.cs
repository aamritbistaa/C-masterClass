using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserService.Application.Feature.User.Command;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ServiceResult<string>>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserCommandHandler(IDateTimeProvider dateTimeProvider, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUserData = await _userRepository.GetUserById(request.Id);
        if (existingUserData == null)
        {
            return new ServiceResult<string>()
            {
                Message = "User detail not found",
                StatusCode = 200
            };
        }
        existingUserData.FirstName = request.FirstName;
        existingUserData.LastName = request.LastName;
        existingUserData.MiddleName = request.MiddleName;
        existingUserData.Email = request.Email;
        existingUserData.UpdatedBy = request.ActionBy;
        existingUserData.UpdatedDate = _dateTimeProvider.CurrentDate;

        await _userRepository.UpdateAsync(existingUserData);
        var result = await _unitOfWork.SaveChangesAsync();
        return new ServiceResult<string>
        {
            Data = "",
            Message = "Updated successfully",
            StatusCode = 201
        };
    }
}