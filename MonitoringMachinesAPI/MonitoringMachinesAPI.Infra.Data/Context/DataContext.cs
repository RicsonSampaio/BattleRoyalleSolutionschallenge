using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MonitoringMachinesAPI.Domain.Models;
using System;
using MonitoringMachinesAPI.Infra.Data.Mappers;

namespace MonitoringMachinesAPI.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Antivirus> Antivirus { get; set; }
        public DbSet<HardDrive> HardDrive { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            optionsBuilder.UseSqlite(config["DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MachineMap());
            modelBuilder.ApplyConfiguration(new HardDriveMap());
            modelBuilder.ApplyConfiguration(new AntivirusMap());
        }
    }
}
