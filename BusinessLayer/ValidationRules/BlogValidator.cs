using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını Boş Geçemezsiniz!!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriğini Boş Geçemezsiniz!!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Görsel Alanı Boş Geçilemez!!");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapın!!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen en fazla 150 karakter girişi yapın!!");
        }
    }
}
