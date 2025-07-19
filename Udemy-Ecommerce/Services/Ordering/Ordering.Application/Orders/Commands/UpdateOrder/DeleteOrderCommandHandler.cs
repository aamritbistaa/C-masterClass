using System;
using Ordering.Application.Data;
using Ordering.Application.Exception;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class DeleteOrderCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(request.OrderId);

        var order = await dbContext.Orders.FindAsync(orderId);

        if (order == null)
        {
            throw new OrderNotFoundException(request.OrderId);
        }
        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync();

        return new DeleteOrderResult(true);
    }
}
