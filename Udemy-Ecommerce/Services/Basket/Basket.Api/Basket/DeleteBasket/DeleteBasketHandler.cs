using System;

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
public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        //Todo: delete basket from database and cache 
        //session.Delete<Product>(requeest.Id);
        return new DeleteBasketResult(true);
    }
}
