using FluentValidation;
using ProjectTask.Domains.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTask.API.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Please, Enter Product Name")
                .MinimumLength(3).WithMessage("Product Name length greater than 3");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Please, Enter Price")
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.ProductCategoryId).NotEmpty().WithMessage("Please, Enter Category");

            RuleFor(x => x.State).NotEmpty().WithMessage("Please, Enter State");

        }
    }
}

