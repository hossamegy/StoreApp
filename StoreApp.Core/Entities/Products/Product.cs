using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Core.Entities.Products;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Categories Category { get; set; }
    public int BrandId { get; set; }
    
    [ForeignKey(nameof(BrandId))]
    public virtual Brands Brand { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    // Pricing
    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? DiscountPercentage { get; set; }

    // Stock
    public int StockQuantity { get; set; }

    public bool IsInStock => StockQuantity > 0;

    public bool IsActive { get; set; } = true;

    public bool IsFeatured { get; set; } = false;

    // Tracking
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}