using System.Collections.Generic;

namespace MonitoringMachinesAPI.Domain.Models
{
    public class Machine
    {
        public Machine(string name, string address, Antivirus antivirus, string osVersion, string dotNetVersion, bool isUp, ICollection<HardDrive> hardDrive)
        {
            Name = name;
            Address = address;
            Antivirus = antivirus;
            OsVersion = osVersion;
            DotNetVersion = dotNetVersion;
            IsUp = isUp;
            HardDrive = hardDrive;
        }
        protected Machine(){}

        public static Machine DefaultEntity()
        {
            return new Machine();
        }
        public static Machine Create(string Name, string Address, Antivirus Antivirus, string OsVersion, string DotNetVersion, bool isUp, ICollection<HardDrive> HardDrive)
        {
            return new Machine(Name, Address, Antivirus, OsVersion, DotNetVersion, isUp, HardDrive);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Antivirus Antivirus { get; set; }
        public string OsVersion { get; set; }
        public string DotNetVersion { get; set; }
        public bool IsUp { get; set; }
        public ICollection<HardDrive> HardDrive { get; set; }
    }
}
