using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPROUTEXAM.Application;
using SPROUTEXAM.Application.Employee.Models;
using EmployeeCommand = SPROUTEXAM.Application.Employee.Commands;
using EmployeeQuery = SPROUTEXAM.Application.Employee.Queries;

namespace SPROUTEXAM.Controllers
{
  [Route("api/employee")]
  public class EmployeeController : BaseController
  {
    [HttpGet()]
    [Description("Get all employees, response employees json")]
    [ProducesResponseType(typeof(List<EmployeeModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllEmployees([FromBody] EmployeeQuery.GetAllEmployees.Query query)
    {
      var result = await Mediator.Send(query);

      if (result is BadRequestResponse)
        return BadRequest(result.Message);

      var data = ((SuccessResponse<List<EmployeeModel>>)result).Data;
      return Ok(data);
    }

    [HttpPost()]
    [Description("Create employee based on json body")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create([FromBody] EmployeeCommand.Create.Command command)
    {
      var result = await Mediator.Send(command);

      if (result is BadRequestResponse)
        return BadRequest(result.Message);

      var data = ((SuccessResponse<bool>)result).Data;
      return Created("", data);
    }

    [HttpPut()]
    [Description("Update employee based on json body")]
    [ProducesResponseType(typeof(EmployeeModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update([FromBody] EmployeeCommand.Update.Command command)
    {
      var result = await Mediator.Send(command);

      if (result is BadRequestResponse)
        return BadRequest(result.Message);

      var data = ((SuccessResponse<bool>)result).Data;
      return Ok(data);
    }

    [HttpDelete()]
    [Description("Delete employee based on id")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromQuery] EmployeeCommand.Delete.Command command)
    {
      var result = await Mediator.Send(command);

      if (result is BadRequestResponse)
        return BadRequest(result.Message);

      var data = ((SuccessResponse<bool>)result).Data;
      return Ok(data);
    }
  }
}