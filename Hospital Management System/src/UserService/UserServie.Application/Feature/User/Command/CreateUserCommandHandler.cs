using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.User.Command;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserCommandHandler(IDateTimeProvider dateTimeProvider, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userModel = new EUser
        {
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            Email = request.Email,
            CreatedDate = _dateTimeProvider.CurrentDate,
            CreatedBy = Guid.Empty,
            MobileNumber = request.MobileNumber,
            Id = Guid.NewGuid()
        };
        await _userRepository.AddAsync(userModel);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result == 1)
        {

            return userModel.Id;
        }
        else
        {
            throw new Exception("Cannot add");
        }
    }
}
