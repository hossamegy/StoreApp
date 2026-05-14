
namespace StoreApp.Contracts.Products.Requests;

public class ProductRequest
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<string> ImageUrls { get; set; } = new();

    public int CategoryId { get; set; }

    public int BrandId { get; set; }

    // Pricing
    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? DiscountPercentage { get; set; }

    // Stock
    public int StockQuantity { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsFeatured { get; set; } = false;
}
