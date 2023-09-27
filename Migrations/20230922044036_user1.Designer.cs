﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMgmt.Data;

#nullable disable

namespace UserMgmt.Migrations
{
    [DbContext(typeof(UserMgmtContext))]
    [Migration("20230922044036_user1")]
    partial class user1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserMgmt.Model.MediclaimType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MediclaimType");
                });

            modelBuilder.Entity("UserMgmt.Model.UserSalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasMediclaim")
                        .HasColumnType("bit");

                    b.Property<int>("MediclaimTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MediclaimTypeId");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("UserSalary");
                });

            modelBuilder.Entity("UserMgmt.Model.UsersInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateHired")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("UserMgmt.Model.UserSalary", b =>
                {
                    b.HasOne("UserMgmt.Model.MediclaimType", "MediclaimType")
                        .WithMany("UserSalary")
                        .HasForeignKey("MediclaimTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserMgmt.Model.UsersInfo", "UsersInfo")
                        .WithOne("UserSalary")
                        .HasForeignKey("UserMgmt.Model.UserSalary", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediclaimType");

                    b.Navigation("UsersInfo");
                });

            modelBuilder.Entity("UserMgmt.Model.MediclaimType", b =>
                {
                    b.Navigation("UserSalary");
                });

            modelBuilder.Entity("UserMgmt.Model.UsersInfo", b =>
                {
                    b.Navigation("UserSalary")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}