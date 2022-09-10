using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş geçilemez!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez!");
            RuleFor(x => x.SurnameName).NotEmpty().WithMessage("Soyad boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Yazar hakkında boş geçilemez!");

        }
    }
}
