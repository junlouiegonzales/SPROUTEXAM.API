using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPROUTEXAM.Application;
using WeatherForecastCommand = SPROUTEXAM.Application.WeatherForecast.Commands;

namespace SPROUTEXAM.Api.Controllers
{
    [Route("api/weatherforecast")]
    public class WeatherForecastController : BaseController
    {
        [HttpPost()]
        [Description("Create weather forecast based on json body")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] WeatherForecastCommand.Create.Command command)
        {
            var result = await Mediator.Send(command);
            
            if (result is BadRequestResponse)
                return BadRequest(result.Message);

            var data = ((SuccessResponse<bool>)result).Data;
            return Created("", data);
        }

        [HttpPut()]
        [Description("Update weather forecast based on json body")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] WeatherForecastCommand.Update.Command command)
        {
            var result = await Mediator.Send(command);
            
            if (result is BadRequestResponse)
                return BadRequest(result.Message);

            var data = ((SuccessResponse<bool>)result).Data;
            return Ok(data);
        }

        [HttpDelete()]
        [Description("Delete weather forecast based on id")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteWeatherForecast([FromQuery] WeatherForecastCommand.Delete.Command command)
        {
            var result = await Mediator.Send(command);
            
            if (result is BadRequestResponse)
                return BadRequest(result.Message);

            var data = ((SuccessResponse<bool>)result).Data;
            return Ok(data);
        }
    }
}
