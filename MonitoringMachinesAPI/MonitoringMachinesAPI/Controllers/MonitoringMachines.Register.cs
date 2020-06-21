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
            var response = _registerService.RegisterLocalMachine();

            if (response == null)
            {
                return BadRequest("Error.");
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("registerNewMachine")]
        public IActionResult RegisterNewMachine()  
        {
            Log.Information("RegisterNewMachine");

            try
            {
                var response = _registerService.RegisterNewMachine();

                if (response == null)
                {
                    return BadRequest("Error. Check what you're sending");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Information("RegisterNewMachine Exception " + ex.Message + " " + ex.InnerException.Message);
                throw;
            }
           
        }

        [HttpPost]
        [Route("DeleteMachineRegistered/{machineId}")]
        public IActionResult DeleteMachineRegistered(int machineId) 
        {
            var response = _registerService.DeleteMachineRegistered(machineId);

            if (response == null)
            {
                return BadRequest("Error. Check what you're sending");
            }

            return Ok(response);
        }
    }
}
