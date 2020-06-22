using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonitoringMachinesAPI.Domain.Models;

namespace MonitoringMachinesAPI.Infra.Data.Mappers
{
    public class HardDriveMap : IEntityTypeConfiguration<HardDrive>
    {
        public void Configure(EntityTypeBuilder<HardDrive> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Machine)
                .WithMany(d => d.HardDrive)
                .HasForeignKey(f => f.MachineId);
        }
    }
}
