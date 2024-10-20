using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISender _mediator;


        public SubscriptionController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
        {
            if (!DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType))
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid subscription type");
            }

            var command = new CreateSubscriptionCommand(subscriptionType, request.AdminId);

            var createSubscriptionResult = await _mediator.Send(command);

            return createSubscriptionResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
                error => Problem()
            );
        }

        [HttpGet("{SubscriptionId:guid}")]
        public async Task<IActionResult> GetSubscription(Guid SubscriptionId)
        {
            var query = new GetSubscriptionQuery(SubscriptionId);

            var getSubscriptionResult = await _mediator.Send(query);
            return getSubscriptionResult.MatchFirst(x => Ok(new SubscriptionResponse(SubscriptionId, Enum.Parse<SubscriptionType>(x.SubscriptionType.Name))), error => Problem());
        }
    }
}
