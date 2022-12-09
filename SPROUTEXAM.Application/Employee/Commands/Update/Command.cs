using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Application.Employee.Models;
using SPROUTEXAM.Domain.Enums;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Application.Employee.Commands.Update
{
  public class Command : IRequest<Response>
  {
    public int Id { get; set; }
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
        var employee = await dbContext.Employees
          .Where(t => t.Id == request.Id)
          .FirstOrDefaultAsync();

        if (employee == null)
          return new BadRequestResponse("Employee not found!");

        employee.FullName = request.FullName;
        employee.Birthdate = request.Birthdate;
        employee.Tin = request.Tin;
        employee.Type = request.Type;
        await dbContext.SaveChangesAsync();

        return new SuccessResponse<EmployeeModel>(
          mapper.Map<EmployeeModel>(employee)
        );
      }

      catch (Exception error)
      {
        return new BadRequestResponse(error.GetBaseException().Message);
      }
    }
  }
}