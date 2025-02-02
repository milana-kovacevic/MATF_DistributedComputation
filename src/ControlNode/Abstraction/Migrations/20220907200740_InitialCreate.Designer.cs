﻿// <auto-generated />
using ControlNode.Abstraction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlNode.Abstraction.Migrations
{
    [DbContext(typeof(JobContext))]
    [Migration("20220907200740_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Frontend.Models.AtomicJob", b =>
                {
                    b.Property<int>("AtomicJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtomicJobId"), 1L, 1);

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("InputData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.HasKey("AtomicJobId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("AtomicJob");
                });

            modelBuilder.Entity("Frontend.Models.AtomicJobResult", b =>
                {
                    b.Property<int>("AtomicJobId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("AtomicJobId", "JobId");

                    b.ToTable("AtomicJobResult");
                });

            modelBuilder.Entity("Frontend.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Frontend.Models.JobResult", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.ToTable("JobResult");
                });

            modelBuilder.Entity("Frontend.Models.AtomicJob", b =>
                {
                    b.HasOne("Frontend.Models.Job", "Job")
                        .WithMany("AtomicJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Frontend.Models.AtomicJobResult", b =>
                {
                    b.HasOne("Frontend.Models.AtomicJob", "AtomicJob")
                        .WithOne("AtomicJobResult")
                        .HasForeignKey("Frontend.Models.AtomicJobResult", "AtomicJobId", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AtomicJob");
                });

            modelBuilder.Entity("Frontend.Models.JobResult", b =>
                {
                    b.HasOne("Frontend.Models.Job", "Job")
                        .WithOne("JobResult")
                        .HasForeignKey("Frontend.Models.JobResult", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Frontend.Models.AtomicJob", b =>
                {
                    b.Navigation("AtomicJobResult")
                        .IsRequired();
                });

            modelBuilder.Entity("Frontend.Models.Job", b =>
                {
                    b.Navigation("AtomicJobs");

                    b.Navigation("JobResult")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
