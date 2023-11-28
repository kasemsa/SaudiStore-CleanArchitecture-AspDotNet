using FluentValidation;
using SaudiStore.Application.Contracts.Persistence;


namespace SaudiStore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommoandValidator:AbstractValidator<UpdateProductCommand>
    {
        
        public UpdateProductCommoandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

        }
     
    }
}
