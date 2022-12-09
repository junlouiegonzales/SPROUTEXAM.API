using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SPROUTEXAM.Domain.Enums;
using SPROUTEXAM.Infrastructure.Context;
using EmployeeEntity = SPROUTEXAM.Domain.Entities.Employee;

namespace SPROUTEXAM.Application.Employee.Commands.Create
{
  public class Command : IRequest<Response>
  {
    public string FullName { get; set; }
    public string Tin { get; set; }
    public DateTime Birthdate { get; set; }
    public EmployeeType Type { get; set; }
  }

  public class CommandHandler : IRequestHandler<Command, Response>
  {
    private readonly SproutExamDbContext dbContext;
    private readonly IMapper mapper;

    public CommandHandler(SproutExamDbContext dbContext, IMapper mapper)
    {
      this.dbContext = dbContext;
      this.mapper = mapper;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
      try
      {
        var newItem = mapper.Map<EmployeeEntity>(request);
        dbContext.Employees.Add(newItem);
        await dbContext.SaveChangesAsync();
        return new SuccessResponse<bool>(true);
      }
      catch (Exception error)
      {
        return new BadRequestResponse(error.GetBaseException().Message);
      }
    }
  }
}