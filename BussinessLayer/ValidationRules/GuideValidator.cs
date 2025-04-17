
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x =>x.Name).NotEmpty().WithMessage("Lüfren rehber adını giriniz");
            RuleFor(x =>x.Description).NotEmpty().WithMessage("Lüfren rehber açıklamasını girin");
            RuleFor(x =>x.Image).NotEmpty().WithMessage("Lüfren rehber resim ekliyin");
            RuleFor(x =>x.Name).MaximumLength(30).WithMessage("Lüfren en 30 karakterden daha kısa isim giriniz");
            RuleFor(x =>x.Name).MinimumLength(6).WithMessage("Lüfren  6 karakterden daha uzun isim giriniz");
        }
    }
}
