using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Phòng_Trọ.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Phòng_Trọ
{
    public partial class fConfirmPassStaff : Form
    {
        string email;
        public fConfirmPassStaff(string Email)
        {
            InitializeComponent();
            this.email = Email;
            lblEmail.Text = email;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                ErrorMess.Show("Mật khẩu không được để trống!");
                return;
            }
            if (txtNewPass.Text.Length < 3)
            {
                ErrorMess.Show("Mật khẩu phải dài hơn hoặc bằng 3 kí tự!");
                return;
            }
            if (txtNewPass.Text.ToString().Equals(txtConfirmPass.Text.ToString()))
            {
                try
                {
                    var db = new EFDbContext();
                    Staff staff = db.Staffs.SingleOrDefault(e => e.Email == email);
                    staff.Password = txtConfirmPass.Text;
                    db.SaveChanges();
                    if (SuccessMess.Show("Đổi mật khẩu thành công") == DialogResult.OK)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    ErrorMess.Show("Lỗi!");
                }
            }
            else
            {
                ErrorMess.Show("Mật khẩu xác nhận không đúng!");
            }
        }
    }
}
