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
    [PrimaryKey(nameof(TenantID))]
    internal class Tenant
    {
        public long TenantID {  get; set; }

        [ForeignKey(nameof(Room))]
        public long RoomID { get; set; }

        [StringLength(12, MinimumLength = 12), Column(TypeName = "nchar(12)")]
        public string CCCD { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public bool? Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime JoinDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public virtual Room Room { get; set; }
    }
}
