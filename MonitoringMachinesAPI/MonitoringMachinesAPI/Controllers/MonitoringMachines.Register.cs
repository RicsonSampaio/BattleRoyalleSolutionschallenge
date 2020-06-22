using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace MonitoringMachinesAPI.Controllers
{
    public partial class MonitoringMachinesController
    {
        [HttpPost]
        [Route("registerLocalMachine")]
        public IActionResult RegisterLocalMachine()
        {
            try
            {
                var response = _registerService.RegisterLocalMachine();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Information($"registerLocalMachine Exception {ex.Message} {ex.InnerException.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("registerNewMachine")]
        public IActionResult RegisterNewMachine()  
        {
            try
            {
                var response = _registerService.RegisterNewMachine();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Information($"RegisterNewMachine Exception {ex.Message} {ex.InnerException.Message}");
                return BadRequest();
            }  
        }

        [HttpPost]
        [Route("DeleteMachineRegistered/{machineId}")]
        public IActionResult DeleteMachineRegistered(int machineId) 
        {
            try
            {
                var response = _registerService.DeleteMachineRegistered(machineId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Information($"DeleteMachineRegistered Exception {ex.Message} {ex.InnerException.Message}");
                return BadRequest();
            }
        }
    }
}
