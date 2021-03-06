﻿// <auto-generated />
using System;
using HoopRunAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HoopRunAPI.Migrations
{
    [DbContext(typeof(HoopRunAPIContext))]
    [Migration("20190217210316_codeCleanup2")]
    partial class codeCleanup2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoopRunAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Line2")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("HoopRunAPI.Models.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired();

                    b.Property<string>("AddressLine2")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Coordinates");

                    b.Property<int?>("GymOwnerId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GymOwnerId");

                    b.ToTable("Gym");
                });

            modelBuilder.Entity("HoopRunAPI.Models.GymOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Gender");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("ProfilePicture");

                    b.Property<bool>("Status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("GymOwner");
                });

            modelBuilder.Entity("HoopRunAPI.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Gender");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("ProfilePicture");

                    b.Property<int?>("RunId");

                    b.Property<bool>("Status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("RunId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("HoopRunAPI.Models.PlayerRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId");

                    b.Property<int>("RunId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerRun");
                });

            modelBuilder.Entity("HoopRunAPI.Models.Run", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Availability");

                    b.Property<int?>("GymId");

                    b.Property<int>("MinimumAge");

                    b.Property<decimal>("ParticipationFee");

                    b.Property<string>("RunName");

                    b.Property<string>("SkillLevel");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.ToTable("Run");
                });

            modelBuilder.Entity("HoopRunAPI.Models.Gym", b =>
                {
                    b.HasOne("HoopRunAPI.Models.GymOwner")
                        .WithMany("GymList")
                        .HasForeignKey("GymOwnerId");
                });

            modelBuilder.Entity("HoopRunAPI.Models.Player", b =>
                {
                    b.HasOne("HoopRunAPI.Models.Run")
                        .WithMany("RunningPlayers")
                        .HasForeignKey("RunId");
                });

            modelBuilder.Entity("HoopRunAPI.Models.PlayerRun", b =>
                {
                    b.HasOne("HoopRunAPI.Models.Player")
                        .WithMany("PlayerRuns")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoopRunAPI.Models.Run", b =>
                {
                    b.HasOne("HoopRunAPI.Models.Gym", "Gym")
                        .WithMany()
                        .HasForeignKey("GymId");
                });
#pragma warning restore 612, 618
        }
    }
}
