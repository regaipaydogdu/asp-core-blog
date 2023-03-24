using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator :AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık Boş Olamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik Boş Olamaz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Resim Boş Olamaz");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Başlık 100 karakterden fazla Olamaz");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Başlık 4 karakterden az  Olamaz");

        
        }
    }
}
