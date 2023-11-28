using AutoMapper;
using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Domain.Entities;
using MediatR;
using SaudiStore.Application.Features.Products.Commands.DeleteProduct;
using OpenQA.Selenium;

namespace SaudiStore.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        
        public DeleteProductCommandHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.ProductId);

            if (productToDelete == null)
            {
                throw new NotFoundException(nameof(Product));
            }

            await _productRepository.DeleteAsync(productToDelete);

            return Unit.Value;
        }
    }
}
