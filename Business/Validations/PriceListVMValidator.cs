using Core.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class PriceListVMValidator:AbstractValidator<PriceListVM>
    {
        public PriceListVMValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required"); 
            RuleFor(x => x.Discount).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Discount).InclusiveBetween(1, 100).WithMessage("{PropertyName} must be between 1 and 100");
        }
    }
}
