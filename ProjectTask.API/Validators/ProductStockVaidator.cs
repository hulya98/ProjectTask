using FluentValidation;
using ProjectTask.Domains.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTask.API.Validators
{
    public class ProductStockVaidator : AbstractValidator<ProductStockDto>
    {
        public ProductStockVaidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Please, Enter Product");
        }
    }
}
