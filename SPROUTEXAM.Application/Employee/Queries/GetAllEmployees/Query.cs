using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Application.Employee.Models;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Application.Employee.Queries.GetAllEmployees
{
  public class Query : IRequest<Response>
  {
  }

  public class QueryHandler : IRequestHandler<Query, Response>
  {
    private readonly SproutExamDbContext dbContext;
    private readonly IMapper mapper;

    public QueryHandler(SproutExamDbContext dbContext, IMapper mapper)
    {
      this.dbContext = dbContext;
      this.mapper = mapper;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
      try
      {
        var employees = await dbContext.Employees.Where(t => true).ToListAsync();
        return new SuccessResponse<List<EmployeeModel>>(
          employees.Select(t => mapper.Map<EmployeeModel>(t)).ToList()
        );
      }
      catch (Exception error)
      {
        return new BadRequestResponse(error.GetBaseException().Message);
      }
    }
  }
}