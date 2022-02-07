﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quads.Models;

namespace Quads.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20220207202239_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Quads.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("Quads.Models.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsImportant")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            CategoryID = 1,
                            DueDate = "03-02-2022",
                            IsCompleted = false,
                            IsImportant = false,
                            IsUrgent = true,
                            TaskName = "Setup"
                        },
                        new
                        {
                            TaskID = 2,
                            CategoryID = 2,
                            DueDate = "03-07-2022",
                            IsCompleted = true,
                            IsImportant = false,
                            IsUrgent = false,
                            TaskName = "Plan"
                        },
                        new
                        {
                            TaskID = 3,
                            CategoryID = 4,
                            DueDate = "03-05-2022",
                            IsCompleted = false,
                            IsImportant = true,
                            IsUrgent = true,
                            TaskName = "Phone Calls"
                        });
                });

            modelBuilder.Entity("Quads.Models.Task", b =>
                {
                    b.HasOne("Quads.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
