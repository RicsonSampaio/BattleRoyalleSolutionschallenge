using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringMachinesAPI.Domain.Interfaces;
using MonitoringMachinesAPI.Domain.Models;

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
        // lembrar de validar se a maquina ta ligada 
        public IActionResult ExecuteCommand(Command command) 
        {
            var response = _commandService.ExecuteCommand(command);

            if (response == null)
            {
                return BadRequest("Error. Check what you're sending");
            }

            return Ok(response);
        }
    }
}