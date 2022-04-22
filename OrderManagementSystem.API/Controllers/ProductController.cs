using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets list of all available Products
        /// </summary>
        /// <returns>Json object list</returns>
       // /// <response code="302">Returns the list of available products</response>
       // /// <response code="400">If the list is empty</response>
        [HttpGet]
       // [ProducesResponseType(StatusCodes.Status302Found)]
       // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var response = await  _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Gets a product by a given product name
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        /// <response code="302">Returns the product of the given name</response>
        /// <response code="404">If there is no product called by that name</response>
        [HttpGet("{ProductName}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByProductName(string ProductName)
        {
            var query = new GetProductByProductNameQuery(ProductName);
            var response = await _mediator.Send(query);
            return Ok(response);
        }


        /// <summary>
        /// saves a new product to the system
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created product</response>
        /// <response code="400">If the product is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var command = new AddProductCommand(product);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Deletes a product by a given product Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        /// <response code="200">Returns ok if product was sucessfully deleted</response>
        /// <response code="400">If no product was found</response>
        [HttpDelete("{ProductId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveProduct(int ProductId)
        {
            var command = new RemoveProductCommand(ProductId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
