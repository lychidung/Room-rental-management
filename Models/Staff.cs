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
    [PrimaryKey(nameof(StaffID))]
    internal class Staff
    {
        public Staff()
        {
            this.Contracts = new HashSet<Contract>();
        }
        public long StaffID { get; set; }

        [StringLength(100)]
        public string StaffName { get; set; }

        [StringLength(18)]
        public string Password { get; set; }

        public bool? Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }

        [StringLength(10, MinimumLength = 10), Column(TypeName = "nchar(10)")]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }

        public bool Status { get; set; }

        public byte RoleID { get; set; }

        [StringLength(200)]
        public string? Avatar { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
