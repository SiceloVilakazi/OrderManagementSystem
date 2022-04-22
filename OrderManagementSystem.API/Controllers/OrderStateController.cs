using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderStateController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Adds a new Order State
        /// </summary>
        /// <param name="orderState"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddOrderState([FromBody] OrderState orderState)
        {
            var command = new AddOrderStateCommand(orderState);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
