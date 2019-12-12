using System;
using Flowsoft.Domain.Models;
using Flowsoft.Hms.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flowsoft.Data
{
    public partial class EcomContext : DbContext, IDataContext
    {
        public virtual DbSet<AdmissionTypes> AdmissionTypes { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<PatientAdmission> PatientAdmission { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Opds> Opds { get; set; }

        public EcomContext(DbContextOptions<EcomContext> options)
       : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmissionTypes>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmergencyNumber).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.StateId).HasColumnName("StateID");
                ;
            });

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<PatientAdmission>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Admission)
                    .WithMany(p => p.PatientAdmission)
                    .HasForeignKey(d => d.AdmissionId)
                    .HasConstraintName("FK_PatientAdmission_AdmissionType");

                entity.HasOne(d => d.PatientAdmision)
                    .WithMany(p => p.InversePatientAdmision)
                    .HasForeignKey(d => d.PatientAdmisionId)
                    .HasConstraintName("FK_PatientAdmission_PatientAdmission");

            });

            modelBuilder.Entity<Patients>(entity =>
            {

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.AdhaarCard).HasMaxLength(20);

                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.EmergencyNumber).HasMaxLength(20);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.VoterCard).HasMaxLength(50);


            });

            modelBuilder.Entity<ProductCategories>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                   .WithMany(p => p.Users)
                   .HasForeignKey(d => d.RoleId)
                   .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);
            });
            modelBuilder.Entity<Opds>(entity =>
            {
                entity.Property(e => e.OpdNotes).HasMaxLength(5000);
            });
        }

        void IDataContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
