namespace ProductManager.Api.Domain.Entities
{
    public class Product(string name, decimal price, int quantity)
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public int Quantity { get; set; } = quantity;
    }
}
