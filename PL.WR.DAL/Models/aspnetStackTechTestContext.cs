using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace PL.WR.DAL.Models
{
    public partial class aspnetStackTechTestContext : DbContext
    {
        private IConfiguration _config;
        public aspnetStackTechTestContext(IConfiguration config)
        {
            _config = config;
        }

        public aspnetStackTechTestContext(DbContextOptions<aspnetStackTechTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WeatherRecord> WeatherRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            

            modelBuilder.Entity<WeatherRecord>(entity =>
            {
                entity.ToTable("WeatherRecord");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
