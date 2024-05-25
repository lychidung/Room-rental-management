using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project_Phòng_Trọ.Models;

namespace Project_Phòng_Trọ
{
    internal class EFDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<HistoryInvoices> HistoryInvoices { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }

        public void ConfigurServices(IServiceCollection services) => services.AddDbContext<EFDbContext>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(
            new Staff
            {
                StaffID = 1,
                StaffName = "Phát",
                Email = "2154810035@vaa.edu.vn",
                Password = "password",
                Birthday = DateTime.Parse("2003-01-29"),
                Phone = "1234567890",
                Address = "Quận Tân Bình, TP.HCM",
                Avatar = null,
                Status = true,
                Gender = true,
                RoleID = 1
            },
            new Staff
            {
                StaffID = 2,
                StaffName = "Minh",
                Email = "2154810027@vaa.edu.vn",
                Password = "password",
                Birthday = DateTime.Parse("2003-09-29"),
                Phone = "1234567890",
                Address = "Quận Thủ Đức, TP.HCM",
                Avatar = null,
                Status = true,
                Gender = true,
                RoleID = 1
            },
            new Staff
            {
                StaffID = 3,
                StaffName = "Dũng",
                Email = "2154810045@vaa.edu.vn",
                Password = "password",
                Birthday = DateTime.Parse("2003-05-29"),
                Phone = "1234567890",
                Address = "Quận Tân Bình, TP.HCM",
                Avatar = null,
                Status = true,
                Gender = true,
                RoleID = 1
            },
            new Staff
            {
                StaffID = 4,
                StaffName = "Trúc Shiba Bếu",
                Email = "2154810015@vaa.edu.vn",
                Password = "password",
                Birthday = DateTime.Parse("2003-04-29"),
                Phone = "1234567890",
                Address = "Quận 5, TP.HCM",
                Avatar = null,
                Status = true,
                Gender = false,
                RoleID = 3
            },
            new Staff
            {
                StaffID = 5,
                StaffName = "Bảo",
                Email = "2154810103@vaa.edu.vn",
                Password = "password",
                Birthday = DateTime.Parse("2003-03-29"),
                Phone = "1234567890",
                Address = "Quận Tân Phú, TP.HCM",
                Avatar = null,
                Status = true,
                Gender = null,
                RoleID = 2
            });
            modelBuilder.Entity<Room>().HasData(
            new Room
            {
                RoomID = 1,
                RoomName = "Phòng 101",
                RoomPrice = 1500000,
                Area = 5,
                Status = false
            },
            new Room
            {
                RoomID = 2,
                RoomName = "Phòng 102",
                RoomPrice = 3000000,
                Area = 10,
                Status = true
            },
            new Room
            {
                RoomID = 3,
                RoomName = "Phòng 103",
                RoomPrice = 4500000,
                Area = 15,
                Status = false
            },
            new Room
            {
                RoomID = 4,
                RoomName = "Phòng 104",
                RoomPrice = 55000000,
                Area = 30,
                Status = true
            },
            new Room
            {
                RoomID = 5,
                RoomName = "Phòng 105",
                RoomPrice = 35000000,
                Area = 12,
                Status = false
            },
            new Room
            {
                RoomID = 6,
                RoomName = "Phòng 106",
                RoomPrice = 2000000,
                Area = 7,
                Status = false
            });
            modelBuilder.Entity<Tenant>().HasData(
            new Tenant
            {
                TenantID = 1,
                RoomID = 2,
                FullName = "Shiba Bếu",
                CCCD = "072307489013",
                Gender = false,
                JoinDate = DateTime.Parse("2023-11-11"),
                Birthday = DateTime.Parse("2003-01-11"),
                Address = "Sao Mộc, Ngân hà dũ trụ"
            },
            new Tenant
            {
                TenantID = 2,
                RoomID = 4,
                FullName = "Minh Ẩn Danh",
                CCCD = "075307592016",
                Gender = true,
                JoinDate = DateTime.Parse("2023-11-01"),
                Birthday = DateTime.Parse("2003-05-09"),
                Address = "Quận Sao Kim, TP.Mộc Tinh"
            });
            modelBuilder.Entity<Service>().HasData(
            new Service
            {
                ServiceID = 1,
                ServiceName = "Điện",
                Price = 3000,
                ImageFile = null,
                CreateDate = DateTime.Parse("2000-12-12")
            },
            new Service
            {
                ServiceID = 2,
                ServiceName = "Nước",
                Price = 5000,
                ImageFile = null,
                CreateDate = DateTime.Parse("2000-12-12")
            },
            new Service
            {
                ServiceID = 3,
                ServiceName = "Rác thải",
                Price = 50000,
                ImageFile = null,
                CreateDate = DateTime.Parse("2000-12-12")
            },
            new Service
            {
                ServiceID = 4,
                ServiceName = "Internet",
                Price = 220000,
                ImageFile = null,
                CreateDate = DateTime.Parse("2001-10-12")
            });
            modelBuilder.Entity<Invoices>().HasData(
            new Invoices
            {
                InvoiceID = 1,
                RoomID = 2,
                CreateDate = DateTime.Parse("2023-11-11"),
                EndDate = DateTime.Parse("2023-12-11"),
                TotalAmount = 1900000,
                Status = true
            },
            new Invoices
            {
                InvoiceID = 2,
                RoomID = 4,
                CreateDate = DateTime.Parse("2023-11-01"),
                EndDate = DateTime.Parse("2023-12-01"),
                TotalAmount = 4000000,
                Status = true
            });
            modelBuilder.Entity<HistoryInvoices>().HasData(
            new HistoryInvoices
            {
                HistoryInvoicesID = 1,
                InvoiceID = 1,
                PayDate = DateTime.Parse("2023-12-11")
            },
            new HistoryInvoices
            {
                HistoryInvoicesID = 2,
                InvoiceID = 2,
                PayDate = DateTime.Parse("2023-12-03")
            });
            modelBuilder.Entity<Contract>().HasData(
            new Contract
            {
                ContractID = 1,
                RoomID = 2,
                StaffID = 2,
                CreateDate = DateTime.Parse("2023-11-11"),
                EndDate = DateTime.Parse("2023-12-11"),
                TotalAmount = 3000000,
                Status = true
            },
            new Contract
            {
                ContractID = 2,
                RoomID = 4,
                StaffID = 4,
                CreateDate = DateTime.Parse("2023-11-01"),
                EndDate = DateTime.Parse("2023-12-01"),
                TotalAmount = 55000000,
                Status = true
            });
            modelBuilder.Entity<ServiceDetail>().HasData(
            new ServiceDetail
            {
                ServiceDetailID = 1,
                InvoiceID = 1,
                ServiceID = 1,
                TotalAmount = 3000,
                Quantity = 12
            },
            new ServiceDetail
            {
                ServiceDetailID = 2,
                InvoiceID = 1,
                ServiceID = 2,
                TotalAmount = 5000,
                Quantity = 15
            }, 
            new ServiceDetail
            {
                ServiceDetailID = 3,
                InvoiceID = 2,
                ServiceID = 1,
                TotalAmount = 3000,
                Quantity = 26
            },
            new ServiceDetail
            {
                ServiceDetailID = 4,
                InvoiceID = 2,
                ServiceID = 2,
                TotalAmount = 5000,
                Quantity = 10
            });
        }
    }
}
