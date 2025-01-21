using System;
using ErrorOr;
using GymManagement.Application.Common.Interface;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<ESubscriptions>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public GetSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<ErrorOr<ESubscriptions>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
    {

        var data = await _subscriptionRepository.GetSubscription(request.Id);
        return data is null ? Error.NotFound(description: "No data found") : data;
    }
}
