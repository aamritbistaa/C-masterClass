using System;
using MediatR;

namespace UserServie.Application.Feature.User.Query;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<GetAllUserResponse>>
{
    public Task<List<GetAllUserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
