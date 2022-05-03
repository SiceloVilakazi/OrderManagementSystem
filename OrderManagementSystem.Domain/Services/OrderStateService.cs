using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace OrderManagementSystem.Domain
{
    public class OrderStateService : BaseService, IOrderStateService
    {
        private readonly IOrderStateRepository _orderStateRepository;
        private readonly IDistributedCacheRepository _distributedCacheRepository;
        private readonly string _cacheKey;
        private readonly int _absoluteExpiration;
        public OrderStateService(IOrderStateRepository orderStateRepository, IDistributedCacheRepository distributedCacheRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _orderStateRepository = orderStateRepository;
            _distributedCacheRepository = distributedCacheRepository;
            _cacheKey = "OrderStates";
            _absoluteExpiration = 5;
        }

        public async Task<OrderState> AddOrderState(OrderState orderState)
        {
            var addedOrderState = new OrderState();
            try
            {
                addedOrderState = await _orderStateRepository.AddAsync(orderState);
                await UnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            { }
            return addedOrderState;
        }

        public async Task<IEnumerable<OrderState>> GetCachedOrderStates()
        {
            return await GetCache();
        }

        public async Task<IEnumerable<OrderState>> GetCache()
        {
            var cachedOrderStates = await _distributedCacheRepository.GetAsync(_cacheKey);
            if (!string.IsNullOrEmpty(cachedOrderStates))
            {
                var orderStates = JsonConvert.DeserializeObject<List<OrderState>>(cachedOrderStates);
                return orderStates;
            }
            else
            {
                var dbOrderStates = _orderStateRepository.ListAsync();

                var jsonOrderStates = JsonConvert.SerializeObject(dbOrderStates);

                var options = new DistributedCacheEntryOptions()
                                  .SetAbsoluteExpiration(TimeSpan.FromHours(_absoluteExpiration));

                await _distributedCacheRepository.SetAsync(_cacheKey, jsonOrderStates, options);

                return (IEnumerable<OrderState>)dbOrderStates;
            }
        }

        public async Task<OrderState> GetCachedOrderStatesByKey(int orderStateId)
        {
            var orderState = await GetCache();
            return orderState.FirstOrDefault(x => x.OrderStateId == orderStateId);
        }

        public async Task<OrderState> GetOrderState(int OrderStateId)
        {
            var orderState = await _orderStateRepository.GetAsync(x => x.OrderStateId == OrderStateId);
            return orderState;
        }
        
        public async Task<OrderState> GetOrderState(string state)
        {
            var orderState = await _orderStateRepository.GetAsync(x=>x.State == state);
            return orderState;
        }
    }
}
