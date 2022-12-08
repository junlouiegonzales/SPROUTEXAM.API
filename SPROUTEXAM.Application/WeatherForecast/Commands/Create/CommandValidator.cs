using FluentValidation;

namespace SPROUTEXAM.Application.WeatherForecast.Commands.Create
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(t => t.Type).NotNull();
            RuleFor(t => t.Temperature).NotNull();
            RuleFor(t => t.Wind).NotEmpty();
            RuleFor(t => t.Precipitation).NotEmpty();
        }
    }
}