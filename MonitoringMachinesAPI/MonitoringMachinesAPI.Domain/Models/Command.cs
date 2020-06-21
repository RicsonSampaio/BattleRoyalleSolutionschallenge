using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringMachinesAPI.Domain.Models
{
    public class Command
    {
        public string CMDCommand { get; set; }
        public int MachineId { get; set; }
    }
}
