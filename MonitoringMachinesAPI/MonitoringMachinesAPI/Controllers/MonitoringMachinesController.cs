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
            Log.Information("MonitoringMachinesController construtor");
            _registerService = registerService;
            _machineService = machineService;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAllMachines() 
        {
            Log.Information("GetAllMachines");
            var response = _machineService.GetAllMachines();

            if (response == null)
            {
                return BadRequest("Error. Check what you're sending");
            }

            return Ok(response);
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
                return BadRequest("Error " + ex);
            }            
        }
    }
}