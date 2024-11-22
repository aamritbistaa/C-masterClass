using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSApplication.Command.AuthUserCommand;
using CQRSApplication.Context;
using FluentValidation;

namespace src.Command.AuthUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
            .NotEmpty()
            .WithMessage("First Name for User Command Cannot be empty");

            RuleFor(p => p.FirstName)
            .MaximumLength(20)
            .WithMessage("First Name length cannot be more than 20");

            RuleFor(p => p.FirstName)
            .MinimumLength(2)
            .WithMessage("First Name length must be more than 2");

            RuleFor(p => p.UserCredentials.UserName)
                        .NotEmpty()
                        .WithMessage("UserName for User Command Cannot be empty");

            RuleFor(p => p.FirstName)
            .MaximumLength(10)
            .WithMessage("UserName length cannot be more than 10");

            RuleFor(p => p.FirstName)
            .MinimumLength(5)
            .WithMessage("UserName length must be more than 5");

            RuleFor(p => p.UserCredentials.UserName)
            .Matches("[a-z]").WithMessage("UserName must contain atleast one uppercase letter");

            //Password Verification, with atleast 6 character long, atleast one uppercase,lowercase, symbol and number"

            RuleFor(x => x.UserCredentials.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");

            RuleFor(x => x.UserCredentials.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress();
        }
    }
}