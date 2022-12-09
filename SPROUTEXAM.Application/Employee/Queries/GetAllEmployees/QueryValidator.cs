using FluentValidation;

namespace SPROUTEXAM.Application.Employee.Queries.GetAllEmployees
{
  public class QueryValidator : AbstractValidator<Query>
  {
    public QueryValidator()
    {
    }
  }
}