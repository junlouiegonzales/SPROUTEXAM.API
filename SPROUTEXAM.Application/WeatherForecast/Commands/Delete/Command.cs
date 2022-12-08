using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Application.WeatherForecast.Commands.Delete
{
    public class Command : IRequest<Response>
    {
        public int Id { get; set; }
    }

    public class CommandHandler : IRequestHandler<Command, Response>
    {
        private readonly NetCoreDbContext dbContext;

        public CommandHandler(NetCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var item = await dbContext.Weathers
                .Where(t => t.Id == request.Id)
                .FirstOrDefaultAsync();

            if(item == null)
                return new NotFoundResponse($"The Item with the primary key of {request.Id} not found.");

            dbContext.Weathers.Remove(item);
            await dbContext.SaveChangesAsync();
                
            return new SuccessResponse<bool>(true);
        }
    }
}