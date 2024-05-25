using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Project_Phòng_Trọ.Models;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Project_Phòng_Trọ
{
    public partial class fForgetStaff : Form
    {
        string randomcode, to;
        public fForgetStaff()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ErrorMess.Show("Vui lòng nhập Email!");
                txtEmail.Focus();
                return;
            }
            if (!Utility.IsVaildMail(txtEmail.Text))
            {
                ErrorMess.Show("Email không hợp lệ!");
                txtEmail.Focus();
                return;
            }
            var db = new EFDbContext();
            Staff staff = db.Staffs.SingleOrDefault(e => e.Email == txtEmail.Text);
            if (staff != null)
            {
                string from, pass, messageBody;
                Random random = new Random();
                randomcode = (random.Next(9999999)).ToString();
                MailMessage mailMessage = new MailMessage();
                to = (txtEmail.Text).ToString();
                from = "lycammai771@gmail.com";
                pass = "maafxhndnsdnpwzi";
                messageBody = $"Code xác nhận: {randomcode}";
                mailMessage.To.Add(to);
                mailMessage.From = new MailAddress(from);
                mailMessage.Body = messageBody;
                mailMessage.Subject = "Xác nhận đổi mật khẩu";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(mailMessage);
                    WarningMess.Show("Gửi thành công. Vui lòng check gmail của bạn");
                    btnConfirm.Enabled = true;
                }
                catch (Exception ex)
                {
                    ErrorMess.Show(ex.Message);
                }
            }
            else
            {
                ErrorMess.Show("Email này chưa được đăng ký!");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Equals(randomcode))
            {
                fConfirmPassStaff f = new fConfirmPassStaff(txtEmail.Text.ToString());
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {
                ErrorMess.Show("Code không đúng vui lòng check lại!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
