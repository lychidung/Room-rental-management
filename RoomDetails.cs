using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Project_Phòng_Trọ
{
    public partial class RoomDetails : Form
    {
        private long RoomID;
        private string RoomName;
        Room inforroom;
        Room room;
        EFDbContext db1 = new EFDbContext();
        public event EventHandler FormClosedEvent;

        public RoomDetails(long RoomID, string RoomName)
        {
            InitializeComponent();
            this.RoomID = RoomID;
            this.RoomName = RoomName;
            LoadDuLieuBang(RoomID, RoomName);
            LoadDuLieuService(RoomID, RoomName);
        }

        public RoomDetails()
        {

            InitializeComponent();
        }

        private void LoadDuLieuBang(long RoomID, string RoomName)
        {
            var db = new EFDbContext();
            var tenatsInRoom = db.Tenants.Where(t => t.RoomID == RoomID).Select(t => new
            {
                TenantID = t.TenantID,
                CCCD = t.CCCD,
                FullName = t.FullName,
                Gender = t.Gender,
                Birthday = t.Birthday,
                Address = t.Address,
                JoinDate = t.JoinDate,
            }).ToList();
            guna2DataGridView2.DataSource = tenatsInRoom;
            labelRoom.Text = "Bảng chi tiết " + RoomName.ToString();
            txtTenPhong.Text = RoomName.ToString();

            inforroom = db.Rooms.Single(o => o.RoomID == RoomID);
            txtGiaPhong.Text = inforroom.RoomPrice.ToString();
            txtTenPhong.Text = inforroom.RoomName;
            txtDienTich.Text = inforroom.Area.ToString();

            var totalTennantsInRoom = db.Tenants.Count(t => t.RoomID == RoomID);
            labelTongKhach.Text = "Thành viên tạm trú: " + totalTennantsInRoom.ToString();
        }

        private void LoadDuLieuService(long RoomID, string RoomName)
        {
            //var db = new EFDbContext();
            //var serviceInRoom = db.Invoices
            //    .Where(d => d.RoomID == RoomID)
            //    .Join(db.ServiceDetails, invoice => invoice.InvoiceID, serviceDetail => serviceDetail.InvoiceID,
            //    (invoice, serviceDetail) => new { invoice, serviceDetail })
            //    .Join(db.Services,
            //    joinedTable => joinedTable.serviceDetail.ServiceID,
            //    service => service.ServiceID,
            //    (joinedTable, service) => new
            //    {
            //        ServiceName = service.ServiceName,
            //        //Quantity = joinedTable.serviceDetail.Quantity,
            //        Price = service.Price,
            //        //Total = service.Price * joinedTable.serviceDetail.Quantity,
            //    }).ToList();

            //guna2DataGridView1.DataSource = serviceInRoom;

            var db = new EFDbContext();
            var inforInvoice = db.Invoices.Where(d => d.RoomID == RoomID).Select(t => new
            {
                InvoiceID = t.InvoiceID,
                CreateDate = t.CreateDate,
                Status = (t.Status == true) ? "Đã thanh toán" : "Chưa thanh toán",
            }).ToList();

            guna2DataGridView1.DataSource = inforInvoice;


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var db = new EFDbContext();
            var tenatsInRoom = db.Tenants.Where(t => t.RoomID == RoomID).Select(t => new
            {
                TenantID = t.TenantID,
                CCCD = t.CCCD,
                FullName = t.FullName,
                Gender = t.Gender,
                Birthday = t.Birthday,
                Address = t.Address,
                JoinDate = t.JoinDate,
            }).ToList();


            var tenantsWithSpecificName = tenatsInRoom.Where(t => t.FullName.Contains(txtFind.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            guna2DataGridView2.DataSource = tenantsWithSpecificName;


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView2.Columns[e.ColumnIndex].Name == "Delete")
            {
                try
                {
                    long TenantID = Convert.ToInt64(guna2DataGridView2.Rows[e.RowIndex].Cells["TenantID"].Value);
                    var db = new EFDbContext();
                    Tenant tenant = db.Tenants.Single(c => c.TenantID == TenantID);

                    if (dialogQuest.Show("Bạn muốn xóa người thuê này? " + tenant.FullName) == DialogResult.Yes)
                    {
                        db.Tenants.Remove(tenant);
                        db.SaveChanges();
                        RoomDetails_Activated(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }
            else if (guna2DataGridView2.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (Utility.IsOpenForm("fNewTenantsForRoom")) return;
                fNewTenantsForRoom f = new fNewTenantsForRoom(Convert.ToInt64(guna2DataGridView2.Rows[e.RowIndex].Cells["TenantID"].Value));
                f.ShowDialog();
            }
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Details")
            {
                try
                {
                    long InvoiceID = Convert.ToInt64(guna2DataGridView1.Rows[e.RowIndex].Cells["InvoiceID"].Value);
                    var db = new EFDbContext();
                    Invoices invoice = db.Invoices.Single(c => c.InvoiceID == InvoiceID);

                    if (Utility.IsOpenForm("fChangeInvoice")) return;
                    fChangeInvoice f = new fChangeInvoice(invoice.InvoiceID,RoomID);
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }
            else if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Delete1")
            {


            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fNewTenantsForRoom fNewTenantsForRoom = new fNewTenantsForRoom();
            fNewTenantsForRoom.ShowDialog();
        }

        private void RoomDetails_Load(object sender, EventArgs e)
        {

        }

        private void RoomDetails_Activated(object sender, EventArgs e)
        {
            LoadDuLieuBang(RoomID, RoomName);
            LoadDuLieuService(RoomID, RoomName);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnChange.Enabled = false;
            txtTenPhong.ReadOnly = false;
            txtGiaPhong.ReadOnly = false;
            txtDienTich.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                room = db1.Rooms.Single(r => r.RoomID == RoomID);

                btnSave.Enabled = false;
                btnChange.Enabled = true;
                txtTenPhong.ReadOnly = true;
                txtGiaPhong.ReadOnly = true;
                txtDienTich.ReadOnly = true;

                room.RoomName = txtTenPhong.Text;
                room.Area = decimal.Parse(txtDienTich.Text);
                room.RoomPrice = decimal.Parse(txtGiaPhong.Text);
                db1.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi xảy ra !" + e);
            }
        }

        private void RoomDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            fNewInvoices fNewInvoices = new fNewInvoices();
            fNewInvoices.ShowDialog();
        }
    }
}
