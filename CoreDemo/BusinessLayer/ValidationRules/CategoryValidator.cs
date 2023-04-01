using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı Minimum 3 Karakter Olmalıdır.");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Kategori Adı Maksimum 50 Karakter Olmalıdır.");

        }
    }
}
