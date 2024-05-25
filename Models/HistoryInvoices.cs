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
    [PrimaryKey(nameof(HistoryInvoicesID))]
    internal class HistoryInvoices
    {
        public long HistoryInvoicesID { get; set; }

        [ForeignKey(nameof(Invoices))]
        public long InvoiceID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PayDate { get; set; }

        public virtual Invoices Invoices { get; set; }
    }
}
