using CQRSApplication.Model;
using MediatR;

namespace CQRSApplication.Command.AuthUserCommand
{
    public class ChangeToMemberCommand : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
