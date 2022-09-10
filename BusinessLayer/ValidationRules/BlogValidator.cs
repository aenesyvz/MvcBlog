using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik boş geçilemez!");
            RuleFor(x => x.BlogContent).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik içerik giriniz!");
            RuleFor(x => x.BlogContent).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakterlik içerik giriniz!");
        }
    }
}
