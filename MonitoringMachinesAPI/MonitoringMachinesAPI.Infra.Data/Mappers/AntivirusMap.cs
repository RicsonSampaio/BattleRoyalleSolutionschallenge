using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonitoringMachinesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringMachinesAPI.Infra.Data.Mappers
{
    public class AntivirusMap : IEntityTypeConfiguration<Antivirus>
    {
        public void Configure(EntityTypeBuilder<Antivirus> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
