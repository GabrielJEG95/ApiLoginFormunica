using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiLoginFormunica.Models
{
    public partial class ApiSecFormunicaContext : DbContext
    {
        public ApiSecFormunicaContext()
        {
        }

        public ApiSecFormunicaContext(DbContextOptions<ApiSecFormunicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accion> Accions { get; set; } = null!;
        public virtual DbSet<ActionsAudit> ActionsAudits { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<ContactInformation> ContactInformations { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Entidade> Entidades { get; set; } = null!;
        public virtual DbSet<LogSesion> LogSesions { get; set; } = null!;
        public virtual DbSet<Pantalla> Pantallas { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<RelacionAccione> RelacionAcciones { get; set; } = null!;
        public virtual DbSet<RelacionEntidade> RelacionEntidades { get; set; } = null!;
        public virtual DbSet<RelacionPaise> RelacionPaises { get; set; } = null!;
        public virtual DbSet<RelacionPantalla> RelacionPantallas { get; set; } = null!;
        public virtual DbSet<TypeContact> TypeContacts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accion>(entity =>
            {
                entity.HasKey(e => e.IdAccion)
                    .HasName("PK__Accion__9845169BA8E21FC4");

                entity.ToTable("Accion");

                entity.Property(e => e.Accion1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Accion");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Accions)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accion__IdCity__4BAC3F29");

                entity.HasOne(d => d.IdPantallaNavigation)
                    .WithMany(p => p.Accions)
                    .HasForeignKey(d => d.IdPantalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accion__IdPantal__4AB81AF0");
            });

            modelBuilder.Entity<ActionsAudit>(entity =>
            {
                entity.HasKey(e => e.IdActionsAudit)
                    .HasName("PK__ActionsA__90F9475BD403DB2F");

                entity.ToTable("ActionsAudit");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdAccionNavigation)
                    .WithMany(p => p.ActionsAudits)
                    .HasForeignKey(d => d.IdAccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActionsAu__IdAcc__70DDC3D8");

                entity.HasOne(d => d.IdEntidadNavigation)
                    .WithMany(p => p.ActionsAudits)
                    .HasForeignKey(d => d.IdEntidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActionsAu__IdEnt__72C60C4A");

                entity.HasOne(d => d.IdPantallaNavigation)
                    .WithMany(p => p.ActionsAudits)
                    .HasForeignKey(d => d.IdPantalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActionsAu__IdPan__71D1E811");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ActionsAudits)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActionsAu__IdUse__73BA3083");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.IdBranch)
                    .HasName("PK__Branch__54205B044898D74D");

                entity.ToTable("Branch");

                entity.Property(e => e.Branch1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Branch");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Branch__IdCity__30F848ED");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PK__City__394B023AC5632B27");

                entity.ToTable("City");

                entity.Property(e => e.City1)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("City");

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__IdCountry__2C3393D0");
            });

            modelBuilder.Entity<ContactInformation>(entity =>
            {
                entity.HasKey(e => e.IdContactInformation)
                    .HasName("PK__ContactI__7C30709629F6AAC2");

                entity.ToTable("ContactInformation");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.ContactInformations)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactIn__Perso__3D5E1FD2");

                entity.HasOne(d => d.TypeContactNavigation)
                    .WithMany(p => p.ContactInformations)
                    .HasForeignKey(d => d.TypeContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactIn__TypeC__3C69FB99");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__Country__F99F104D49DBC564");

                entity.ToTable("Country");

                entity.Property(e => e.Country1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Country");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Entidade>(entity =>
            {
                entity.HasKey(e => e.IdEntidad)
                    .HasName("PK__Entidade__7D662868BDC3D955");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Entidad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogSesion>(entity =>
            {
                entity.HasKey(e => e.IdLogSesion)
                    .HasName("PK__LogSesio__C215D227ADDD4C90");

                entity.ToTable("LogSesion");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Pantalla>(entity =>
            {
                entity.HasKey(e => e.IdPantalla)
                    .HasName("PK__Pantalla__CAF8EE4F8111D17D");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pantalla1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pantalla");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdEntidadNavigation)
                    .WithMany(p => p.Pantallas)
                    .HasForeignKey(d => d.IdEntidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pantallas__IdEnt__45F365D3");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__Person__A5D4E15BBAF105F0");

                entity.ToTable("Person");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<RelacionAccione>(entity =>
            {
                entity.HasKey(e => e.IdRelationAction)
                    .HasName("PK__relacion__D290FEBED8088A16");

                entity.ToTable("relacionAcciones");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdAccionNavigation)
                    .WithMany(p => p.RelacionAcciones)
                    .HasForeignKey(d => d.IdAccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relacionA__IdAcc__66603565");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.RelacionAcciones)
                    .HasForeignKey(d => d.IdUsers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relacionA__IdUse__656C112C");
            });

            modelBuilder.Entity<RelacionEntidade>(entity =>
            {
                entity.HasKey(e => e.IdRelationEntidad)
                    .HasName("PK__relacion__DA6456B78712F562");

                entity.ToTable("relacionEntidades");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdEntidadNavigation)
                    .WithMany(p => p.RelacionEntidades)
                    .HasForeignKey(d => d.IdEntidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relacionE__IdEnt__6477ECF3");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.RelacionEntidades)
                    .HasForeignKey(d => d.IdUsers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relacionE__IdUse__6383C8BA");
            });

            modelBuilder.Entity<RelacionPaise>(entity =>
            {
                entity.HasKey(e => e.IdRelationCountry)
                    .HasName("PK__Relacion__9E9ED6EC869E4161");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.RelacionPaises)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RelacionP__IdCou__619B8048");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.RelacionPaises)
                    .HasForeignKey(d => d.Idusers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RelacionP__Iduse__628FA481");
            });

            modelBuilder.Entity<RelacionPantalla>(entity =>
            {
                entity.HasKey(e => e.IdRelationPantalla)
                    .HasName("PK__relacion__2B762E619A49A963");

                entity.ToTable("relacionPantalla");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsers).HasColumnName("IdUSers");

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdPantallaNavigation)
                    .WithMany(p => p.RelacionPantallas)
                    .HasForeignKey(d => d.IdPantalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relacionP__IdPan__6D0D32F4");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.RelacionPantallas)
                    .HasForeignKey(d => d.IdUsers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relacionP__IdUSe__6B24EA82");
            });

            modelBuilder.Entity<TypeContact>(entity =>
            {
                entity.HasKey(e => e.IdTypeContact)
                    .HasName("PK__TypeCont__07F4F2466051757A");

                entity.ToTable("TypeContact");

                entity.Property(e => e.TypeContact1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TypeContact");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers)
                    .HasName("PK__Users__C781FF19278852A2");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RemoveDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Token)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__IdPerson__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
