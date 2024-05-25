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
    public partial class fLoginStaff : Form
    {
        public fLoginStaff()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                Message.Show("Bạn phải nhập tên người dùng?");
                txtUser.Select();
            }
            else if (txtPassword.Text == "")
            {
                Message.Show("Bạn phải nhập mật khẩu?");
                txtPassword.Select();
            }
            else
            {
                try
                {
                    var db = new EFDbContext();
                    Utility.Staff = db.Staffs.SingleOrDefault(e => e.Email == txtUser.Text && e.Password == txtPassword.Text);
                    if (Utility.Staff != null)
                    {
                        if (Success.Show("Đăng nhập thành công") == DialogResult.OK)
                        {
                            DialogResult = DialogResult.OK;
                            Admin admin = new Admin();
                            admin.ShowDialog();
                            this.Hide();
                        }
                    }
                    else
                    {
                        txtPassword.Text = "";
                        Message.Show("Sai tên người dùng hoặc mật khẩu");
                    }
                }
                catch (Exception ex)
                {
                    Message.Show("Lỗi");
                }
            }
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            fForgetStaff f = new fForgetStaff();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Close();
            }
        }
    }
}
