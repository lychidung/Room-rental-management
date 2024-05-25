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

namespace Project_Phòng_Trọ
{
    public partial class fChangeInvoice : Form
    {
        EFDbContext db = new EFDbContext();
        Invoices invoices;
        ServiceDetail serviceDetail;
        decimal amount;
        private long InvoiceID;
        private long RoomID;

        public fChangeInvoice(long InvoiceID, long roomID)
        {
            InitializeComponent();
            this.InvoiceID = InvoiceID;
            this.RoomID = roomID;
        }



        private void loadCbRoom()
        {
            cbRoom.DisplayMember = "RoomName";
            cbRoom.ValueMember = "RoomID";
            cbRoom.DataSource = db.Rooms.Where(r => r.RoomID == RoomID).ToList();
            //cbRoom.Text = null;



            long roomID = Convert.ToInt64(cbRoom.SelectedValue);
            var room = db.Rooms.Single(r => r.RoomID == roomID);
            txtPrice.Text = room.RoomPrice.ToString("0,0") + "đ";
            amount = room.RoomPrice;

            txtIDInvoice.Text = "Mã hóa đơn: #" + InvoiceID.ToString();

            var invoiceDetails = db.Invoices.Single(r => r.InvoiceID == InvoiceID);
            dtCreateDate.Text = invoiceDetails.CreateDate.ToString();
            dtEndDate.Text = invoiceDetails.EndDate.ToString();
            txtTotal.Text = invoiceDetails.TotalAmount.ToString();
            checkStatus.Checked = invoiceDetails.Status;

            var listServiceRoom = db.ServiceDetails
                .Where(s => s.InvoiceID == InvoiceID)
                .Join(db.Services, s => s.ServiceID, service => service.ServiceID,
                (s, service) => new
                {
                    ServiceID = s.ServiceID,
                    ServiceName = service.ServiceName,
                    Price = service.Price,
                    Quantity = s.Quantity,
                    Total = s.TotalAmount,
                }).ToList();
            guna2DataGridView1.DataSource = listServiceRoom;

        }
        private void clearText()
        {
            dtCreateDate.Text = DateTime.UtcNow.Date.ToShortDateString();
            dtEndDate.Text = DateTime.UtcNow.Date.ToShortDateString();
            txtTotal.Text = null;
            amount = 0;
            txtTotal.Text = null;
            txtPrice.Text = null;

        }

        private void fChangeInvoice_Load(object sender, EventArgs e)
        {
            txtIDInvoice.Text = "Mã hóa đơn: #" + InvoiceID;
            loadCbRoom();
        }


        private void btnAddInvoice_Click_1(object sender, EventArgs e)
        {
            try
            {
                invoices = new Invoices();
                var db1 = new EFDbContext();
                invoices = db1.Invoices.Single(r => r.InvoiceID == InvoiceID);
                MessageBox.Show(invoices.InvoiceID.ToString());
                invoices.Status = true;
                MessageBox.Show(checkStatus.Checked.ToString());
                db1.Invoices.Add(invoices);
                db1.SaveChanges();
                SuccessMess.Show("Chỉnh sửa thành công");

            }
            catch (Exception ex)
            {
                ErrorMess.Show("Thêm thất bại? Error: " + ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Delete2")
            {
                guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void checkStatus_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void cbRoom_SelectionChangeCommitted_1(object sender, EventArgs e)
        {

        }

        private void checkStatus_Click(object sender, EventArgs e)
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
                } else if(result == DialogResult.Yes)
                {
                    checkStatus.Checked = true;

                }
            }
        }
    }
}
