using System;
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);


public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is requrired");
        RuleFor(x => x.Order.CustomerId).NotEmpty().WithMessage("CustomerId is requrired");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems is requrired");
    }
}
