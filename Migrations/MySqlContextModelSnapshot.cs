﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_software_documentation.src.Infra.Data.Context;

#nullable disable

namespace api_software_documenxtation.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.FunctionalRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Actor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Sequential")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("FunctionalRequirements");
                });

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.FunctionalRequirement_UserRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FunctionalRequirementId")
                        .HasColumnType("int");

                    b.Property<int>("UserRequirementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FunctionalRequirementId");

                    b.HasIndex("UserRequirementId");

                    b.ToTable("FunctionalRequirements_UserRequirements");
                });

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.UserRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Sequential")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserRequirements");
                });

            modelBuilder.Entity("api_software_documentation.src.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("api_software_documentation.src.Domain.Entities.ProjectCharter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectManager")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectCharters");
                });

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.FunctionalRequirement", b =>
                {
                    b.HasOne("api_software_documentation.src.Domain.Entities.Project", "Project")
                        .WithMany("FunctionalRequirements")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.FunctionalRequirement_UserRequirement", b =>
                {
                    b.HasOne("api_software_documentation.Src.Domain.Entities.FunctionalRequirement", "FunctionalRequirement")
                        .WithMany("FunctionalRequirements_UserRequirements")
                        .HasForeignKey("FunctionalRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_software_documentation.Src.Domain.Entities.UserRequirement", "UserRequirement")
                        .WithMany("FunctionalRequirements_UserRequirements")
                        .HasForeignKey("UserRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FunctionalRequirement");

                    b.Navigation("UserRequirement");
                });

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.UserRequirement", b =>
                {
                    b.HasOne("api_software_documentation.src.Domain.Entities.Project", "Project")
                        .WithMany("UserRequirements")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("api_software_documentation.src.Domain.Entities.ProjectCharter", b =>
                {
                    b.HasOne("api_software_documentation.src.Domain.Entities.Project", "Project")
                        .WithMany("ProjectCharters")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.FunctionalRequirement", b =>
                {
                    b.Navigation("FunctionalRequirements_UserRequirements");
                });

            modelBuilder.Entity("api_software_documentation.Src.Domain.Entities.UserRequirement", b =>
                {
                    b.Navigation("FunctionalRequirements_UserRequirements");
                });

            modelBuilder.Entity("api_software_documentation.src.Domain.Entities.Project", b =>
                {
                    b.Navigation("FunctionalRequirements");

                    b.Navigation("ProjectCharters");

                    b.Navigation("UserRequirements");
                });
#pragma warning restore 612, 618
        }
    }
}