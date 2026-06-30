using System.ComponentModel.DataAnnotations;

namespace ECommerceFrontend.DTOs
{
    public class UpdateProductDTO
    {
        public int ProductId { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }


    }
}
