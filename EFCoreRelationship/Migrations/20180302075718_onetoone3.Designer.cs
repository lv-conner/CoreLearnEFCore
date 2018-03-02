﻿// <auto-generated />
using EFCoreRelationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EFCoreRelationship.Migrations
{
    [DbContext(typeof(EFCoreRelationContext))]
    [Migration("20180302075718_onetoone3")]
    partial class onetoone3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreRelationship.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ISBM");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("EFCoreRelationship.StudentInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StudentNumber")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("StudentInfo");
                });

            modelBuilder.Entity("EFCoreRelationship.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<Guid?>("StudentInfoId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StudentInfoId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("EFCoreRelationship.Book", b =>
                {
                    b.HasOne("EFCoreRelationship.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreRelationship.User", b =>
                {
                    b.HasOne("EFCoreRelationship.StudentInfo", "StudentInfo")
                        .WithOne("User")
                        .HasForeignKey("EFCoreRelationship.User", "StudentInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
