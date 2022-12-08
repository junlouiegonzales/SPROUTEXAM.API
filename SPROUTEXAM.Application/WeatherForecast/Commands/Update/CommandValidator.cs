using FluentValidation;

namespace SPROUTEXAM.Application.WeatherForecast.Commands.Update
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Type).NotEmpty();
            RuleFor(t => t.Temperature).NotEmpty();
            RuleFor(t => t.Wind).NotEmpty();
            RuleFor(t => t.Precipitation).NotEmpty();
        }
    }
}