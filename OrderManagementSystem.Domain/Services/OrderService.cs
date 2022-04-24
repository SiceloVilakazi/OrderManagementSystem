namespace OrderManagementSystem.Domain
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStateRepository _orderStateRepository;
        private readonly IStockService _stockService;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository,IOrderStateRepository orderStateRepository,
            IStockService stockService ,IProductRepository productRepository , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _orderRepository = orderRepository;
            _orderStateRepository = orderStateRepository;
            _stockService = stockService;
            _productRepository = productRepository;
        }
        public async Task<string> CancelOrder(int orderId)
        {
            var state = await _orderStateRepository.GetAsync(x=>x.State=="Cancelled");
            var CompletedState = await _orderStateRepository.GetAsync(x => x.State == "Completed");
            var order = await _orderRepository.GetAsync(x => x.OrderId == orderId);
            var orderstate = await GetOrderState(orderId);

            if(orderstate ==state.OrderStateId)
            {
                return String.Format("Order number {0}, has already been cancelled", order.OrderId);
            }

            if (orderstate != CompletedState.OrderStateId)
            {
                #region update stock
                var stock = await _stockService.GetStock(order.ProductId);
                stock.AvailableStock += order.Quantity;
                var returnStock = await _stockService.UpdateStock(stock);
                #endregion

                order.OrderStateId = state.OrderStateId;
                await _orderRepository.UpdateAsync(order);
                await UnitOfWork.CommitAsync();
                return String.Format("Order number {0}, has been cancelled", order.OrderId);
            }
            else
            {
                return String.Format("Order number {0}, cannot be cancelled because it is in a completed state", order.OrderId);
            }
        }

        public async Task<string> CompleteOrder(int orderId)
        {
            var state = await _orderStateRepository.GetAsync(x=>x.State=="Completed");
            var order = await _orderRepository.GetAsync(x => x.OrderId == orderId);

            order.OrderStateId = state.OrderStateId;
            await _orderRepository.UpdateAsync(order);
            await UnitOfWork.CommitAsync();
            return String.Format("Order number {0}, has been completed", order.OrderId);
        }

        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
           var orders = await _orderRepository.ListAsync(x=>x.CreatedDateUtc.ToShortDateString()
                                                      ==date.ToShortDateString());
            return orders;
        }

        public async Task<Order> GetOrderByName(string Name)
        {
            var order = await _orderRepository.GetAsync(x => x.Name == Name);
            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            var Orders = await _orderRepository.ListAsync();
            return Orders;
        }

        public async Task<string> PlaceOrder(Order order)
        {
            try
            {
               var state = await _orderStateRepository.GetAsync(x=>x.State=="Reserved");
               var product = await _productRepository.GetAsync(x=>x.ProductId == order.ProductId);
               var stockAvailable = await _stockService.GetAvailableStock(product.Name);
                if(stockAvailable.AvailableStock>=order.Quantity)
                {
                    stockAvailable.AvailableStock =stockAvailable.AvailableStock -order.Quantity;
                    var updatedStock= await _stockService.UpdateStock(stockAvailable);
                    var saved = await _orderRepository.AddAsync(new Order
                    {
                        Quantity = order.Quantity,
                        ProductId = order.ProductId,
                        Name = order.Name,
                        OrderStateId = state.OrderStateId,
                        CreatedDateUtc = DateTime.Now,

                    });
                    await UnitOfWork.CommitAsync();
                    return "successfully placed an order";
                }
                else
                {
                    throw new Exception("The product is currently out of stock, try a different product");
                }
            
            }
            catch (Exception ex)
            { }
            return "failed to place an order";
        }

        internal async Task<int> GetOrderState(int OrderId)
        {
            var order = await _orderRepository.GetAsync(x=>x.OrderId == OrderId);
            return order.OrderStateId;
        }
    }
}
