using AutoMapper;
using SaudiStore.Application.Contracts.Persistence;
using OpenQA.Selenium;
using SaudiStore.Domain.Entities;
using MediatR;
using SaudiStore.Application.Features.Products.Commands.UpdateProduct;
using SaudiStore.Application.Exceptions;

namespace SaudiStore.Application.Features.Events.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (productToUpdate == null)
            {
                throw new OpenQA.Selenium.NotFoundException(nameof(Product));
            }

            var validator = new UpdateProductCommoandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(productToUpdate);

            return Unit.Value;
        }
    }
}