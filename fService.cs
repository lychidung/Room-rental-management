using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Project_Phòng_Trọ;
using Project_Phòng_Trọ.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Phòng_Trọ
{
    public partial class fService : Form
    {
        long ServiceIDs;
        Service Service;
        EFDbContext db = new EFDbContext();
        List<ServicesCard> services;

        public fService()
        {
            InitializeComponent();
        }

        private void clearText()
        {
            txtServiceName.Text = null;
            txtPrice.Text = null;
            txtPicture.Text = null;
            pictureBox.ImageLocation = null;
            lblServiceID.Text = null;
            ServiceIDs = 0;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadService()
        {
            var service = db.Services.ToList();
            tableLayoutPanel1.Controls.Clear();
            services = new List<ServicesCard>();
            foreach (var d in service)
            {
                ServicesCard card = new ServicesCard();
                card.ServiceID = d.ServiceID;
                card.ServiceName = d.ServiceName;
                card.Price = d.Price;
                card.ImageFile = d.ImageFile;
                card.CreateDate = d.CreateDate;
                card.SetText();
                services.Add(card);
                Guna2CustomGradientPanel panel = card.GetpanelServices();
                panel.Click += Panel_Click;

                void Panel_Click(object? sender, EventArgs e)
                {
                    ServiceIDs = card.ServiceID;
                    lblServiceID.Text = "#" + ServiceIDs;
                    btnEditService.Enabled = true;
                    btnDeleteService.Enabled = true;
                    txtServiceName.Text = card.ServiceName;
                    txtPrice.Text = card.Price.ToString();
                    txtPicture.Text = Utility.ImagePathService + card.ImageFile;
                    pictureBox.ImageLocation = txtPicture.Text;
                }

                tableLayoutPanel1.Controls.Add(card);
            }
        }

        private void fService_Activated(object sender, EventArgs e)
        {

        }

        private void fService_Load(object sender, EventArgs e)
        {
            LoadService();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (btnEditService.Enabled == true)
            {
                btnEditService.Enabled = false;
                btnDeleteService.Enabled = false;
                clearText();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtServiceName.Text))
                {
                    ErrorMess.Show("Hãy nhập tên dịch vụ?");
                    txtServiceName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    ErrorMess.Show("Hãy nhập giá dịch vụ?");
                    txtPrice.Focus();
                    return;
                }
                try
                {
                    Service = new Service();
                    Service.ServiceName = txtServiceName.Text;
                    Service.Price = Convert.ToDecimal(txtPrice.Text);
                    Service.CreateDate = DateTime.UtcNow.Date;
                    db.Services.Add(Service);
                    db.SaveChanges();
                    if (!string.IsNullOrWhiteSpace(txtPicture.Text))
                    {
                        if (txtPicture.Text.LastIndexOf(".") >= 0)
                        {
                            string ext = txtPicture.Text.Substring(txtPicture.Text.LastIndexOf("."), txtPicture.Text.Length - txtPicture.Text.LastIndexOf("."));
                            Service.ImageFile = Service.ServiceID + ext;
                            pictureBox.Image.Save(Utility.ImagePathService + Service.ServiceID + ext);
                            db.SaveChanges();
                            SuccessMess.Show("Thêm thành công.");
                        }
                        else
                        {
                            Service.ImageFile = null;
                            db.SaveChanges();
                            SuccessMess.Show("Thêm thành công.");
                        }
                    }
                    else
                    {
                        Service.ImageFile = null;
                        db.SaveChanges();
                        SuccessMess.Show("Thêm thành công.");
                    }
                    clearText();
                    LoadService();
                }
                catch (Exception ex)
                {
                    ErrorMess.Show("Thêm thất bại? Error: " + ex.Message);
                }
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All file|*.*|Bitmap File | *.bmp; *.dib | JPEG | *.jpg; *.jpe; *.jpeg; *.jfif | GIF | *.gif | TIFF | *.tif; *.tiff | PNG | *. png | ICO | *.ico";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPicture.Text = openFileDialog1.FileName;
                pictureBox.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            Service service;
            try
            {
                service = db.Services.Single(s => s.ServiceID == ServiceIDs);
                if (WarningMess.Show("Bạn muốn xóa " + service.ServiceName + " ra khỏi danh sách", "Xóa") == DialogResult.Yes)
                {
                    db.Services.Remove(service);
                    db.SaveChanges();
                    btnEditService.Enabled = false;
                    btnDeleteService.Enabled = false;
                    clearText();
                    LoadService();
                }
            }
            catch (Exception ex)
            {
                ErrorMess.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
            }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                ErrorMess.Show("Hãy nhập tên dịch vụ?");
                txtServiceName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                ErrorMess.Show("Hãy nhập giá dịch vụ?");
                txtPrice.Focus();
                return;
            }
            try
            {
                Service = db.Services.Single(s => s.ServiceID == ServiceIDs);
                Service.ServiceName = txtServiceName.Text;
                Service.Price = Convert.ToDecimal(txtPrice.Text);
                Service.CreateDate = DateTime.UtcNow.Date;
                db.SaveChanges();
                if (!string.IsNullOrWhiteSpace(txtPicture.Text))
                {
                    if (txtPicture.Text.LastIndexOf(".") >= 0)
                    {
                        string ext = txtPicture.Text.Substring(txtPicture.Text.LastIndexOf("."), txtPicture.Text.Length - txtPicture.Text.LastIndexOf("."));
                        Service.ImageFile = Service.ServiceID + ext;
                        pictureBox.Image.Save(Utility.ImagePathService + Service.ServiceID + ext);
                        db.SaveChanges();
                        SuccessMess.Show("Lưu thành công.");
                    }
                    else
                    {
                        Service.ImageFile = null;
                        db.SaveChanges();
                        SuccessMess.Show("Lưu thành công.");
                    }
                }
                else
                {
                    Service.ImageFile = null;
                    db.SaveChanges();
                    SuccessMess.Show("Lưu thành công.");
                }
                LoadService();
            }
            catch (Exception ex)
            {
                ErrorMess.Show("Lưu thất bại? Error: " + ex.Message);
            }
        }
    }
}
