using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(r => r.CategoryName).NotEmpty().WithMessage("Categori boş geçilemez");
            RuleFor(r => r.CategoryName).MaximumLength(35).WithMessage("max 35 karakteri geçemez");
        }
    }
}
