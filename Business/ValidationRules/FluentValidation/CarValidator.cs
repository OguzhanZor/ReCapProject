using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.ModelYear).NotEmpty();
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(p => p.Description).Must(StartWithA).WithMessage("Ürün harfi a ile baslamalıdır");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
