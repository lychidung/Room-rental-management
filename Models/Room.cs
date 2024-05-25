using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_Phòng_Trọ.Models
{
    [PrimaryKey(nameof(RoomID))]
    internal class Room
    {
        public Room() 
        {
            this.Contracts = new HashSet<Contract>();
            this.Invoices = new HashSet<Invoices>();
            this.Tenants = new HashSet<Tenant>();
        }

        public long RoomID { get; set; }

        [StringLength(100)]
        public string RoomName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RoomPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Area { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
