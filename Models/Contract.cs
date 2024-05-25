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
    [PrimaryKey(nameof(ContractID))]
    internal class Contract
    {
        public long ContractID { get; set; }

        [ForeignKey(nameof(Room))]
        public long RoomID { get; set; }

        [ForeignKey(nameof(Staffs))]
        public long StaffID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        public bool Status { get; set; }

        public virtual Room Room { get; set; }
        public virtual Staff Staffs { get; set; }
    }
}
