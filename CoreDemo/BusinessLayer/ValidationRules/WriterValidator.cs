using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator() 
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yaz adı soyadı boş olamaz.");

            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş olamaz.");

            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Parola boş olamaz.");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("En az üç karakter girin.");
            RuleFor(x => x.WriterName).MaximumLength(30).WithMessage("En fazla 30 karakter girin.");

        }
    }
}
