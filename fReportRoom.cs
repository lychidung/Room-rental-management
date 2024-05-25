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
    public partial class fReportRoom : Form
    {
        EFDbContext db = new EFDbContext();
        ReportViewer reportViewer;
        public fReportRoom()
        {
            InitializeComponent();
        }

        private void fReportRoom_Load(object sender, EventArgs e)
        {
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
            };
            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("ds_Room", db.Rooms.Select(p => new
            {
                p.RoomID,
                p.RoomName,
                p.RoomPrice,
                p.Area,
                p.Status
            }).ToList()));

            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\rRoom.rdlc";
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
