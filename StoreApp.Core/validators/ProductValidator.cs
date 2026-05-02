using FluentValidation;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        // Name
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(150).WithMessage("Product name must not exceed 150 characters");

        // Description
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

        // Iamges
        RuleFor(p => p.ProductImages)
            .NotNull().WithMessage("Images list cannot be null")
            .Must(list => list.Count > 0).WithMessage("At least one image is required")
            .Must(list => list.Count <= 5).WithMessage("Maximum 5 images allowed");

        RuleForEach(p => p.ProductImages)
            .Must(img => !string.IsNullOrEmpty(img.ImageUrl))
            .WithMessage("Image URL cannot be empty")
            .Must(img => Uri.IsWellFormedUriString(img.ImageUrl, UriKind.Absolute))
            .WithMessage("Invalid image URL format");

        // Price
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        // Discount logic
        RuleFor(p => p.DiscountPrice)
            .GreaterThan(0)
            .When(p => p.DiscountPrice.HasValue)
            .WithMessage("Discount price must be greater than 0");

        RuleFor(p => p)
            .Must(p => !p.DiscountPrice.HasValue || p.DiscountPrice < p.Price)
            .WithMessage("Discount price must be less than original price");

        RuleFor(p => p.DiscountPercentage)
            .InclusiveBetween(0, 100)
            .When(p => p.DiscountPercentage.HasValue)
            .WithMessage("Discount percentage must be between 0 and 100");

        // Stock
        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative");

        // Relations
        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Category is required");

        RuleFor(p => p.BrandId)
            .GreaterThan(0).WithMessage("Brand is required");
    }
}