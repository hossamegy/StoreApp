using FluentValidation;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.validators;

public class BrandValidator : AbstractValidator<Brands>
{
    public BrandValidator()
    {
        // Name
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(150).WithMessage("Category name must not exceed 50 characters");

           }
}