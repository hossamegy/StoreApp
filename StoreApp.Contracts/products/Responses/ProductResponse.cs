namespace StoreApp.Contracts.Products.Responses;

public class ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public int BrandId { get; set; }

    public string BrandName { get; set; } = string.Empty;

    public List<string> ProductImages { get; set; } = new();

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public int StockQuantity { get; set; }

    public bool IsInStock { get; set; }

    public bool IsActive { get; set; }

    public bool IsFeatured { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}