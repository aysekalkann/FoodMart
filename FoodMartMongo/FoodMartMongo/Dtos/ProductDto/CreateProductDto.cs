namespace FoodMartMongo.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public int StockCount { get; set; }
        public string CategoryId { get; set; }

    }
}
