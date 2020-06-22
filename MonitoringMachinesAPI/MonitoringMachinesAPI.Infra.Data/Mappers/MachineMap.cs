using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonitoringMachinesAPI.Domain.Models;

namespace MonitoringMachinesAPI.Infra.Data.Mappers
{
    public class MachineMap : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Antivirus)
                .WithOne(m => m.Machine)
                .HasForeignKey<Antivirus>(m => m.MachineId);
        }
    }
}
