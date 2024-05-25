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
    public partial class fReportMain : Form
    {
        public fReportMain()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            fReportRoom fReportRoom = new fReportRoom();
            fReportRoom.ShowDialog();
        }

        private void fReportMain_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fReportStaff fReportStaff = new fReportStaff();
            fReportStaff.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            fReportInvoice fReportInvoice = new fReportInvoice();
            fReportInvoice.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            fReportRoomChart fReportRoomChart = new fReportRoomChart();
            fReportRoomChart.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            fReportStaffGroup fReportStaffGroup = new fReportStaffGroup();
            fReportStaffGroup.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            fReportTenant fReportTenant = new fReportTenant();
            fReportTenant.ShowDialog();
        }
    }
}
