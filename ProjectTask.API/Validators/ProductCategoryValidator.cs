using FluentValidation;
using ProjectTask.Domains.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTask.API.Validators
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategoryDto>
    {
        public ProductCategoryValidator()
        {
            RuleFor(x => x.ProductCategoryName).NotEmpty().WithMessage("Please, Enter Category Name");
        }
    }
}
