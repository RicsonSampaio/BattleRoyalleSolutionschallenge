using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringMachinesAPI.Domain.Models
{
    public class Antivirus
    {
        public Antivirus(string name, bool hasAntivirus)
        {
            Name = name;
            HasAntivirus = hasAntivirus;
        }

        public static Antivirus Create(string Name, bool HasAntivirus)
        {
            return new Antivirus(Name, HasAntivirus);
        }

        public int Id { get; set; }
        public bool HasAntivirus { get; set; }
        public string Name { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

    }
}
