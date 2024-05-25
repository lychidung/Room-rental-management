using Microsoft.EntityFrameworkCore;
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
    public partial class fReportRoomChart : Form
    {
        EFDbContext db = new EFDbContext();
        public fReportRoomChart()
        {
            InitializeComponent();
        }

        private void fReportRoom_Load(object sender, EventArgs e)
        {
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
            };

            var sql = (from r in db.Rooms
                       join iv in db.Invoices on r.RoomID equals iv.RoomID
                       select new
                       {
                           r.RoomID,
                           r.RoomName,
                           r.RoomPrice,
                           r.Area,
                           r.Status,
                           TotalAmount = iv.TotalAmount,
                           InvoiceID = iv.InvoiceID
                       });

            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("ds_Room_Chart", sql.ToList()));

            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\rRoomInvoice.rdlc";
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
