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
    public partial class fInvoices : Form
    {
        EFDbContext db = new EFDbContext();
        Invoices invoices;
        decimal amount;

        public fInvoices()
        {
            InitializeComponent();
        }

        private void clearText()
        {
            dtCreateDate.Text = DateTime.UtcNow.Date.ToShortDateString();
            dtEndDate.Text = DateTime.UtcNow.Date.ToShortDateString();
            lblTotalAmount.Text = null;
            amount = 0;
            checkStatus.Checked = true;
        }

        private void loadCbRoom()
        {
            cbRoom.DisplayMember = "RoomName";
            cbRoom.ValueMember = "RoomID";
            cbRoom.DataSource = db.Rooms.Where(r => r.Status == true).ToList();
            cbRoom.Text = null;
        }

        //Trả về tổng số tiền
        private decimal TotalAmount(string id)
        {
            return amount;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
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

        private void fInvoices_Load(object sender, EventArgs e)
        {
            var maxid = db.Invoices.Max(x => x.InvoiceID);
            lblInvoiceID.Text = (maxid + 1).ToString();
            loadCbRoom();
        }

        private void cbRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long roomID = Convert.ToInt64(cbRoom.SelectedValue);
            var room = db.Rooms.Single(r => r.RoomID == roomID);
            lblTotalAmount.Text = room.RoomPrice.ToString("0,0") + "đ";
            amount = room.RoomPrice;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
