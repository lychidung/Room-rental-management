using Guna.UI2.WinForms;
using Project_Phòng_Trọ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Phòng_Trọ
{
    public partial class fNewRoom : Form
    {
        public event EventHandler FormClosedEvent;

        Room room;
        public fNewRoom()
        {
            InitializeComponent();
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals(""))
            {
                guna2MessageDialog2.Show("Vui lòng nhập tên phòng");
            }
            else
            {
                try
                {
                    room = new Room();
                    var db1 = new EFDbContext();
                    room.RoomName = txtName.Text;
                    room.Area = nrArea.Value;
                    room.RoomPrice = nrPrice.Value;

                    db1.Rooms.Add(room);
                    db1.SaveChanges();
                    guna2MessageDialog1.Show("Thêm phòng thành công: " + room.RoomName);
                    fNewRoom_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra !");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void fNewRoom_Load(object sender, EventArgs e)
        {
            txtName.Text = null;

            nrArea.Value = 0;
            nrPrice.Value = 0;
            cbRoom.DisplayMember = "RoomName";
            cbRoom.ValueMember = "RoomID";

            var db1 = new EFDbContext();
            cbRoom.DataSource = db1.Rooms.Select(c => new
            {
                c.RoomName,
                c.RoomID,
            }).ToList();
            cbRoom.SelectedIndex = -1;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (cbRoom.SelectedIndex == -1)
            {
                guna2MessageDialog2.Show("Vui lòng chọn phòng cần xóa ");
            }
            else
            {
                try
                {
                    var db = new EFDbContext();
                    Room room = db.Rooms.Single(c => c.RoomID == Convert.ToInt64(cbRoom.SelectedValue));
                    if (guna2MessageDialog3.Show("Bạn muốn xóa phòng?: " + room.RoomName) == DialogResult.Yes)
                    {
                        db.Rooms.Remove(room);
                        db.SaveChanges();
                        //RoomDetails_Activated(sender, e);
                        guna2MessageDialog1.Show("Xóa thành công phòng: " + room.RoomName);
                        cbRoom.SelectedIndex = -1;
                        fNewRoom_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void fNewRoom_FormClosed(object sender, FormClosedEventArgs e)
        {

        }



        public void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
        }
    }
}
