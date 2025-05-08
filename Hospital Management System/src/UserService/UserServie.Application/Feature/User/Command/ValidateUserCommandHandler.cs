using System;
using MediatR;

namespace UserServie.Application.Feature.User.Command;

public class ValidateUserCommandHandler : IRequestHandler<ValidateUserCommand, bool>
{
    public Task<bool> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
