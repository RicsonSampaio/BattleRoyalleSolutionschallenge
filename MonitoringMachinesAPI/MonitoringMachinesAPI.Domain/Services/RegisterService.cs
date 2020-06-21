using MonitoringMachinesAPI.Domain.Interfaces;
using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MonitoringMachinesAPI.Domain.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public Machine DeleteMachineRegistered(int machineId)
        {
            return _registerRepository.DeleteMachineRegistered(machineId);
        }

        public Machine RegisterLocalMachine()
        {
            // verificar se ja nao tem la
            return _registerRepository.RegisterLocalMachine();
        }

        public Machine RegisterNewMachine()
        {
            return _registerRepository.RegisterNewMachine();
        }
    }
}
