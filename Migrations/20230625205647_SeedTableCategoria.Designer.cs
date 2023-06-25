﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProjectCourse.Data;

#nullable disable

namespace WebProjectCourse.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230625205647_SeedTableCategoria")]
    partial class SeedTableCategoria
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebProjectCourse.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("OrdemDisplay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Ação",
                            OrdemDisplay = 1
                        },
                        new
                        {
                            Id = 2,
                            Nome = "SciFi",
                            OrdemDisplay = 2
                        },
                        new
                        {
                            Id = 3,
                            Nome = "História",
                            OrdemDisplay = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
