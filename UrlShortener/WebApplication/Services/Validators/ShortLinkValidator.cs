using FluentValidation;
using WebApplication.Models;

namespace WebApplication.Services.Validators
{
    public class ShortLinkValidator : AbstractValidator<ShortLink>
    {
        public ShortLinkValidator()
        {
            RuleFor(x => x.OriginalUrl)
                .NotEmpty().WithMessage("Оригинальный URL не может быть пустым.")
                .Must(BeAValidUrl).WithMessage("Некорректный URL.");

            RuleFor(x => x.ShortUrl)
                .NotEmpty().WithMessage("Сокращенный URL не может быть пустым.")
                .MaximumLength(50).WithMessage("Сокращенный URL слишком длинный.");

            RuleFor(x => x.ClickCount)
                .GreaterThanOrEqualTo(0).WithMessage("Количество кликов не может быть отрицательным.");
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
