using FluentValidation;

namespace SPROUTEXAM.Application.Employee.Commands.Create
{
  public class CommandValidator : AbstractValidator<Command>
  {
    public CommandValidator()
    {
      RuleFor(t => t.FullName).NotEmpty();
      RuleFor(t => t.Tin).NotEmpty();
      RuleFor(t => t.Birthdate).NotEmpty();
      RuleFor(t => t.Type).NotNull();
    }
  }
}