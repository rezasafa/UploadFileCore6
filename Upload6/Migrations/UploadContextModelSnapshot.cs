﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Upload6.Models;

#nullable disable

namespace Upload6.Migrations
{
    [DbContext(typeof(UploadContext))]
    partial class UploadContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Upload6.Models.students", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("studentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentID"), 1L, 1);

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("studentID");

                    b.ToTable("students");
                });
#pragma warning restore 612, 618
        }
    }
}
