using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class BrandModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string? Country { get; set; }

        public ICollection<ProductModel>? Products { get; set; }

    }
}