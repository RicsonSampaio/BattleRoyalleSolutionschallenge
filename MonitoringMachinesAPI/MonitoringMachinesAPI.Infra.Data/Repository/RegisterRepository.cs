using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using MonitoringMachinesAPI.Infra.Data.Context;
using Serilog;
using System;
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

            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                HardDrives.Add(HardDrive.Create(drive.Name, drive.TotalFreeSpace, drive.TotalSize));
            }

            return HardDrives;
        }

        public Machine RegisterLocalMachine()
        {
            try
            {
                var machineName = GetMachineName();
                var machine = _context.Machines.FirstOrDefault(m => m.Name == machineName);
                if (machine == null)
                {
                    var localMachine = Machine.Create(GetMachineName(), GetIpAddress(), GetAntivirus(), GetOSVersion(), GetRuntimeInstalledVersion(), true, GetHardDrives());
                    var response = _context.Machines.Add(localMachine);
                    _context.SaveChanges();
                    Log.Information($"Local Machine created: Id: {response.Entity.Id} Name: {response.Entity.Name}");
                    return response.Entity;
                }
                else
                {
                    return Machine.DefaultEntity();
                }
            }
            catch (Exception ex)
            {
                Log.Information($"RegisterLocalMachine Repository Exception {ex.Message} {ex.InnerException.Message}");
                throw;
            }
        }

        public Machine RegisterNewMachine()
        {
            try
            {
                var HardDrives = new List<HardDrive>();
                HardDrives.Add(HardDrive.Create("C:/", 1000000, 10000000));
                HardDrives.Add(HardDrive.Create("E:/", 1000000, 10000000));

                var randomMachine = Machine.Create("Random-Machine-Name", "192.0.2.235", Antivirus.Create("Avast-XPTO", false), GetOSVersion(), GetRuntimeInstalledVersion(), true, HardDrives);
                var response = _context.Machines.Add(randomMachine);
                _context.SaveChanges();
                Log.Information($"Machine created: Id: {response.Entity.Id} Name: {response.Entity.Name}");
                return response.Entity;
            }
            catch (Exception ex)
            {
                Log.Information($"RegisterNewMachine Repository Exception {ex.Message} {ex.InnerException.Message}");
                throw;
            }
        }

        public Machine DeleteMachineRegistered(int machineId)
        {
            try
            {
                var machine = _context.Machines.FirstOrDefault(m => m.Id == machineId);
                if (machine != null)
                {
                    _context.Machines.Remove(machine);
                    _context.SaveChanges();
                    Log.Information($"Deleted Machine: Id: {machine.Id} Name: {machine.Name}");
                    return machine;
                }
                else
                {
                    return Machine.DefaultEntity();
                }
            }
            catch (Exception ex)
            {
                Log.Information($"DeleteMachineRegistered Repository Exception {ex.Message} {ex.InnerException.Message}");
                throw;
            } 
        }
    }
}
