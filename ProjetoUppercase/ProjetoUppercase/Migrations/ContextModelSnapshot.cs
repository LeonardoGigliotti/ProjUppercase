﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoUppercase.Models;

#nullable disable

namespace ProjetoUppercase.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoUppercase.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cor");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Foto");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Marca");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Modelo");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<int>("Preco")
                        .HasColumnType("int")
                        .HasColumnName("Preco");

                    b.HasKey("Id");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("ProjetoUppercase.Models.Pager", b =>
                {
                    b.Property<int>("CurrentPage")
                        .HasColumnType("int")
                        .HasColumnName("CurrentPage");

                    b.Property<int>("EndPage")
                        .HasColumnType("int")
                        .HasColumnName("EndPage");

                    b.Property<int>("PageSize")
                        .HasColumnType("int")
                        .HasColumnName("PageSize");

                    b.Property<int>("StartPage")
                        .HasColumnType("int")
                        .HasColumnName("StartPage");

                    b.Property<int>("TotalItems")
                        .HasColumnType("int")
                        .HasColumnName("TotalItems");

                    b.Property<int>("TotalPages")
                        .HasColumnType("int")
                        .HasColumnName("TotalPages");

                    b.ToTable("Pager");
                });
#pragma warning restore 612, 618
        }
    }
}