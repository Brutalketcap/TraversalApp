using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyin");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lüften en az 5 karakter veri giriniz");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Lüften en az 20 karakter veri giriniz");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lüften en az 50 karakter veri giriniz");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lüften en az 500 karakter veri giriniz");
        }
    }
    {
    }
}
