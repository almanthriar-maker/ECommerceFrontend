using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ECommerceFrontend.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
    public int Stock { get; set; }

    public List<Review> Reviews { get; set; } = new List<Review>();

    [NotMapped]
    public decimal OverallRating
    {
        get
        {
            if (Reviews == null || Reviews.Count == 0)
                return 0;

            return (decimal)Reviews.Average(r => r.Rating);
        }
    }
}