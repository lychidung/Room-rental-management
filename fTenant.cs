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
using System.Xml.Linq;

namespace Project_Phòng_Trọ
{
    public partial class fTenant : Form
    {

        Tenant tenant;
        EFDbContext db = new EFDbContext();
        public fTenant()
        {
            InitializeComponent();
            LoadTenantData();
            this.tenant = new Tenant();
        }

        private void LoadTenantData()
        {
            try
            {
                using (var db = new EFDbContext())
                {
                    dataGridView1.DataSource = db.Tenants.Select(s => new
                    {
                        s.TenantID,
                        s.RoomID,
                        s.JoinDate,
                        s.Address,
                        s.Birthday,
                        s.CCCD,
                        s.Gender,
                        s.FullName,
                    }).ToList();

                    cbRoomID.DisplayMember = "RoomName";
                    cbRoomID.ValueMember = "RoomID";
                    cbRoomID.DataSource = db.Rooms.Select(r => new { r.RoomID, r.RoomName }).ToList();


                    var tenants = db.Tenants.ToList();

                    dataGridView1.Columns["TenantID"].DisplayIndex = 0;
                    dataGridView1.Columns["RoomID"].DisplayIndex = 1;
                    dataGridView1.Columns["FullName"].DisplayIndex = 2;
                    dataGridView1.Columns["CCCD"].DisplayIndex = 3;
                    dataGridView1.Columns["Birthday"].DisplayIndex = 4;
                    dataGridView1.Columns["Address"].DisplayIndex = 5;
                    dataGridView1.Columns["Gender"].DisplayIndex = 6;
                    dataGridView1.Columns["JoinDate"].DisplayIndex = 7;

                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tenant = new Tenant();
                tenant.FullName = txtFullName.Text;
                tenant.Birthday = DateTime.Now;
                tenant.Address = txtAddress.Text;
                tenant.CCCD = txtCCCD.Text;
                tenant.RoomID = Convert.ToInt32(cbRoomID.SelectedValue);
                tenant.JoinDate = DateTime.Now;
                tenant.Gender = ckGender.CheckState == CheckState.Indeterminate ? (bool?)null : ckGender.Checked;
                using (var db = new EFDbContext())
                {
                    db.Tenants.Add(tenant);
                    db.SaveChanges();
                }

                LoadTenantData();

                txtFullName.Text = null;
                txtAddress.Text = null;
                txtCCCD.Text = null;
                cbRoomID.SelectedIndex = 0;
                ckGender.CheckState = CheckState.Indeterminate;
                toolTip1.Show("Thêm thành công!", btAdd, 0, 0, 1000);
            }
            catch (Exception ex)
            {
                toolTip1.Show("Thêm thất bại? Error: " + ex.Message, btAdd, 0, 0, 1000);
            }
            txtFullName.Focus();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int tenantID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TenantID"].Value);
                tenant = db.Tenants.FirstOrDefault(t => t.TenantID == tenantID);
                tenant.FullName = txtFullName.Text;
                tenant.Address = txtAddress.Text;
                tenant.CCCD = txtCCCD.Text;
                tenant.Birthday = tenant.Birthday = dtBirthday.Value;
                tenant.RoomID = Convert.ToInt32(cbRoomID.SelectedValue);
                tenant.Gender = ckGender.CheckState == CheckState.Indeterminate ? (bool?)null : ckGender.Checked;

                db.SaveChanges();

                LoadTenantData();

                toolTip1.Show("Cập nhật thành công!", btEdit, 0, 0, 1000);
            }
            catch (Exception ex)
            {
                toolTip1.Show("Cập nhật thất bại? Error: " + ex.Message, btEdit, 0, 0, 1000);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int tenantID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TenantID"].Value);

                    using (var db = new EFDbContext())
                    {
                        Tenant tenant = db.Tenants.Single(c => c.TenantID == tenantID);

                        if (MessageBox.Show("Bạn muốn xóa khách hàng " + tenant.FullName + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.Tenants.Remove(tenant);
                            db.SaveChanges();
                            LoadTenantData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();

                if (row.Cells["Gender"].Value != null)
                {
                    bool genderValue = Convert.ToBoolean(row.Cells["Gender"].Value);

                    ckGender.Checked = genderValue;
                }

                if (DateTime.TryParse(row.Cells["Birthday"].Value.ToString(), out DateTime birthday))
                {
                    dtBirthday.Value = birthday;
                }

                if (DateTime.TryParse(row.Cells["JoinDate"].Value.ToString(), out DateTime joinDate))
                {
                    dtJoinDate.Value = joinDate;
                }

                string roomIDText = row.Cells["RoomID"].Value.ToString();

                if (int.TryParse(roomIDText, out int roomId))
                {
                    cbRoomID.SelectedIndex = roomId - 1;
                }
            }
        }
    }
}