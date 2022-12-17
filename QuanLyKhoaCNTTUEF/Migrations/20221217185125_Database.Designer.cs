﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhoaCNTTUEF.Models;

#nullable disable

namespace QuanLyKhoaCNTTUEF.Migrations
{
    [DbContext(typeof(ConfigDbContext))]
    [Migration("20221217185125_Database")]
    partial class Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.ChiTietTask", b =>
                {
                    b.Property<string>("IDNhom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IDTask")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("KetQua")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IDNhom");

                    b.ToTable("ChiTietTask");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.DanhSachThongTin", b =>
                {
                    b.Property<string>("IDNhom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DiaChiHienTai")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IDGiaoVien")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IDKhoa")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IDSinhVien")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IDTask")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IDNhom");

                    b.ToTable("DanhSachThongTin");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.KeHoach", b =>
                {
                    b.Property<string>("IDSuKien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("NgayDuyet")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTrinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiDuyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NguoiTrinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenKeHoach")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDSuKien");

                    b.ToTable("KeHoach");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.NguoiDung", b =>
                {
                    b.Property<string>("MSSV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("MSSV");

                    b.ToTable("NguoiDung");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Nhom", b =>
                {
                    b.Property<string>("IDSuKien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("IDNhom")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenNhom")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDSuKien");

                    b.ToTable("Nhom");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.SuKien", b =>
                {
                    b.Property<string>("IDSuKien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("NgayBD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKT")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenSuKien")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDSuKien");

                    b.ToTable("SuKien");
                });

            modelBuilder.Entity("QuanLyKhoaCNTTUEF.Models.Task", b =>
                {
                    b.Property<string>("IDSuKien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("IDTask")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("NgayBD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKT")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenTask")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDSuKien");

                    b.ToTable("Task");
                });
#pragma warning restore 612, 618
        }
    }
}
