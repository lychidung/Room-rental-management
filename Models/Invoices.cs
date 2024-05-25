using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_Phòng_Trọ.Models
{
    [PrimaryKey(nameof(InvoiceID))]
    internal class Invoices
    {
        public Invoices() 
        {
            this.ServiceDetail = new HashSet<ServiceDetail>();
            this.HistoryInvoices = new HashSet<HistoryInvoices>();
        }
        public long InvoiceID { get; set; }

        [ForeignKey(nameof(Room))]
        public long RoomID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        public bool Status { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<ServiceDetail> ServiceDetail { get; set; }
        public virtual ICollection<HistoryInvoices> HistoryInvoices { get; set; }
    }
}
