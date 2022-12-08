using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Domain.Enums;
using SPROUTEXAM.Infrastructure.Context;

namespace SPROUTEXAM.Application.WeatherForecast.Commands.Update
{
    public class Command : IRequest<Response>
    {
        public int Id { get; set; }
        public WeatherType Type { get; set; }
        public int Temperature { get; set; }
        public string Wind { get; set; }
        public string Precipitation { get; set; }
    }

    public class CommandHandler : IRequestHandler<Command, Response>
    {
        private readonly NetCoreDbContext dbContext;
        private readonly IMapper mapper;

        public CommandHandler(NetCoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var item = await dbContext.Weathers
                .Where(t => t.Id == request.Id)
                .FirstOrDefaultAsync();

            if(item == null)
                return new NotFoundResponse($"The Item with the primary key of {request.Id} not found.");

            item.Type = request.Type;
            item.Temperature = request.Temperature;
            item.Wind = request.Wind;
            item.Precipitation = request.Precipitation;

            await dbContext.SaveChangesAsync();
            return new SuccessResponse<bool>(true);
        }
    }
}