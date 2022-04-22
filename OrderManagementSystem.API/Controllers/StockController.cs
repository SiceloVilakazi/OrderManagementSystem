using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets available stock for a specific product
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        [HttpGet("{ProductName}")]
        public async Task<IActionResult> GetAvailableStock(string ProductName)
        {
            var query = new GetAvailableStockQuery(ProductName);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Adds new stock for a specific product
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStock(Stock stock)
        {
            var command = new AddStockCommand(stock);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
