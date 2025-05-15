using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserService.Application.Feature.User.Command;

public class AddAdditionalUserCommandHandler : IRequestHandler<AddAdditionalUserCommand, ServiceResult<string>>
{
    private readonly IUserDetailRepository _userDetailRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    public AddAdditionalUserCommandHandler(IUserDetailRepository userDetailRepository, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork)
    {
        _userDetailRepository = userDetailRepository;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<string>> Handle(AddAdditionalUserCommand request, CancellationToken cancellationToken)
    {
        if (request.ActionBy == Guid.Empty)
            return new ServiceResult<string>()
            {
                Message = "User not found",
                StatusCode = 200
            };
        var model = new EUserDetail
        {
            UserId = request.UserId,
            AdditionalContactNumber = request.AdditionalContactNumber,
            BloodGroup = request.BloodGroup,
            CreatedBy = request.ActionBy,
            CreatedDate = _dateTimeProvider.CurrentDate,
            DateOfBirth = request.DateOfBirth,
        };
        await _userDetailRepository.AddUserDetail(model);
        await _unitOfWork.SaveChangesAsync();
        return new ServiceResult<string>
        {
            StatusCode = 200,
            Message = "added successfully",
            Data = ""
        };
    }
}
