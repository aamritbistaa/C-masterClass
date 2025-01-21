using System;
using ErrorOr;
using GymManagement.Application.Common.Interface;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<ESubscriptions>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    // private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        // _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<ESubscriptions>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        //Create subscription
        var subscription = new ESubscriptions(subscriptionType: request.SubscriptionType, adminId:request.AdminId);

        //Add to database
        await _subscriptionRepository.AddSubscription(subscription);
        // await _unitOfWork.ComitChangesAsync();
        //return subscription
        return subscription;
    }
}
