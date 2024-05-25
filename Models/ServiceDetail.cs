using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_Phòng_Trọ.Models
{
    [PrimaryKey(nameof(ServiceDetailID))]
    internal class ServiceDetail
    {
        public long ServiceDetailID { get; set; }

        [ForeignKey(nameof(Invoices))]
        public long InvoiceID { get; set; }

        [ForeignKey(nameof(Service))]
        public long ServiceID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        public int? Quantity { get; set; }

        public virtual Invoices Invoices { get; set; }
        public virtual Service Service { get; set; }
    }
}
