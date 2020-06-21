using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringMachinesAPI.Domain.Models
{
    public class HardDrive
    {
        public HardDrive(string name, long freeSpace, long usedSpace)
        {
            Name = name;
            FreeSpace = BitesToString(freeSpace);
            UsedSpace = BitesToString(usedSpace);
        }
        protected HardDrive(){}

        public static HardDrive Create(string Name, long FreeSpace, long UsedSpace)
        {
            return new HardDrive(Name, FreeSpace, UsedSpace);
        }

        private string BitesToString(long bytes)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double doubleBytes = bytes;
            for (i = 0; i < suf.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                doubleBytes = bytes / 1024;
            }

            return String.Format("{0:0.##} {1}", doubleBytes, suf[i]);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FreeSpace { get; set; }
        public string UsedSpace { get; set; }
        public Machine Machine { get; set; }
        public int MachineId { get; set; }
    }
}
