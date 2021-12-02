﻿using MediatR;
using ProductMS.Application.DtoModels;

namespace ProductMS.Application.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public ProductDto ProductDto;

        public CreateProductCommand(ProductDto productDto)
        {
            ProductDto = productDto;
        }
    }
}
