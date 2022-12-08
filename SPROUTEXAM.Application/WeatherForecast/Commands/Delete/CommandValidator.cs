using FluentValidation;

namespace SPROUTEXAM.Application.WeatherForecast.Commands.Delete
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
        }
    }
}