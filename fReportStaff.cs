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
    public partial class fReportStaff : Form
    {
        EFDbContext db = new EFDbContext();
        ReportViewer reportViewer;
        Dictionary<long, string> roleID = new Dictionary<long, string>
        {
            { 1, "Quản lý" },
            { 2, "Nhân viên" },
            { 3, "Nhân viên mới" }
        };
        public fReportStaff()
        {
            InitializeComponent();
        }

        private void fReportStaff_Load(object sender, EventArgs e)
        {
            reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
            };
            using (var db = new EFDbContext())
            {
                cbCheckStaff.DisplayMember = "RoleName";
                cbCheckStaff.ValueMember = "RoleID";
                cbCheckStaff.DataSource = db.Staffs.Select(s => new
                {
                   s.RoleID,
                   RoleName = roleID[s.RoleID]
                }).Distinct().ToList();
                cbCheckStaff.Text = null;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbCheckStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new EFDbContext())
            {
                long RoleID = Convert.ToInt64(cbCheckStaff.SelectedValue);
                reportViewer.Reset();
                reportViewer.LocalReport.DataSources.Add(new
               ReportDataSource("ds_Staff", db.Staffs.Where(p => p. RoleID == RoleID ||
               cbCheckStaff.SelectedIndex < 0).Select(p => new
               {
                   p.StaffID,
                   p.StaffName,
                   p.Password,
                   p.Gender,
                   p.Birthday,
                   p.Phone,
                   p.Address,
                   p.Email,
                   p.Status,
                   p.RoleID,
                   p.Avatar
               }).ToList()));
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +"\\rStaff.rdlc";
                Controls.Add(reportViewer);
                reportViewer.RefreshReport();
            }
        }
    }
}
