using System;
using System.Collections.Generic;
using Entities.Authentication;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class OdontoPediatraContext : IdentityDbContext<ApplicationUser>
    {
        public OdontoPediatraContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OdontoPediatraContext>();
            optionsBuilder.UseSqlServer(Util.ConnectionString);
        }

        public OdontoPediatraContext(DbContextOptions<OdontoPediatraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advice> Advices { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Clinic> Clinics { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientDoctor> PatientDoctors { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
        public virtual DbSet<Treatment> Treatments { get; set; } = null!;
        public virtual DbSet<TreatmentPatient> TreatmentPatients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advice>(entity =>
            {
                entity.ToTable("Advice");

                entity.Property(e => e.AdviceId).HasColumnName("AdviceID");

                entity.Property(e => e.Description).HasMaxLength(1500);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Advices)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Advice__DoctorId__5D2BD0E6");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppoinmentId)
                    .HasName("PK__Appointm__DE36FF8F84B9EF0C");

                entity.ToTable("Appointment");

                entity.Property(e => e.AppoinmentId).HasColumnName("AppoinmentID");

                entity.Property(e => e.CitaAsignada).HasDefaultValueSql("((0))");

                entity.Property(e => e.Motivo).HasMaxLength(150);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Patie__5A4F643B");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Sched__595B4002");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.ToTable("Clinic");

                entity.Property(e => e.ClinicAddress).HasMaxLength(255);

                entity.Property(e => e.ClinicName).HasMaxLength(60);

                entity.Property(e => e.ClinicPhone).HasMaxLength(10);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Clinics)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clinic__DoctorId__62E4AA3C");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Clinics)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clinic__Province__61F08603");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Identification).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(60);

                entity.Property(e => e.Name).HasMaxLength(60);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.Level).HasMaxLength(20);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Age).HasMaxLength(2);

                entity.Property(e => e.Identification).HasMaxLength(25);

                entity.Property(e => e.LastName).HasMaxLength(60);

                entity.Property(e => e.Name).HasMaxLength(60);

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__Educati__63D8CE75");
            });

            modelBuilder.Entity<PatientDoctor>(entity =>
            {
                entity.ToTable("PatientDoctor");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PatientDoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientDo__Docto__6D6238AF");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientDoctors)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientDo__Patie__6C6E1476");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.ProvinceName).HasMaxLength(60);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.TimeOfDay).HasMaxLength(10);
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatment");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TreatmentPatient>(entity =>
            {
                entity.ToTable("TreatmentPatient");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TreatmentPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Treatment__Patie__3EA749C6");

                entity.HasOne(d => d.Treatment)
                    .WithMany(p => p.TreatmentPatients)
                    .HasForeignKey(d => d.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Treatment__Treat__3F9B6DFF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
