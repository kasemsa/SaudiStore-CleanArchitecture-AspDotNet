using FluentValidation;
using SaudiStore.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Products.Commands.CreateProduct
{
    public class UpdateProductCommoandValidator:AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommoandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("{ProoertyName} must not exceed 50 characters");

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("{ProoertyName} must not exceed 50 characters");

            RuleFor(p => p)
                .MustAsync(ProductNameAndCompanyNameUniqe)
                .WithMessage("An product with the same name and Company alrady exists");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{ProoertyName} is Required")
                .GreaterThan(0);
                
               
        }

        private async Task<bool> ProductNameAndCompanyNameUniqe(CreateProductCommand p,
            CancellationToken token)
        {
            return !(await _productRepository.IsProductNameAndCompanyNameUniqe(p.Name, p.CompanyName));
        }
    }
}
