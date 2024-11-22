using MediatR;

namespace CQRSApplication.Command.AuthUserCommand
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
    }
}
