using Microsoft.EntityFrameworkCore;
using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using MonitoringMachinesAPI.Infra.Data.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;

namespace MonitoringMachinesAPI.Infra.Data.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly DataContext _context;
        public RegisterRepository(DataContext context)
        {
            _context = context; 
        }

        private string GetMachineName() => Environment.MachineName;
        private string GetIpAddress()
        {
            var hostName = Dns.GetHostName();
            var hostAddresses = Dns.GetHostAddresses(hostName);

            if (hostAddresses.Any(x => x.AddressFamily == AddressFamily.InterNetwork))
            {
                return hostAddresses.Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
            }
            else
            {
                return "000.0.0.0";  
            }
        }
        private Antivirus GetAntivirus()
        {
            var objectCollection = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct").Get();
            var antivirusName = "";

            foreach (ManagementObject virusChecker in objectCollection)
            {
                antivirusName += virusChecker["displayName"].ToString() + " ";
            }

            return Antivirus.Create(antivirusName, (objectCollection.Count > 0));
        }
        private string GetOSVersion() => Environment.OSVersion.VersionString;
        private string GetRuntimeInstalledVersion()
        {
            return $"{AppContext.TargetFrameworkName.Split(',')[0]} {Environment.Version}";
        }

        private ICollection<HardDrive> GetHardDrives()
        {
            var HardDrives = new List<HardDrive>();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                HardDrives.Add(HardDrive.Create(drive.Name, drive.TotalFreeSpace, drive.TotalSize));
            }

            return HardDrives;
        }

        public Machine RegisterLocalMachine()
        {
            var machineName = GetMachineName();
            var machine = _context.Machines.FirstOrDefault(m => m.Name == machineName);
            if (machine == null)
            {
                var localMachine = Machine.Create(GetMachineName(), GetIpAddress(), GetAntivirus(), GetOSVersion(), GetRuntimeInstalledVersion(), true, GetHardDrives());
                var response = _context.Machines.Add(localMachine);
                _context.SaveChanges();
                return response.Entity;
            }
            else
            {
                return Machine.DefaultEntity();
            }
        }

        public Machine RegisterNewMachine()
        {
            var HardDrives = new List<HardDrive>();
            HardDrives.Add(HardDrive.Create("randomDriveName1", 100000, 1000000));
            HardDrives.Add(HardDrive.Create("randomDriveName2", 100000, 1000000));

            var randomMachine = Machine.Create("RandomMachineName","xxx.x.x.x", Antivirus.Create("AvastXPTO", false), GetOSVersion(), GetRuntimeInstalledVersion(), true , HardDrives);
            var response = _context.Machines.Add(randomMachine);
            _context.SaveChanges();
            return response.Entity;
        }

        public Machine DeleteMachineRegistered(int machineId)
        {
            var machine = _context.Machines.FirstOrDefault(m => m.Id == machineId);
            if (machine != null)
            {
                _context.Machines.Remove(machine);
                _context.SaveChanges();
                return machine;
            }
            else
            {
                return Machine.DefaultEntity();
            }
        }
    }
}
