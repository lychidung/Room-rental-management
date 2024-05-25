using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using Guna.UI2.WinForms;

namespace Project_Phòng_Trọ
{
    public partial class ServicesCard : UserControl
    {
        public ServicesCard()
        {
            InitializeComponent();
        }

        public void SetText()
        {
            this.lblServiceName.Text = ServiceName;
            this.lblServicePrice.Text = Price.ToString("0,0") + "đ";
            this.lblCreateDate.Text = CreateDate.ToShortDateString();
            this.PictureService.ImageLocation = Utility.ImagePathService + ImageFile;
        }
        public Guna2CustomGradientPanel GetpanelServices()
        {
            return panelService;
        }
        public long ServiceID
        { get; set; }

        public decimal Price { get; set; }

        public string ServiceName { get; set; }

        public string? ImageFile { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
