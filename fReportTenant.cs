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
    public partial class fReportTenant : Form
    {
        EFDbContext db = new EFDbContext();
        ReportViewer reportViewer;
        public fReportTenant()
        {
            InitializeComponent();
        }

        private void fReportTenant_Load(object sender, EventArgs e)
        {
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
            };
            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("ds_Tenant", db.Tenants.Select(p => new
            {
                p.TenantID,
                p.RoomID,
                p.FullName,
                p.CCCD,
                p.Gender,
                p.Birthday,
                p.Address,
                p.JoinDate
            }).ToList()));

            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\rTenant.rdlc";
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
