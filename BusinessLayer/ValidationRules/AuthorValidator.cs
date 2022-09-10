using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı boş geçilemez!");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar hakkında boş geçilemez!");
            
        }
    }
}
