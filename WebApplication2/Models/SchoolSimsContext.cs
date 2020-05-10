using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class SchoolSimsContext : DbContext
    {
        public SchoolSimsContext()
        {
        }

        public SchoolSimsContext(DbContextOptions<SchoolSimsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:schoolsims.database.windows.net,1433;Initial Catalog=SchoolSims;Persist Security Info=False;User ID=rrohitx;Password=Krish@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.EmployeName).HasMaxLength(50);
            });
        }
    }
}
