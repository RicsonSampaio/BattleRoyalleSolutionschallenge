using System;
using Microsoft.AspNetCore.Mvc;
using MonitoringMachinesAPI.Domain.Interfaces;
using Serilog;

namespace MonitoringMachinesAPI.Controllers
{
    [Route("monitoring-machines")]
    [ApiController]
    public partial class MonitoringMachinesController : ControllerBase
    {
        private readonly IMachineService _machineService;
        private readonly IRegisterService _registerService;
        public MonitoringMachinesController(IRegisterService registerService, IMachineService machineService)
        {
            _registerService = registerService;
            _machineService = machineService;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAllMachines() 
        {
            try
            {
                var response = _machineService.GetAllMachines();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Information($"GetAllMachines Exception {ex.Message} {ex.InnerException.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("toggleMachine/{machineId}")]
        public IActionResult ToggleMachine(int machineId)
        {
            try
            {
                _machineService.ToggleMachine(machineId);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Information($"toggleMachine Exception {ex.Message} {ex.InnerException.Message}");
                return BadRequest();
            }        
        }
    }
}