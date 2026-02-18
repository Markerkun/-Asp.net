namespace Shop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public CategoryModel? Category { get; set; }

        public int BrandId { get; set; }
        public BrandModel? Brand { get; set; }
    }
}