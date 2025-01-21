using System.Threading.Tasks;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISender _mediator;
        public SubscriptionsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateSubscription")]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
        {

            if (!DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType))
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid subscription type");
            }
            var command = new CreateSubscriptionCommand(subscriptionType, request.AdminId);
            var result = await _mediator.Send(command);

            return result.MatchFirst(subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)), error => Problem());
        }

        [HttpGet("GetSubscription")]
        public async Task<IActionResult> GetSubscription(Guid id)
        {
            var command = new GetSubscriptionQuery(id);
            var result = await _mediator.Send(command);
            return result.MatchFirst(subscription => Ok(new SubscriptionResponse(subscription.Id, Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))), error => Problem(error.Description));
        }
    }
}
