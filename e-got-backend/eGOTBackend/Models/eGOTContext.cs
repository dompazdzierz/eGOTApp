using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eGOTBackend.Models
{
    public partial class eGOTContext : DbContext
    {
        public eGOTContext()
        {
        }

        public eGOTContext(DbContextOptions<eGOTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BadgeLevel> BadgeLevel { get; set; }
        public virtual DbSet<CommissionWorker> CommissionWorker { get; set; }
        public virtual DbSet<DepartmentWorker> DepartmentWorker { get; set; }
        public virtual DbSet<GpsProof> GpsProof { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Leader> Leader { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MountainRange> MountainRange { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PhotoProof> PhotoProof { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<Turist> Turist { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=eGOT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadgeLevel>(entity =>
            {
                entity.ToTable("Badge_level");

                entity.HasIndex(e => e.Id)
                    .HasName("Badge_level_id");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Badge_le__72E12F1BB5625E74")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequiredPoints).HasColumnName("required_points");
            });

            modelBuilder.Entity<CommissionWorker>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Commissi__D2D146379EBC1A27");

                entity.ToTable("Commission_worker");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.CommissionWorker)
                    .HasForeignKey<CommissionWorker>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCommission_worker228672");
            });

            modelBuilder.Entity<DepartmentWorker>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Departme__D2D1463721266F09");

                entity.ToTable("Department_worker");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.DepartmentWorker)
                    .HasForeignKey<DepartmentWorker>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDepartment_worker81783");
            });

            modelBuilder.Entity<GpsProof>(entity =>
            {
                entity.HasKey(e => e.IdTrip)
                    .HasName("PK__GPS_proo__F5F227788A19A250");

                entity.ToTable("GPS_proof");

                entity.Property(e => e.IdTrip)
                    .HasColumnName("id_trip")
                    .ValueGeneratedNever();

                entity.Property(e => e.GpsData)
                    .HasColumnName("GPS_data")
                    .HasColumnType("image");

                entity.HasOne(d => d.IdTripNavigation)
                    .WithOne(p => p.GpsProof)
                    .HasForeignKey<GpsProof>(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGPS_proof590864");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => new { e.IdTurist, e.IdBadgeLevel })
                    .HasName("PK__History__2A509D270486FE06");

                entity.Property(e => e.IdTurist).HasColumnName("id_turist");

                entity.Property(e => e.IdBadgeLevel).HasColumnName("id_badge_level");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdBadgeLevelNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.IdBadgeLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHistory256828");

                entity.HasOne(d => d.IdTuristNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.IdTurist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHistory784901");
            });

            modelBuilder.Entity<Leader>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Leader__D2D14637CD94AC72");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Leader)
                    .HasForeignKey<Leader>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLeader405786");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Location_id");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Location__72E12F1BFB130DF5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longtitude).HasColumnName("longtitude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MountainRange>(entity =>
            {
                entity.ToTable("Mountain_range");

                entity.HasIndex(e => e.Id)
                    .HasName("Mountain_range_id");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Mountain__72E12F1B98630B12")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdMountainRange })
                    .HasName("PK__Permissi__730A8F62FB70595C");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdMountainRange).HasColumnName("id_mountain_range");

                entity.HasOne(d => d.IdMountainRangeNavigation)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.IdMountainRange)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPermission185604");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPermission277937");
            });

            modelBuilder.Entity<PhotoProof>(entity =>
            {
                entity.HasKey(e => e.IdTrip)
                    .HasName("PK__Photo_pr__F5F2277824A7906D");

                entity.ToTable("Photo_proof");

                entity.Property(e => e.IdTrip)
                    .HasColumnName("id_trip")
                    .ValueGeneratedNever();

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.HasOne(d => d.IdTripNavigation)
                    .WithOne(p => p.PhotoProof)
                    .HasForeignKey<PhotoProof>(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPhoto_proof12437");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => new { e.IdTrip, e.IdSection, e.PositionInTrip })
                    .HasName("PK__Route__1A08A8B705DA99C5");

                entity.Property(e => e.IdTrip).HasColumnName("id_trip");

                entity.Property(e => e.IdSection).HasColumnName("id_section");

                entity.Property(e => e.PositionInTrip).HasColumnName("position_in_trip");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.IdSection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRoute598500");

                entity.HasOne(d => d.IdTripNavigation)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRoute778662");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Section_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ElevationGain).HasColumnName("elevation_gain");

                entity.Property(e => e.EndLocation).HasColumnName("end_location");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.MountainRange).HasColumnName("mountain_range");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.StartLocation).HasColumnName("start_location");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.EndLocationNavigation)
                    .WithMany(p => p.SectionEndLocationNavigation)
                    .HasForeignKey(d => d.EndLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSection74604");

                entity.HasOne(d => d.MountainRangeNavigation)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.MountainRange)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSection521241");

                entity.HasOne(d => d.StartLocationNavigation)
                    .WithMany(p => p.SectionStartLocationNavigation)
                    .HasForeignKey(d => d.StartLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSection198858");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Trip_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ElevationGain).HasColumnName("elevation_gain");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTurist).HasColumnName("id_turist");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdTuristNavigation)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.IdTurist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrip848043");
            });

            modelBuilder.Entity<Turist>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Turist__D2D1463735CD9327");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllPoints).HasColumnName("all_points");

                entity.Property(e => e.ConfirmedPoints).HasColumnName("confirmed_points");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdBadgeLevel).HasColumnName("id_badge_level");

                entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");

                entity.HasOne(d => d.IdBadgeLevelNavigation)
                    .WithMany(p => p.Turist)
                    .HasForeignKey(d => d.IdBadgeLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTurist324263");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Turist)
                    .HasForeignKey<Turist>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTurist733992");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__AB6E6164A513AC01")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("User_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastSeen)
                    .HasColumnName("last_seen")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
