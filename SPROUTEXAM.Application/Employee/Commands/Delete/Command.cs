using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Application.Employee.Commands.Delete
{
  public class Command : IRequest<Response>
  {
    public int Id { get; set; }
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

        dbContext.Employees.Remove(employee);
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