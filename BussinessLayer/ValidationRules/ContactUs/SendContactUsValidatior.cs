using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidatior : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidatior()
        {
            RuleFor(x=> x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(x=> x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez.");
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Isim alanı boş geçilemez.");
            RuleFor(x=> x.MessageBody).NotEmpty().WithMessage("Messagealanı boş geçilemez.");
            RuleFor(x=> x.Subject).MinimumLength(5).WithMessage("Messaj alanı en az 5 karakter olmalı.");
            RuleFor(x=> x.Subject).MaximumLength(508).WithMessage("Messaj alanı en fazla 580 karakter olmalı.");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Messaj alanı en az 5 karakter olmalı.");
            RuleFor(x => x.Mail).MaximumLength(500).WithMessage("Messaj alanı en fazla 500 karakter olmalı.");
        }
    }
}
