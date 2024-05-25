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
    [PrimaryKey(nameof(ServiceID))]
    internal class Service
    {
        public Service() 
        {
            this.ServiceDetails = new HashSet<ServiceDetail>();
        }

        public long ServiceID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [StringLength(100)]
        public string ServiceName { get; set; }

        [StringLength(200)]
        public string? ImageFile { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}
