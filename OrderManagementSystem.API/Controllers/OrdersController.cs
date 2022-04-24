using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a list of all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetOrdersQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Gets a list of Orders from a given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("GetOrderByDate/{date}")]
        public async Task<IActionResult> GetOrdersByDate(DateTime date)
        {
            var query = new GetOrdersByDateQuery(date);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Gets a specific order from a given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetOrderByName/{name}")]
        public async Task<IActionResult> GetOrderByName(string name)
        {
            var query = new GetOrderByNameQuery(name);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// places a new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            var command = new PlaceOrderCommand(order);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// cancels an existing order by an Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> CancelOrder(int Id)
        {
            var command = new CancelOrderCommand(Id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Completes an order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("CompleteOrder/{Id}")]
        public async Task<IActionResult> CompleteOrder(int Id)
        {
            var command = new CompleteOrderCommand(Id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
