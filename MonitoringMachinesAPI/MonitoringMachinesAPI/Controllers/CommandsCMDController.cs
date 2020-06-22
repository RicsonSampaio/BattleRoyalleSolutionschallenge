using System;
using Microsoft.AspNetCore.Mvc;
using MonitoringMachinesAPI.Domain.Interfaces;
using MonitoringMachinesAPI.Domain.Models;
using Serilog;

namespace MonitoringMachinesAPI.Controllers
{
    [Produces("application/json")]
    [Route("")]
    public class CommandsCMDController : ControllerBase
    {
        private readonly ICommandService _commandService;
        public CommandsCMDController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        [Route("command-cmd")]
        // TODO lembrar de validar se a maquina ta ligada 
        public IActionResult ExecuteCommand(Command command) 
        {
            try
            {
                var response = _commandService.ExecuteCommand(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Information($"ExecuteCommand Exception {ex.Message} {ex.InnerException.Message}");
                return BadRequest();
            }
        }
    }
}