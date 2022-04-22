
namespace OrderManagementSystem.Domain
{
    public partial class Product
    {
        public Product()
        {
            Stocks = new HashSet<Stock>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
