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
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Project_Phòng_Trọ
{
    public partial class fNewTenantsForRoom : Form
    {
        Room room;
        Tenant tenant;
        long TenantID;
        EFDbContext db = new EFDbContext();

        //Nếu kiemtra = false thì là form nhập, nếu kiemtra = true là form chỉnh sữa
        bool kiemtra = false;

        public fNewTenantsForRoom()
        {
            InitializeComponent();
        }

        public fNewTenantsForRoom(long Tenant)
        {
            InitializeComponent();
            this.TenantID = Tenant;
            this.kiemtra = true;
        }


        private void fNewTenantsForRoom_Load(object sender, EventArgs e)
        {
            cbRoom.DisplayMember = "RoomName";
            cbRoom.ValueMember = "RoomID";

            var db1 = new EFDbContext();
            cbRoom.DataSource = db1.Rooms.Select(c => new
            {
                c.RoomName,
                c.RoomID,
            }).ToList();



            if (kiemtra == true)
            {
                //var db = new EFDbContext();
                //tenant = new Tenant();
                tenant = db.Tenants.Single(o => o.TenantID == TenantID);
                cbRoom.SelectedValue = tenant.RoomID;
                txtName.Text = tenant.FullName;
                txtAddress.Text = tenant.Address;
                txtCC.Text = tenant.CCCD;
                if (tenant.Gender.HasValue)
                {
                    cbGender.SelectedItem = tenant.Gender.Value ? "Nam" : "Nữ";
                }
                timeBirthday.Text = tenant.Birthday.ToString();

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbRoom.Text))
            {
                toolTip1.Show("Hãy chọn số phòng?", cbRoom, 0, 0, 1000);
                cbRoom.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                toolTip1.Show("Hãy tên người cư trú?", txtName, 0, 0, 1000);
                cbRoom.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cbGender.Text))
            {
                toolTip1.Show("Hãy chọn giới tính?", cbGender, 0, 0, 1000);
                cbRoom.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(timeBirthday.Text))
            {
                toolTip1.Show("Hãy chọn ngày tháng năm sinh?", timeBirthday, 0, 0, 1000);
                cbRoom.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                toolTip1.Show("Hãy nhập địa chỉ?", txtAddress, 0, 0, 1000);
                cbRoom.Focus();
                return;
            }


            try
            {
                if(!kiemtra) tenant = new Tenant();
                tenant.RoomID = Convert.ToInt64(cbRoom.SelectedValue);
                tenant.FullName = txtName.Text;
                tenant.CCCD = txtCC.Text;
                if (cbGender.SelectedItem == "Nam")
                {
                    tenant.Gender = true;
                }
                else
                {
                    tenant.Gender = false;
                }
                tenant.Birthday = timeBirthday.Value;
                tenant.Address = txtAddress.Text;
                if(!kiemtra)
                {
                    var db1 = new EFDbContext();
                    db1.Tenants.Add(tenant);

                    long ID = Convert.ToInt64(cbRoom.SelectedValue);
                    Room roomToUpdate = db1.Rooms.SingleOrDefault(r => r.RoomID == ID);
                    roomToUpdate.Status = true;

                    db1.Rooms.Add(roomToUpdate);

                    db1.SaveChanges();
                    //txtName = null;
                    //txtAddress = null;
                    //txtCC = null;
                    //cbGender = null;
                    //timeBirthday = null;
                    //txtAddress = null;
                    tenant.RoomID = Convert.ToInt64(cbRoom.SelectedValue);
                    tenant.FullName = txtName.Text;
                    tenant.CCCD = txtCC.Text;
                    if (cbGender.SelectedItem == "Nam")
                    {
                        tenant.Gender = true;
                    }
                    else
                    {
                        tenant.Gender = false;
                    }
                    tenant.Birthday = timeBirthday.Value;
                    tenant.Address = txtAddress.Text;
                }
                else
                {
                    Close();
                    db.SaveChanges();
                }
                toolTip1.Show("Lưu thành công.", guna2Button1, 0, 0, 1000);
            }


            catch (Exception ex)
            {
                toolTip1.Show("Lưu thất bại." + ex, guna2Button1, 0, 0, 1000);

            }


        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
