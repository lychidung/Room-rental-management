using Microsoft.EntityFrameworkCore;
using Project_Phòng_Trọ.Models;
using Project_Phòng_Trọ.Uc_Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Project_Phòng_Trọ
{
    public partial class Admin : Form
    {

        private Room room;

        public Admin()
        {
            InitializeComponent();

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            fReportMain fReportMain = new fReportMain();
            fReportMain.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            fContract fContract = new fContract();
            fContract.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            fService fService = new fService();
            fService.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            fTenant fTenant = new fTenant();
            fTenant.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            var db = new EFDbContext();
            var allRooms = db.Rooms.ToList();
            Uc_Item.UC_Header uC_Tab_Room = new Uc_Item.UC_Header();
            flowLayoutPanel2.Controls.Add(uC_Tab_Room);
            foreach (var room in allRooms)
            {
                Uc_Item.UC_Card_Room ucCardRoom = new Uc_Item.UC_Card_Room(room.RoomName.ToString(), room.Status, room.RoomID);
                flowLayoutPanel1.Controls.Add(ucCardRoom);

            }
            guna2Button2.Checked = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        public void Admin_Load(object sender, EventArgs e)
        {
            guna2Button2_Click(sender, e);
        }

        public void LoadListFormWhenClosefNewRoom()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            var db = new EFDbContext();
            var allRooms = db.Rooms.ToList();
            Uc_Item.UC_Header uC_Tab_Room = new Uc_Item.UC_Header();
            flowLayoutPanel2.Controls.Add(uC_Tab_Room);
            foreach (var room in allRooms)
            {
                Uc_Item.UC_Card_Room ucCardRoom = new Uc_Item.UC_Card_Room(room.RoomName.ToString(), room.Status, room.RoomID);
                flowLayoutPanel1.Controls.Add(ucCardRoom);

            }
            guna2Button2.Checked = true;
            MessageBox.Show("Sadsa");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            fStaff fstaff = new fStaff();
            fstaff.ShowDialog();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
