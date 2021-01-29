﻿// <auto-generated />
using System;
using Baby_Tracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Baby_Tracker.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Baby_Tracker.Models.Baby", b =>
                {
                    b.Property<Guid>("BabyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("BirthHeight")
                        .HasColumnType("double");

                    b.Property<double>("BirthWeight")
                        .HasColumnType("double");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Height")
                        .HasColumnType("double");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerId1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerId2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OwnerId3")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("BabyId");

                    b.ToTable("Baby");
                });

            modelBuilder.Entity("Baby_Tracker.Models.Feed", b =>
                {
                    b.Property<Guid>("FeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Alertness")
                        .HasColumnType("int");

                    b.Property<Guid>("BabyId")
                        .HasColumnType("char(36)");

                    b.Property<int>("ChinEngagement")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FeedSummary")
                        .HasColumnType("int");

                    b.Property<int>("Fussiness")
                        .HasColumnType("int");

                    b.Property<bool>("IsDreamFeed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LatchQuality")
                        .HasColumnType("int");

                    b.Property<Guid?>("SleepId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("FeedId");

                    b.HasIndex("BabyId");

                    b.HasIndex("SleepId");

                    b.ToTable("Feed");
                });

            modelBuilder.Entity("Baby_Tracker.Models.Intervention", b =>
                {
                    b.Property<Guid>("InterventionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FirstTry")
                        .HasColumnType("int");

                    b.Property<int>("FourthTry")
                        .HasColumnType("int");

                    b.Property<int>("InterventionSummary")
                        .HasColumnType("int");

                    b.Property<int>("SecondTry")
                        .HasColumnType("int");

                    b.Property<Guid?>("SleepId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ThirdTry")
                        .HasColumnType("int");

                    b.HasKey("InterventionId");

                    b.HasIndex("SleepId");

                    b.ToTable("Intervention");
                });

            modelBuilder.Entity("Baby_Tracker.Models.Sleep", b =>
                {
                    b.Property<Guid>("SleepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BabyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsNap")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("SleepSummary")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("SleepId");

                    b.HasIndex("BabyId");

                    b.ToTable("Sleep");
                });

            modelBuilder.Entity("Baby_Tracker.Models.Feed", b =>
                {
                    b.HasOne("Baby_Tracker.Models.Baby", null)
                        .WithMany("Feeds")
                        .HasForeignKey("BabyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Baby_Tracker.Models.Sleep", null)
                        .WithMany("SleepFeeds")
                        .HasForeignKey("SleepId");
                });

            modelBuilder.Entity("Baby_Tracker.Models.Intervention", b =>
                {
                    b.HasOne("Baby_Tracker.Models.Sleep", null)
                        .WithMany("Interventions")
                        .HasForeignKey("SleepId");
                });

            modelBuilder.Entity("Baby_Tracker.Models.Sleep", b =>
                {
                    b.HasOne("Baby_Tracker.Models.Baby", null)
                        .WithMany("Sleeps")
                        .HasForeignKey("BabyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
