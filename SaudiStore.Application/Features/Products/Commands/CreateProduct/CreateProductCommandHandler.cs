using AutoMapper;
using MediatR;
using SaudiStore.Application.Contracts.Infrastructure;
using SaudiStore.Application.Contracts.Persistence;
using SaudiStore.Application.Models.Mail;
using SaudiStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IEmailService _emailService;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository,IEmailService emailService)
        { 
            _mapper = mapper;
            _productRepository = productRepository;
            _emailService = emailService;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var @product =_mapper.Map<Product>(request);

            var validator = new UpdateProductCommoandValidator(_productRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validatorResult);
            }

            @product = await _productRepository.AddAsync(@product);

            var email = new Email()
            {
                To = "saudikasem@gmail.com",
                body = $"a new Product was Created :{request}",
                subject = " a new Product was Created",
            };
            try { 
                await _emailService.SendEmail(email);
            }
               catch (Exception ex)
            {


            }

            return @product.ProductId;
        }
    }
}
