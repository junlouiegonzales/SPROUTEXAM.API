using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SPROUTEXAM.Application.UserAccount.Models;

namespace SPROUTEXAM.Application.UserAccount.Queries.GetByUserId
{
  public class Query : IRequest<Models.UserAccountModel>
  {
    public string Id { get; set; }
  }

  public class QueryHandler : IRequestHandler<Query, Models.UserAccountModel>
  {
    private readonly UserManager<Domain.Entities.UserAccount> userManager;
    private readonly IMapper mapper;

    public QueryHandler(UserManager<Domain.Entities.UserAccount> userManager, IMapper mapper)
    {
      this.userManager = userManager;
    }

    public async Task<UserAccountModel> Handle(Query request, CancellationToken cancellationToken)
    {
       var result = await userManager.FindByIdAsync(request.Id); 
       return result == null 
          ? null 
          : mapper.Map<Models.UserAccountModel>(result);
    }
  }
}