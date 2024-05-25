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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Project_Phòng_Trọ
{
    public partial class fNewInvoices : Form
    {
        EFDbContext db = new EFDbContext();
        Invoices invoices;
        ServiceDetail serviceDetail;
        decimal amount;
        public fNewInvoices()
        {
            InitializeComponent();
        }
        private void loadCbRoom()
        {
            cbRoom.DisplayMember = "RoomName";
            cbRoom.ValueMember = "RoomID";
            cbRoom.DataSource = db.Rooms.Where(r => r.Status == true).ToList();
            cbRoom.Text = null;

            cbService.DisplayMember = "ServiceName";
            cbService.ValueMember = "ServiceID";
            cbService.DataSource = db.Services.Select(c => new
            {
                c.ServiceID,
                c.ServiceName,
            }).ToList();
            cbService.SelectedIndex = -1;
        }
        private void clearText()
        {
            dtCreateDate.Text = DateTime.UtcNow.Date.ToShortDateString();
            dtEndDate.Text = DateTime.UtcNow.Date.ToShortDateString();
            txtTotal.Text = null;
            amount = 0;
            txtTotal.Text = null;
            txtQuantity.Text = null;
            txtPrice.Text = null;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void fNewInvoices_Load(object sender, EventArgs e)
        {
            var maxid = db.Invoices.Max(x => x.InvoiceID);
            txtIDInvoice.Text = "Mã hóa đơn: #" + (maxid + 1).ToString();
            loadCbRoom();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            if (cbRoom.SelectedIndex == -1)
            {
                ErrorMess.Show("Chưa chọn phòng?");
                cbRoom.Focus();
                return;
            }
            if (Convert.ToDateTime(dtCreateDate.Value.ToShortDateString()) > Convert.ToDateTime(dtEndDate.Value.ToShortDateString()))
            {
                ErrorMess.Show("Ngày kết thúc hóa đơn không hợp lệ?");
                dtEndDate.Focus();
                return;
            }
            if (dtEndDate.Value.Date.Subtract(dtCreateDate.Value.Date).TotalDays < 30)
            {
                ErrorMess.Show("Tháng phải trả hóa đơn phải >= 1?");
                dtEndDate.Focus();
                return;
            }
            try
            {


                invoices = new Invoices();
                invoices.CreateDate = DateTime.UtcNow.Date;
                invoices.EndDate = dtEndDate.Value.Date;
                invoices.RoomID = Convert.ToInt64(cbRoom.SelectedValue);
                invoices.Status = checkStatus.Checked;
                invoices.TotalAmount = amount;
                db.Invoices.Add(invoices);

                var maxid = db.Invoices.Max(x => x.InvoiceID);
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    serviceDetail = new ServiceDetail();
                    serviceDetail.InvoiceID = maxid + 1;
                    serviceDetail.ServiceID = Convert.ToInt32(row.Cells["ServiceID"].Value);
                    serviceDetail.Quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    serviceDetail.TotalAmount = Convert.ToInt32(row.Cells["Total"].Value);
                    db.ServiceDetails.Add(serviceDetail);
                    amount += Convert.ToInt32(row.Cells["Total"].Value);
                }
                db.SaveChanges();
                SuccessMess.Show("Thêm thành công");
                loadCbRoom();
                clearText();
            }
            catch (Exception ex)
            {
                ErrorMess.Show("Thêm thất bại? Error: " + ex.Message);
            }
        }

        private void cbRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long roomID = Convert.ToInt64(cbRoom.SelectedValue);
            var room = db.Rooms.Single(r => r.RoomID == roomID);
            txtPrice.Text = room.RoomPrice.ToString("0,0") + "đ";
            amount = room.RoomPrice;
        }

        private void checkStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkStatus.Checked)
            {
                // Hiển thị cảnh báo bằng MessageBox
                DialogResult result = YNMess.Show("Hóa đơn này đã được thanh toán?");

                // Kiểm tra kết quả của MessageBox
                if (result == DialogResult.No)
                {
                    // Nếu người dùng chọn "No", hủy chọn CheckBox
                    checkStatus.Checked = false;
                }
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbService.Text) && !string.IsNullOrEmpty(txtQuantity.Text))
            {
                long serviceID = Convert.ToInt64(cbService.SelectedValue);
                var service = db.Services.Single(r => r.ServiceID == serviceID);
                decimal TotalService = service.Price * txtQuantity.Value;
                guna2DataGridView1.Rows.Add(service.ServiceID, service.ServiceName, service.Price, txtQuantity.Value, TotalService);
                amount += TotalService;
                txtTotal.Text = amount.ToString("0,0") + "đ";
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Delete2")
            {
                guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {



        }
    }
}
