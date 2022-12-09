using FluentValidation;

namespace SPROUTEXAM.Application.Employee.Commands.Delete
{
  public class CommandValidator : AbstractValidator<Command>
  {
    public CommandValidator()
    {
      RuleFor(t => t.Id).NotNull();
    }
  }
}