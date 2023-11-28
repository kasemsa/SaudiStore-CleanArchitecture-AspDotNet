﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand:IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name}; Price: {Price}; " +
                $"By: {CompanyName}; Description: {Description}";
        }
    }
}
