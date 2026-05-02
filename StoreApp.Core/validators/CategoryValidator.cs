using FluentValidation;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.validators;

public class CategoryValidator : AbstractValidator<Categories>
{
    public CategoryValidator()
    {
        // Name
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(150).WithMessage("Category name must not exceed 50 characters");

           }
}