using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
          //  RuleFor(c => c.ImagePath).NotEmpty().WithMessage("dosya yolu nerede ");
            RuleFor(c => c.CarId).NotEmpty().WithMessage("car id olmak zorunda");
        //    RuleFor(p => p.Description).Must(StartWithA).WithMessage("Ürün harfi a ile baslamalıdır");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
