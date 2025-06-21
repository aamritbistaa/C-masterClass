using System;
using Basket.Api.Data;

namespace Basket.Api.Basket.DeleteBasket;

public record DeleteBasketCommand(string username) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool isSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.username).NotEmpty().WithMessage("UserName is required");
    }
}
public class DeleteBasketHandler(IBasketRepository basketRepository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var response = await basketRepository.DeleteBasket(request.username);
        return new DeleteBasketResult(response);
    }
}
