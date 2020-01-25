﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eGOTBackend.Models;

namespace eGOTBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200125015504_add_photoproof_and_fix_its_ids")]
    partial class add_photoproof_and_fix_its_ids
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eGOTBackend.Models.BadgeLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Icon")
                        .HasColumnName("icon")
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<int>("RequiredPoints")
                        .HasColumnName("required_points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Badge_level_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ__Badge_le__72E12F1BB5625E74");

                    b.ToTable("Badge_level");
                });

            modelBuilder.Entity("eGOTBackend.Models.CommissionWorker", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnName("id_user")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdUser")
                        .HasName("PK__Commissi__D2D146379EBC1A27");

                    b.ToTable("Commission_worker");
                });

            modelBuilder.Entity("eGOTBackend.Models.DepartmentWorker", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnName("id_user")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdUser")
                        .HasName("PK__Departme__D2D1463721266F09");

                    b.ToTable("Department_worker");
                });

            modelBuilder.Entity("eGOTBackend.Models.GpsProof", b =>
                {
                    b.Property<int>("IdTrip")
                        .HasColumnName("id_trip")
                        .HasColumnType("int");

                    b.Property<string>("GpsDataUrl")
                        .IsRequired()
                        .HasColumnName("GPS_data_url")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdTrip")
                        .HasName("PK__GPS_proo__F5F227788A19A250");

                    b.ToTable("GPS_proof");
                });

            modelBuilder.Entity("eGOTBackend.Models.History", b =>
                {
                    b.Property<int>("IdTourist")
                        .HasColumnName("id_tourist")
                        .HasColumnType("int");

                    b.Property<int>("IdBadgeLevel")
                        .HasColumnName("id_badge_level")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdTourist", "IdBadgeLevel")
                        .HasName("PK__History__2A509D270486FE06");

                    b.HasIndex("IdBadgeLevel");

                    b.ToTable("History");
                });

            modelBuilder.Entity("eGOTBackend.Models.Leader", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnName("id_user")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdUser")
                        .HasName("PK__Leader__D2D14637CD94AC72");

                    b.ToTable("Leader");
                });

            modelBuilder.Entity("eGOTBackend.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Latitude")
                        .HasColumnName("latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longtitude")
                        .HasColumnName("longtitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Location_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ__Location__72E12F1BFB130DF5");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("eGOTBackend.Models.MountainRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MountainSystemId")
                        .HasColumnName("mountain_system")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Mountain_range_id");

                    b.HasIndex("MountainSystemId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ__Mountain__72E12F1B98630B12");

                    b.ToTable("Mountain_range");
                });

            modelBuilder.Entity("eGOTBackend.Models.MountainSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Mountain_system_id");

                    b.ToTable("Mountain_system");
                });

            modelBuilder.Entity("eGOTBackend.Models.Permission", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnName("id_user")
                        .HasColumnType("int");

                    b.Property<int>("IdMountainRange")
                        .HasColumnName("id_mountain_range")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdMountainRange")
                        .HasName("PK__Permissi__730A8F62FB70595C");

                    b.HasIndex("IdMountainRange");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("eGOTBackend.Models.PhotoProof", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTrip")
                        .HasColumnName("id_trip")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnName("photo_url")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Photo_proof_id");

                    b.HasIndex("IdTrip")
                        .IsUnique();

                    b.ToTable("Photo_proof");
                });

            modelBuilder.Entity("eGOTBackend.Models.Route", b =>
                {
                    b.Property<int>("IdTrip")
                        .HasColumnName("id_trip")
                        .HasColumnType("int");

                    b.Property<int>("IdSection")
                        .HasColumnName("id_section")
                        .HasColumnType("int");

                    b.Property<int>("PositionInTrip")
                        .HasColumnName("position_in_trip")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdTrip", "IdSection", "PositionInTrip")
                        .HasName("PK__Route__1A08A8B705DA99C5");

                    b.HasIndex("IdSection");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("eGOTBackend.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("ElevationGain")
                        .HasColumnName("elevation_gain")
                        .HasColumnType("real");

                    b.Property<int>("EndLocationId")
                        .HasColumnName("end_location")
                        .HasColumnType("int");

                    b.Property<float>("Length")
                        .HasColumnName("length")
                        .HasColumnType("real");

                    b.Property<int>("MountainRangeId")
                        .HasColumnName("mountain_range")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnName("score")
                        .HasColumnType("int");

                    b.Property<int>("StartLocationId")
                        .HasColumnName("start_location")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EndLocationId");

                    b.HasIndex("Id")
                        .HasName("Section_id");

                    b.HasIndex("MountainRangeId");

                    b.HasIndex("StartLocationId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("eGOTBackend.Models.Tourist", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnName("id_user")
                        .HasColumnType("int");

                    b.Property<int>("AllPoints")
                        .HasColumnName("all_points")
                        .HasColumnType("int");

                    b.Property<int>("ConfirmedPoints")
                        .HasColumnName("confirmed_points")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("date_of_birth")
                        .HasColumnType("datetime");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdBadgeLevel")
                        .HasColumnName("id_badge_level")
                        .HasColumnType("int");

                    b.Property<bool>("IsDisabled")
                        .HasColumnName("is_disabled")
                        .HasColumnType("bit");

                    b.HasKey("IdUser")
                        .HasName("PK__Tourist__D2D1463735CD9327");

                    b.HasIndex("IdBadgeLevel");

                    b.ToTable("Tourist");
                });

            modelBuilder.Entity("eGOTBackend.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("ElevationGain")
                        .HasColumnName("elevation_gain")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("end_date")
                        .HasColumnType("datetime");

                    b.Property<int>("IdTourist")
                        .HasColumnName("id_tourist")
                        .HasColumnType("int");

                    b.Property<float>("Length")
                        .HasColumnName("length")
                        .HasColumnType("real");

                    b.Property<int>("Score")
                        .HasColumnName("score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("start_date")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Trip_id");

                    b.HasIndex("IdTourist");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("eGOTBackend.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnName("last_seen")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Users__AB6E6164A513AC01");

                    b.HasIndex("Id")
                        .HasName("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eGOTBackend.Models.CommissionWorker", b =>
                {
                    b.HasOne("eGOTBackend.Models.Users", "IdUserNavigation")
                        .WithOne("CommissionWorker")
                        .HasForeignKey("eGOTBackend.Models.CommissionWorker", "IdUser")
                        .HasConstraintName("FKCommission_worker228672")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.DepartmentWorker", b =>
                {
                    b.HasOne("eGOTBackend.Models.Users", "IdUserNavigation")
                        .WithOne("DepartmentWorker")
                        .HasForeignKey("eGOTBackend.Models.DepartmentWorker", "IdUser")
                        .HasConstraintName("FKDepartment_worker81783")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.GpsProof", b =>
                {
                    b.HasOne("eGOTBackend.Models.Trip", "IdTripNavigation")
                        .WithOne("GpsProof")
                        .HasForeignKey("eGOTBackend.Models.GpsProof", "IdTrip")
                        .HasConstraintName("FKGPS_proof590864")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.History", b =>
                {
                    b.HasOne("eGOTBackend.Models.BadgeLevel", "IdBadgeLevelNavigation")
                        .WithMany("History")
                        .HasForeignKey("IdBadgeLevel")
                        .HasConstraintName("FKHistory256828")
                        .IsRequired();

                    b.HasOne("eGOTBackend.Models.Tourist", "IdTouristNavigation")
                        .WithMany("History")
                        .HasForeignKey("IdTourist")
                        .HasConstraintName("FKHistory784901")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.Leader", b =>
                {
                    b.HasOne("eGOTBackend.Models.Users", "IdUserNavigation")
                        .WithOne("Leader")
                        .HasForeignKey("eGOTBackend.Models.Leader", "IdUser")
                        .HasConstraintName("FKLeader405786")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.MountainRange", b =>
                {
                    b.HasOne("eGOTBackend.Models.MountainSystem", "MountainSystem")
                        .WithMany("MountainRanges")
                        .HasForeignKey("MountainSystemId")
                        .HasConstraintName("FKSection521451")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.Permission", b =>
                {
                    b.HasOne("eGOTBackend.Models.MountainRange", "IdMountainRangeNavigation")
                        .WithMany("Permission")
                        .HasForeignKey("IdMountainRange")
                        .HasConstraintName("FKPermission185604")
                        .IsRequired();

                    b.HasOne("eGOTBackend.Models.Leader", "IdUserNavigation")
                        .WithMany("Permission")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FKPermission277937")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.PhotoProof", b =>
                {
                    b.HasOne("eGOTBackend.Models.Trip", "IdTripNavigation")
                        .WithOne("PhotoProof")
                        .HasForeignKey("eGOTBackend.Models.PhotoProof", "IdTrip")
                        .HasConstraintName("FKPhoto_proof12437")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.Route", b =>
                {
                    b.HasOne("eGOTBackend.Models.Section", "IdSectionNavigation")
                        .WithMany("Routes")
                        .HasForeignKey("IdSection")
                        .HasConstraintName("FKRoute598500")
                        .IsRequired();

                    b.HasOne("eGOTBackend.Models.Trip", "IdTripNavigation")
                        .WithMany("Route")
                        .HasForeignKey("IdTrip")
                        .HasConstraintName("FKRoute778662")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.Section", b =>
                {
                    b.HasOne("eGOTBackend.Models.Location", "EndLocation")
                        .WithMany("SectionEndLocationNavigation")
                        .HasForeignKey("EndLocationId")
                        .HasConstraintName("FKSection74604")
                        .IsRequired();

                    b.HasOne("eGOTBackend.Models.MountainRange", "MountainRange")
                        .WithMany("Section")
                        .HasForeignKey("MountainRangeId")
                        .HasConstraintName("FKSection521241")
                        .IsRequired();

                    b.HasOne("eGOTBackend.Models.Location", "StartLocation")
                        .WithMany("SectionStartLocationNavigation")
                        .HasForeignKey("StartLocationId")
                        .HasConstraintName("FKSection198858")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.Tourist", b =>
                {
                    b.HasOne("eGOTBackend.Models.BadgeLevel", "IdBadgeLevelNavigation")
                        .WithMany("Tourist")
                        .HasForeignKey("IdBadgeLevel")
                        .HasConstraintName("FKTourist324263")
                        .IsRequired();

                    b.HasOne("eGOTBackend.Models.Users", "IdUserNavigation")
                        .WithOne("Tourist")
                        .HasForeignKey("eGOTBackend.Models.Tourist", "IdUser")
                        .HasConstraintName("FKTourist733992")
                        .IsRequired();
                });

            modelBuilder.Entity("eGOTBackend.Models.Trip", b =>
                {
                    b.HasOne("eGOTBackend.Models.Tourist", "IdTouristNavigation")
                        .WithMany("Trip")
                        .HasForeignKey("IdTourist")
                        .HasConstraintName("FKTrip848043")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
