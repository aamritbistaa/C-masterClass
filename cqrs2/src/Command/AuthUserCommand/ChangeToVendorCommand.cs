using CQRSApplication.Model;
using MediatR;

namespace CQRSApplication.Command.AuthUserCommand
{
    public class ChangeToVendorCommand : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
