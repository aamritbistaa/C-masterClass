using CQRSApplication.Command.CustomerCommand;
using CQRSApplication.Helpers;
using CQRSApplication.Query.CustomerQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CQRSApplication.Controllers
{
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly HttpContextHelper _httpContextHelper;

        public CustomerController(IMediator mediator, HttpContextHelper httpContextHelper)
        {
            _mediator = mediator;
            //injecting httpContextHelper class
            _httpContextHelper = httpContextHelper;
        }
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetAllCustomerQuery(), cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error("Unable to get all Customers: {@message}", ex);
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/[action]/{Id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetCustomerByIdQuery { Id = Id }, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error("Error encountered while getting the value of {@UserId} \n{Message}", Id, ex);
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/cart/[action]")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateCart(CancellationToken cancellationToken)
        {
            var command = new CreateCartCommand
            {
                //Calling ReturnUserId method from httpContextHelper class
                CustomerId = _httpContextHelper.ReturnUserId(),
            };
            try
            {

                var response = await _mediator.Send(command, cancellationToken);
                Log.Information("Cart created for Customer {@UserId} ", command.CustomerId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error("Unable to create Cart for Customer of {@UserId} \n{Message}", command.CustomerId, ex);
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/[controller]/cart/[action]")]
        [Authorize(Roles = "Customer")]
        //public async Task<IActionResult> ViewCart([FromRoute] Guid CustomerId, CancellationToken cancellationToken)
        public async Task<IActionResult> ViewCart(CancellationToken cancellationToken)

        {
            var Customerid = _httpContextHelper.ReturnUserId();

            try
            {

                var response = await _mediator.Send(new GetCartQuery { CustomerId = Customerid }, cancellationToken);
                Log.Information("{@CustomerId} viewed his/her cart", Customerid);
                return Ok(response);
            }
            catch (Exception ex)
            {

                Log.Error("Unable to find cart information for of {@CustomerId} \n{Message}", Customerid, ex);
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/[controller]/cart/[action]")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddToCart(AddToCartCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(command, cancellationToken);
                Log.Information("Item {@ProductId} added to cart for {@userId} ", command.ProductId, command.CustomerId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error("Unable to add item to cart for {@userId} {@message}", command.CustomerId, ex);
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/cart/[action]")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> RemoveFromCart(RemoveFromCartCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(command, cancellationToken);
                Log.Information("Item {@ProductId} removed from cart of {@userId} ", command.ProductId, command.CustomerId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error("Unable to remove item from cart for {@userId} {@message}", command.CustomerId, ex);
                return StatusCode(500, $"Internal Server Error:{ex.Message}");
            }
        }




    }
}