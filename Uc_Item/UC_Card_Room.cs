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

namespace Project_Phòng_Trọ.Uc_Item
{
    public partial class UC_Card_Room : UserControl
    {
        private long RoomID;
        private string RoomName;
        EFDbContext db = new EFDbContext();
        Invoices invoices;

        public UC_Card_Room(string name, bool status, long RoomID)
        {
            InitializeComponent();
            this.RoomID = RoomID;
            this.RoomName = name;
            bool hasIncomplete = false;
            bool hasOverdue = false;
            bool foundInvoice = false;

            if (status)
            {
                tenphong.Text = name;
                List<Invoices> checkedInvoice = db.Invoices.Where(r => r.RoomID == RoomID).ToList();
                DateTime currentDate = DateTime.Now;
                foreach (var invoice in checkedInvoice)
                {
                    if (currentDate >= invoice.CreateDate && currentDate <= invoice.EndDate)
                    {
                        foundInvoice = true;
                        if (invoice.Status == false)
                        {
                            hasIncomplete = true;
                            break;
                        }

                    }
                    else
                    {
                        hasOverdue = true;

                    }
                }
                if (!foundInvoice)
                {
                    label1.Text = "Mới";
                    label1.BackColor = Color.FromArgb(255, 128, 255);
                }
                else if (hasIncomplete)
                {
                    label1.Text = "Trễ hạn";
                    label1.BackColor = Color.FromArgb(255, 192, 128);
                }
                else if (hasOverdue)
                {
                    label1.Text = "Chưa có";
                    label1.BackColor = Color.FromArgb(255, 128, 128);
                }
                else
                {
                    label1.Text = "Hoàn tất";
                    label1.BackColor = Color.FromArgb(178, 214, 199);
                }
            }
            else
            {
                tenphong.Text = name;
                guna2Panel1.FillColor = Color.FromArgb(255, 255, 192);
                guna2Button1.Text = "Đang trống";
                guna2Button1.FillColor = Color.FromArgb(255, 192, 128);
                label1.Visible = false;
            }
        }

        private void UC_Card_Room_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            RoomDetails roomDetails = new RoomDetails(RoomID, RoomName);
            roomDetails.ShowDialog();
        }
    }
}
