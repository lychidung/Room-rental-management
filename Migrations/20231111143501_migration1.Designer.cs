﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Phòng_Trọ;

#nullable disable

namespace Project_Phòng_Trọ.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20231111143501_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Contract", b =>
                {
                    b.Property<long>("ContractID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ContractID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("Date");

                    b.Property<long>("RoomID")
                        .HasColumnType("bigint");

                    b.Property<long>("StaffID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ContractID");

                    b.HasIndex("RoomID");

                    b.HasIndex("StaffID");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            ContractID = 1L,
                            CreateDate = new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 2L,
                            StaffID = 2L,
                            Status = true,
                            TotalAmount = 3000000m
                        },
                        new
                        {
                            ContractID = 2L,
                            CreateDate = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 4L,
                            StaffID = 4L,
                            Status = true,
                            TotalAmount = 55000000m
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.HistoryInvoices", b =>
                {
                    b.Property<long>("HistoryInvoicesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("HistoryInvoicesID"));

                    b.Property<long>("InvoiceID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("Date");

                    b.HasKey("HistoryInvoicesID");

                    b.HasIndex("InvoiceID");

                    b.ToTable("HistoryInvoices");

                    b.HasData(
                        new
                        {
                            HistoryInvoicesID = 1L,
                            InvoiceID = 1L,
                            PayDate = new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            HistoryInvoicesID = 2L,
                            InvoiceID = 2L,
                            PayDate = new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Invoices", b =>
                {
                    b.Property<long>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("InvoiceID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("Date");

                    b.Property<long>("RoomID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("InvoiceID");

                    b.HasIndex("RoomID");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceID = 1L,
                            CreateDate = new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 2L,
                            Status = true,
                            TotalAmount = 1900000m
                        },
                        new
                        {
                            InvoiceID = 2L,
                            CreateDate = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 4L,
                            Status = true,
                            TotalAmount = 4000000m
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Room", b =>
                {
                    b.Property<long>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RoomID"));

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("RoomPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomID = 1L,
                            Area = 5m,
                            RoomName = "Phòng 101",
                            RoomPrice = 1500000m,
                            Status = false
                        },
                        new
                        {
                            RoomID = 2L,
                            Area = 10m,
                            RoomName = "Phòng 102",
                            RoomPrice = 3000000m,
                            Status = true
                        },
                        new
                        {
                            RoomID = 3L,
                            Area = 15m,
                            RoomName = "Phòng 103",
                            RoomPrice = 4500000m,
                            Status = false
                        },
                        new
                        {
                            RoomID = 4L,
                            Area = 30m,
                            RoomName = "Phòng 104",
                            RoomPrice = 55000000m,
                            Status = true
                        },
                        new
                        {
                            RoomID = 5L,
                            Area = 12m,
                            RoomName = "Phòng 105",
                            RoomPrice = 35000000m,
                            Status = false
                        },
                        new
                        {
                            RoomID = 6L,
                            Area = 7m,
                            RoomName = "Phòng 106",
                            RoomPrice = 2000000m,
                            Status = false
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Service", b =>
                {
                    b.Property<long>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ServiceID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Date");

                    b.Property<string>("ImageFile")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceID = 1L,
                            CreateDate = new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 3000m,
                            ServiceName = "Điện"
                        },
                        new
                        {
                            ServiceID = 2L,
                            CreateDate = new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 5000m,
                            ServiceName = "Nước"
                        },
                        new
                        {
                            ServiceID = 3L,
                            CreateDate = new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 50000m,
                            ServiceName = "Rác thải"
                        },
                        new
                        {
                            ServiceID = 4L,
                            CreateDate = new DateTime(2001, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 220000m,
                            ServiceName = "Internet"
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.ServiceDetail", b =>
                {
                    b.Property<long>("ServiceDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ServiceDetailID"));

                    b.Property<long>("InvoiceID")
                        .HasColumnType("bigint");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("ServiceID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ServiceDetailID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ServiceID");

                    b.ToTable("ServiceDetails");

                    b.HasData(
                        new
                        {
                            ServiceDetailID = 1L,
                            InvoiceID = 1L,
                            Quantity = 12,
                            ServiceID = 1L,
                            TotalAmount = 3000m
                        },
                        new
                        {
                            ServiceDetailID = 2L,
                            InvoiceID = 1L,
                            Quantity = 15,
                            ServiceID = 2L,
                            TotalAmount = 5000m
                        },
                        new
                        {
                            ServiceDetailID = 3L,
                            InvoiceID = 2L,
                            Quantity = 26,
                            ServiceID = 1L,
                            TotalAmount = 3000m
                        },
                        new
                        {
                            ServiceDetailID = 4L,
                            InvoiceID = 2L,
                            Quantity = 10,
                            ServiceID = 2L,
                            TotalAmount = 5000m
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Staff", b =>
                {
                    b.Property<long>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StaffID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)");

                    b.Property<byte>("RoleID")
                        .HasColumnType("tinyint");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("StaffID");

                    b.ToTable("Staffs");

                    b.HasData(
                        new
                        {
                            StaffID = 1L,
                            Address = "Quận Tân Bình, TP.HCM",
                            Birthday = new DateTime(2003, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "2154810035@vaa.edu.vn",
                            Gender = true,
                            Password = "password",
                            Phone = "1234567890",
                            RoleID = (byte)1,
                            StaffName = "Phát",
                            Status = true
                        },
                        new
                        {
                            StaffID = 2L,
                            Address = "Quận Thủ Đức, TP.HCM",
                            Birthday = new DateTime(2003, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "2154810027@vaa.edu.vn",
                            Gender = true,
                            Password = "password",
                            Phone = "1234567890",
                            RoleID = (byte)1,
                            StaffName = "Minh",
                            Status = true
                        },
                        new
                        {
                            StaffID = 3L,
                            Address = "Quận Tân Bình, TP.HCM",
                            Birthday = new DateTime(2003, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "2154810045@vaa.edu.vn",
                            Gender = true,
                            Password = "password",
                            Phone = "1234567890",
                            RoleID = (byte)1,
                            StaffName = "Dũng",
                            Status = true
                        },
                        new
                        {
                            StaffID = 4L,
                            Address = "Quận 5, TP.HCM",
                            Birthday = new DateTime(2003, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "2154810015@vaa.edu.vn",
                            Gender = false,
                            Password = "password",
                            Phone = "1234567890",
                            RoleID = (byte)3,
                            StaffName = "Trúc Shiba Bếu",
                            Status = true
                        },
                        new
                        {
                            StaffID = 5L,
                            Address = "Quận Tân Phú, TP.HCM",
                            Birthday = new DateTime(2003, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "2154810103@vaa.edu.vn",
                            Password = "password",
                            Phone = "1234567890",
                            RoleID = (byte)2,
                            StaffName = "Bảo",
                            Status = true
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Tenant", b =>
                {
                    b.Property<long>("TenantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TenantID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nchar(12)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("Date");

                    b.Property<long>("RoomID")
                        .HasColumnType("bigint");

                    b.HasKey("TenantID");

                    b.HasIndex("RoomID");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            TenantID = 1L,
                            Address = "Sao Mộc, Ngân hà dũ trụ",
                            Birthday = new DateTime(2003, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CCCD = "072307489013",
                            FullName = "Shiba Bếu",
                            Gender = false,
                            JoinDate = new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 2L
                        },
                        new
                        {
                            TenantID = 2L,
                            Address = "Quận Sao Kim, TP.Mộc Tinh",
                            Birthday = new DateTime(2003, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CCCD = "075307592016",
                            FullName = "Minh Ẩn Danh",
                            Gender = true,
                            JoinDate = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 4L
                        });
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Contract", b =>
                {
                    b.HasOne("Project_Phòng_Trọ.Models.Room", "Room")
                        .WithMany("Contracts")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Phòng_Trọ.Models.Staff", "Staffs")
                        .WithMany("Contracts")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.HistoryInvoices", b =>
                {
                    b.HasOne("Project_Phòng_Trọ.Models.Invoices", "Invoices")
                        .WithMany("HistoryInvoices")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Invoices", b =>
                {
                    b.HasOne("Project_Phòng_Trọ.Models.Room", "Room")
                        .WithMany("Invoices")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.ServiceDetail", b =>
                {
                    b.HasOne("Project_Phòng_Trọ.Models.Invoices", "Invoices")
                        .WithMany("ServiceDetail")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Phòng_Trọ.Models.Service", "Service")
                        .WithMany("ServiceDetails")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoices");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Tenant", b =>
                {
                    b.HasOne("Project_Phòng_Trọ.Models.Room", "Room")
                        .WithMany("Tenants")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Invoices", b =>
                {
                    b.Navigation("HistoryInvoices");

                    b.Navigation("ServiceDetail");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Room", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Invoices");

                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Service", b =>
                {
                    b.Navigation("ServiceDetails");
                });

            modelBuilder.Entity("Project_Phòng_Trọ.Models.Staff", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
