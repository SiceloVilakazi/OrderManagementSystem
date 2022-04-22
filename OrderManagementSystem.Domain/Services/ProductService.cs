
namespace OrderManagementSystem.Domain
{
    public class ProductService :BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var newproduct=new Product();
            try
            {
                newproduct =await _productRepository.AddAsync(product);
                await UnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            return newproduct;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetAsync(x=>x.ProductId == productId);
            var deleted = _productRepository.DeleteAsync(product);
            return deleted.Result;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.ListAsync();  
            return products;
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            var searchText = name.ToLower().Trim();
            var product = await _productRepository.GetAsync(x=>x.Name.ToLower().Trim()== searchText);
            return product;
        }
    }
}
