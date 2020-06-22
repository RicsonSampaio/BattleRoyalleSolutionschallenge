using MonitoringMachinesAPI.Domain.Interfaces;
using MonitoringMachinesAPI.Domain.Interfaces.Repositories;
using MonitoringMachinesAPI.Domain.Models;

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
            return _registerRepository.RegisterLocalMachine();
        }

        public Machine RegisterNewMachine()
        {
            return _registerRepository.RegisterNewMachine();
        }
    }
}
