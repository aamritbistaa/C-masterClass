using System;
using MediatR;

namespace UserServie.Application.Feature.User.Command;

public class GenerateOtpCommand : IRequest
{
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}
