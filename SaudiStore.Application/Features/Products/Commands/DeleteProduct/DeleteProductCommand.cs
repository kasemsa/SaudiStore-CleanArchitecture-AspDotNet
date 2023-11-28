﻿using MediatR;

namespace SaudiStore.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest
    {
        public Guid ProductId { get; set; }
    }
}
