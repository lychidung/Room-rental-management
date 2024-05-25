using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Phòng_Trọ
{
    public partial class fReportInvoice : Form
    {
        EFDbContext db = new EFDbContext();
        ReportViewer reportViewer;
        public fReportInvoice()
        {
            InitializeComponent();
        }

        private void fReportInvoice_Load(object sender, EventArgs e)
        {
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
            };
            var serv = (from r in db.Rooms
                        join iv in db.Invoices on r.RoomID equals iv.RoomID
                        join te in db.Tenants on r.RoomID equals te.RoomID
                        select new
                        {
                            iv.RoomID,
                            iv.InvoiceID,
                            iv.CreateDate,
                            iv.EndDate,
                            iv.Status,
                            iv.TotalAmount,
                            TenantName = te.FullName
                        });
            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("ds_Invoice", serv.ToList()));

            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\rInvoice.rdlc";
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}