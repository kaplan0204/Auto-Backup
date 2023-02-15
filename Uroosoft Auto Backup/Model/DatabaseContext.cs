using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Uroosoft_Auto_Backup.Model
{
    internal class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=" + AppContext.BaseDirectory + @"\Data.db", options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            //modelBuilder.Entity<Tbl_Process>().ToTable();
            modelBuilder.Entity<Tbl_Process>(entity =>
            {
                entity.HasKey(e => e.ProcessID);
                //entity.HasIndex(e => e.ProcessID).IsUnique();
                entity.Property(e => e.ProcessDestationPath).HasDefaultValue("");
                entity.Property(e => e.ProcessSourcePath).HasDefaultValue("");
                entity.Property(e => e.ProcessStatus).HasDefaultValue(0);
                entity.Property(e => e.ProcessType).HasDefaultValue(0);
                entity.Property(e => e.ProcessRunnigStartDate);
                entity.Property(e => e.ProcessRunnigLastDate);
            });
            //base.OnModelCreating(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Tbl_Process> Process { get; set; }
    }
}
