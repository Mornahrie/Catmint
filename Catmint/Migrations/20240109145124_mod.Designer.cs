﻿// <auto-generated />
using System;
using Catmint.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catmint.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240109145124_mod")]
    partial class mod
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Catmint.Models.Booked", b =>
                {
                    b.Property<int>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("book_id"), 1L, 1);

                    b.Property<DateTime>("booked_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("table_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("book_id");

                    b.ToTable("Bookeds");
                });

            modelBuilder.Entity("Catmint.Models.Cat", b =>
                {
                    b.Property<int>("cat_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cat_id"), 1L, 1);

                    b.Property<int>("cat_age")
                        .HasColumnType("int");

                    b.Property<string>("cat_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cat_photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("history")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("place_id")
                        .HasColumnType("int");

                    b.Property<int>("sex_id")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("cat_id");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("Catmint.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"), 1L, 1);

                    b.Property<string>("categ_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Catmint.Models.Comment", b =>
                {
                    b.Property<int>("comm_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("comm_id"), 1L, 1);

                    b.Property<string>("comment_text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("modered")
                        .HasColumnType("int");

                    b.Property<int>("rank")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("comm_id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Catmint.Models.Description", b =>
                {
                    b.Property<int>("desc_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("desc_id"), 1L, 1);

                    b.Property<int?>("cat_id")
                        .HasColumnType("int");

                    b.Property<int>("right_id")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("value_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("desc_id");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("Catmint.Models.Lazalka", b =>
                {
                    b.Property<int>("place_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("place_id"), 1L, 1);

                    b.Property<int>("place_num")
                        .HasColumnType("int");

                    b.HasKey("place_id");

                    b.ToTable("Lazalki");
                });

            modelBuilder.Entity("Catmint.Models.Menu", b =>
                {
                    b.Property<int>("dish_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dish_id"), 1L, 1);

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<string>("dish_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("dish_price")
                        .HasColumnType("real");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("dish_id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Catmint.Models.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"), 1L, 1);

                    b.Property<int>("dish_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("order_status")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("table_id")
                        .HasColumnType("int");

                    b.HasKey("order_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Catmint.Models.Right", b =>
                {
                    b.Property<int>("right_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("right_id"), 1L, 1);

                    b.Property<int>("right_value")
                        .HasColumnType("int");

                    b.HasKey("right_id");

                    b.ToTable("Rights");
                });

            modelBuilder.Entity("Catmint.Models.Sex", b =>
                {
                    b.Property<int>("sex_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sex_id"), 1L, 1);

                    b.Property<string>("sex_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sex_id");

                    b.ToTable("Sexs");
                });

            modelBuilder.Entity("Catmint.Models.Tables", b =>
                {
                    b.Property<int>("table_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("table_id"), 1L, 1);

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.HasKey("table_id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Catmint.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"), 1L, 1);

                    b.Property<int?>("cat_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_of_birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fathername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("phone_num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("right_id")
                        .HasColumnType("int");

                    b.Property<int>("sex_id")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}