using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Project_Phòng_Trọ.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Phòng_Trọ
{
    public partial class fStaff : Form
    {
        Staff staff;
        EFDbContext db = new EFDbContext();
        public fStaff()
        {
            InitializeComponent();
        }

        private void LoadStaff()
        {
            var db = new EFDbContext();
            DataGridView1.DataSource = db.Staffs.Select(s => new
            {
                s.StaffID,
                s.StaffName,
                s.Password,
                s.Birthday,
                s.Address,
                s.Email,
                s.Phone,
                s.Avatar,
                s.RoleID,
                s.Gender,
                s.Status
            }).ToList();
            DataGridView1.ClearSelection();
        }

        private void clearText()
        {
            lblID.Text = null;
            txtStaffName.Text = null;
            txtPassword.Text = null;
            txtAddress.Text = null;
            dtPickerBirthday.Text = DateTime.UtcNow.ToString();
            txtEmail.Text = null;
            cbRole.Text = null;
            checkGender.Checked = true;
            txtPhone.Text = null;
            checkStatus.Checked = true;
            txtAvatar.Text = null;
            PictureBox1.ImageLocation = null;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fStaff_Activated(object sender, EventArgs e)
        {

        }

        internal void UpdateLabel(Staff d)
        {
            lblID.Text = d.StaffID.ToString();
            txtStaffName.Text = d.StaffName.ToString();
            dtPickerBirthday.Text = d.Birthday.ToShortDateString();
            txtPassword.Text = d.Password.ToString();
            txtAddress.Text = d.Address.ToString();
            txtEmail.Text = d.Email.ToString();
            txtPhone.Text = d.Phone.ToString();
            txtAvatar.Text = Utility.ImagePathAvatar + d.Avatar;
            checkGender.CheckState = d.Gender == null ? CheckState.Indeterminate : (d.Gender == true ? CheckState.Checked : CheckState.Unchecked);
            cbRole.Text = d.RoleID.ToString();
            checkStatus.Checked = d.Status;
            PictureBox1.ImageLocation = txtAvatar.Text;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                DataGridView1.ClearSelection(); btnEditStaff.Enabled = false;
                btnDeleteStaff.Enabled = false; clearText(); return;
            }
            btnEditStaff.Enabled = true;
            btnDeleteStaff.Enabled = true;
            DataGridView1.CurrentRow.Selected = true;
            long StaffID = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["StaffID"].Value);
            List<Staff> result = db.Staffs.Where(s => s.StaffID == StaffID).ToList();
            foreach (Staff d in result)
            {
                UpdateLabel(d);
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All file|*.*|Bitmap File | *.bmp; *.dib | JPEG | *.jpg; *.jpe; *.jpeg; *.jfif | GIF | *.gif | TIFF | *.tif; *.tiff | PNG | *. png | ICO | *.ico";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAvatar.Text = openFileDialog1.FileName;
                PictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (btnEditStaff.Enabled == true)
            {
                btnEditStaff.Enabled = false;
                btnDeleteStaff.Enabled = false;
                DataGridView1.ClearSelection();
                clearText();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtStaffName.Text))
                {
                    ErrorMess.Show("Hãy nhập tên nhân viên?");
                    txtStaffName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    ErrorMess.Show("Hãy nhập mật khẩu?");
                    txtPassword.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    ErrorMess.Show("Hãy nhập địa chỉ?");
                    txtAddress.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    ErrorMess.Show("Hãy nhập Email?");
                    txtEmail.Focus();
                    return;
                }
                else if (!Utility.IsVaildMail(txtEmail.Text))
                {
                    ErrorMess.Show("Mail không hợp lệ?");
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    ErrorMess.Show("Hãy nhập Số điện thoại?");
                    txtPhone.Focus();
                    return;
                }
                else if (txtPhone.Text.Length < 10)
                {
                    ErrorMess.Show("Số điện thoại không hợp lệ?");
                    txtPhone.Focus();
                    return;
                }
                if (cbRole.SelectedIndex == -1)
                {
                    ErrorMess.Show("Hãy thêm phân quyền?");
                    cbRole.Focus();
                    return;
                }
                if (Convert.ToDateTime(dtPickerBirthday.Value.ToShortDateString()) > Convert.ToDateTime(DateTime.UtcNow.Date.ToShortDateString()))
                {
                    ErrorMess.Show("Ngày sinh không hợp lệ?");
                    dtPickerBirthday.Focus();
                    return;
                }
                try
                {
                    staff = new Staff();
                    staff.StaffName = txtStaffName.Text;
                    staff.Password = txtPassword.Text;
                    staff.Address = txtAddress.Text;
                    staff.Birthday = dtPickerBirthday.Value.Date;
                    staff.Email = txtEmail.Text;
                    staff.RoleID = Convert.ToByte(cbRole.Text);
                    staff.Gender = checkGender.Checked;
                    staff.Phone = txtPhone.Text;
                    staff.Status = checkStatus.Checked;
                    db.Staffs.Add(staff);
                    db.SaveChanges();
                    if (!string.IsNullOrWhiteSpace(txtAvatar.Text))
                    {
                        if (txtAvatar.Text.LastIndexOf(".") >= 0)
                        {
                            string ext = txtAvatar.Text.Substring(txtAvatar.Text.LastIndexOf("."), txtAvatar.Text.Length - txtAvatar.Text.LastIndexOf("."));
                            staff.Avatar = staff.StaffID + ext;
                            PictureBox1.Image.Save(Utility.ImagePathAvatar + staff.StaffID + ext);
                            db.SaveChanges();
                            SuccessMess.Show("Thêm thành công.");
                        }
                        else
                        {
                            staff.Avatar = null;
                            db.SaveChanges();
                            SuccessMess.Show("Thêm thành công.");
                        }
                    }
                    else
                    {
                        staff.Avatar = null;
                        db.SaveChanges();
                        SuccessMess.Show("Thêm thành công.");
                    }
                    clearText();
                    LoadStaff();
                }
                catch (Exception ex)
                {
                    ErrorMess.Show("Thêm thất bại? Error: " + ex.Message);
                }
            }
        }

        private void fStaff_Load(object sender, EventArgs e)
        {
            LoadStaff();
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            Staff staff;
            try
            {
                int index = DataGridView1.CurrentRow.Index;
                long StaffID = Convert.ToInt64(DataGridView1.Rows[index].Cells["StaffID"].Value);
                staff = db.Staffs.Single(s => s.StaffID == StaffID);
                if (WarningMess.Show("Bạn muốn xóa " + staff.StaffName + " ra khỏi danh sách", "Xóa") == DialogResult.Yes)
                {
                    db.Staffs.Remove(staff);
                    db.SaveChanges();
                    clearText();
                    LoadStaff();
                }
            }
            catch (Exception ex)
            {
                ErrorMess.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
            }
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStaffName.Text))
            {
                ErrorMess.Show("Hãy nhập Số điện thoại?");
                txtStaffName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ErrorMess.Show("Hãy nhập mật khẩu?");
                txtPassword.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ErrorMess.Show("Hãy nhập địa chỉ?");
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ErrorMess.Show("Hãy nhập Email?");
                txtEmail.Focus();
                return;
            }
            else if (!Utility.IsVaildMail(txtEmail.Text))
            {
                ErrorMess.Show("Mail không hợp lệ?");
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                ErrorMess.Show("Hãy nhập Số điện thoại?");
                txtPhone.Focus();
                return;
            }
            else if (txtPhone.Text.Length < 10)
            {
                ErrorMess.Show("Số điện thoại không hợp lệ?");
                txtPhone.Focus();
                return;
            }
            if (cbRole.SelectedIndex == -1)
            {
                ErrorMess.Show("Hãy thêm phân quyền?");
                cbRole.Focus();
                return;
            }
            if (Convert.ToDateTime(dtPickerBirthday.Value.ToShortDateString()) > Convert.ToDateTime(DateTime.UtcNow.Date.ToShortDateString()))
            {
                ErrorMess.Show("Ngày sinh không hợp lệ?");
                dtPickerBirthday.Focus();
                return;
            }
            try
            {
                long StaffID = Convert.ToInt64(lblID.Text);
                staff = db.Staffs.Single(s => s.StaffID == StaffID);
                staff.StaffName = txtStaffName.Text;
                staff.Password = txtPassword.Text;
                staff.Address = txtAddress.Text;
                staff.Birthday = dtPickerBirthday.Value.Date;
                staff.Email = txtEmail.Text;
                staff.RoleID = Convert.ToByte(cbRole.Text);
                staff.Gender = checkGender.Checked;
                staff.Phone = txtPhone.Text;
                staff.Status = checkStatus.Checked;
                db.SaveChanges();
                if (!string.IsNullOrWhiteSpace(txtAvatar.Text))
                {
                    if (txtAvatar.Text.LastIndexOf(".") >= 0)
                    {
                        string ext = txtAvatar.Text.Substring(txtAvatar.Text.LastIndexOf("."), txtAvatar.Text.Length - txtAvatar.Text.LastIndexOf("."));
                        staff.Avatar = staff.StaffID + ext;
                        PictureBox1.Image.Save(Utility.ImagePathAvatar + staff.StaffID + ext);
                        db.SaveChanges();
                        SuccessMess.Show("Lưu thành công.");
                    }
                    else
                    {
                        staff.Avatar = null;
                        db.SaveChanges();
                        SuccessMess.Show("Lưu thành công.");
                    }
                }
                else
                {
                    staff.Avatar = null;
                    db.SaveChanges();
                    SuccessMess.Show("Lưu thành công.");
                }
                LoadStaff();
            }
            catch (Exception ex)
            {
                ErrorMess.Show("Lưu thất bại? Error: " + ex.Message);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView1.Focused)
            {
                int index = DataGridView1.CurrentRow.Index;
                long StaffID = Convert.ToInt64(DataGridView1.Rows[index].Cells["StaffID"].Value);
                List<Staff> result = db.Staffs.Where(s => s.StaffID == StaffID).ToList();
                foreach (Staff d in result)
                {
                    UpdateLabel(d);
                }
            }
        }
    }
}
