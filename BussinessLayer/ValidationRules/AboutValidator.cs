using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");

            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen gösresl seçiniz...!");

            RuleFor(x=> x.Description).MinimumLength(50).WithMessage("Açıklama alanı en az 50 karakter olmalıdır");

            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Lütfen açıklamayı kısaltın..!");


        }
    }
}
