﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations.Audit
{
    [DbContext(typeof(AuditDataContext))]
    [Migration("20210411071827_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Entities.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AffectedColumns")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("NewValues")
                        .HasColumnType("TEXT");

                    b.Property<string>("OldValues")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimaryKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("TableName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Audit");
                });
#pragma warning restore 612, 618
        }
    }
}