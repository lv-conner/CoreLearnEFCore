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
    [Migration("20180302073044_Init")]
    partial class Init
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

            modelBuilder.Entity("EFCoreRelationship.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EFCoreRelationship.Book", b =>
                {
                    b.HasOne("EFCoreRelationship.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}