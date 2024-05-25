using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Phòng_Trọ.Uc_Item
{
    public partial class UC_Header : UserControl
    {
        public UC_Header()
        {
            InitializeComponent();
            guna2ComboBox1.Text = "Tất cả";
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedValue = guna2ComboBox1.SelectedItem.ToString();

            if (selectedValue == "Hoạt động")
            {
                var db = new EFDbContext();
                var roomSelect = db.Rooms.Where(d => d.Status == true).ToList();
                Control parentControl = this.Parent;
                while (parentControl != null && !(parentControl is Admin))
                {
                    parentControl = parentControl.Parent;
                }
                if (parentControl != null)
                {
                    // Form Admin đã được tìm thấy
                    Admin adminForm = (Admin)parentControl;

                    // Lấy flowLayoutPanel1 từ Form Admin
                    FlowLayoutPanel flowLayoutPanel1 = adminForm.flowLayoutPanel1;
                    flowLayoutPanel1.Controls.Clear();
                    foreach (var room in roomSelect)
                    {
                        Uc_Item.UC_Card_Room ucCardRoom = new Uc_Item.UC_Card_Room(room.RoomName.ToString(), room.Status, room.RoomID);
                        flowLayoutPanel1.Controls.Add(ucCardRoom);
                    }
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra ! 1");
                }



            }
            else if (selectedValue == "Đang trống")
            {
                var db = new EFDbContext();
                var roomSelect = db.Rooms.Where(d => d.Status == false).ToList();
                Control parentControl = this.Parent;
                while (parentControl != null && !(parentControl is Admin))
                {
                    parentControl = parentControl.Parent;
                }
                if (parentControl != null)
                {
                    // Form Admin đã được tìm thấy
                    Admin adminForm = (Admin)parentControl;

                    // Lấy flowLayoutPanel1 từ Form Admin
                    FlowLayoutPanel flowLayoutPanel1 = adminForm.flowLayoutPanel1;
                    flowLayoutPanel1.Controls.Clear();
                    foreach (var room in roomSelect)
                    {
                        Uc_Item.UC_Card_Room ucCardRoom = new Uc_Item.UC_Card_Room(room.RoomName.ToString(), room.Status, room.RoomID);
                        flowLayoutPanel1.Controls.Add(ucCardRoom);
                    }
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra ! 2");
                }
            }
            else if (selectedValue == "Tất cả")
            {
                var db = new EFDbContext();
                var roomSelect = db.Rooms.ToList();
                Control parentControl = this.Parent;
                while (parentControl != null && !(parentControl is Admin))
                {
                    parentControl = parentControl.Parent;
                }
                if (parentControl != null)
                {
                    // Form Admin đã được tìm thấy
                    Admin adminForm = (Admin)parentControl;

                    // Lấy flowLayoutPanel1 từ Form Admin
                    FlowLayoutPanel flowLayoutPanel1 = adminForm.flowLayoutPanel1;
                    flowLayoutPanel1.Controls.Clear();
                    foreach (var room in roomSelect)
                    {
                        Uc_Item.UC_Card_Room ucCardRoom = new Uc_Item.UC_Card_Room(room.RoomName.ToString(), room.Status, room.RoomID);
                        flowLayoutPanel1.Controls.Add(ucCardRoom);
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fNewRoom fNewRoom = new fNewRoom();
            fNewRoom.ShowDialog();
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text.Equals(""))
            {
                Admin admin = new Admin();
                admin.guna2MessageDialog1.Show("Vui lòng nhập tên phòng cần tìm !!");
            }
            else
            {
                var db = new EFDbContext();
                var roomFind = db.Rooms.Where(t => t.RoomName.ToLower().Contains(txtFind.Text))
                    .Select(t => new
                    {
                        RoomName = t.RoomName,
                        RoomID = t.RoomID,
                        Price = t.RoomPrice,
                        Area = t.Area,
                        Status = t.Status,
                    });
                Control parentControl = this.Parent;
                while (parentControl != null && !(parentControl is Admin))
                {
                    parentControl = parentControl.Parent;
                }
                if (parentControl != null)
                {
                    // Form Admin đã được tìm thấy
                    Admin adminForm = (Admin)parentControl;

                    // Lấy flowLayoutPanel1 từ Form Admin
                    FlowLayoutPanel flowLayoutPanel1 = adminForm.flowLayoutPanel1;
                    flowLayoutPanel1.Controls.Clear();
                    foreach (var room in roomFind)
                    {
                        Uc_Item.UC_Card_Room ucCardRoom = new Uc_Item.UC_Card_Room(room.RoomName.ToString(), room.Status, room.RoomID);
                        flowLayoutPanel1.Controls.Add(ucCardRoom);
                    }
                }
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
