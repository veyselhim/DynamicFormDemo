using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Entity.Concrete;
using FluentValidation;

namespace DynamicFormDemo.Business.Utilities.Validation.FluentValidation
{
    public class FormValidator : AbstractValidator<Form>
    {
        public FormValidator()
        {
            RuleFor(f => f.Name).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(f => f.Description).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(f => f.CreatedBy).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}
