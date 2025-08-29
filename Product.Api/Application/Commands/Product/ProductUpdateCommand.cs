namespace ProductManager.Api.Application.Commands.Product
{
    public class ProductUpdateCommand(string id, string name, decimal price, int quantity)
    {
        public string Id { get; set; } = id;
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public int Quantity { get; set; } = quantity;
    }
}
