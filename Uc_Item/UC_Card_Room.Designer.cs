namespace Project_Phòng_Trọ.Uc_Item
{
    partial class UC_Card_Room
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Card_Room));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            tenphong = new Label();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.BorderRadius = 20;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(18, 69);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(289, 178);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 0;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.Click += guna2Panel1_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderRadius = 30;
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(guna2Button1);
            guna2Panel1.Controls.Add(tenphong);
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Color = Color.Transparent;
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.ShadowDecoration.Enabled = true;
            guna2Panel1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2Panel1.Size = new Size(324, 323);
            guna2Panel1.TabIndex = 2;
            guna2Panel1.Click += guna2Panel1_Click;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 192, 128);
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(182, 20);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(109, 37);
            label1.TabIndex = 3;
            label1.Text = "Mới";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.LightGreen;
            guna2Button1.FocusedColor = Color.FromArgb(128, 255, 128);
            guna2Button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.SeaShell;
            guna2Button1.Location = new Point(75, 263);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(183, 37);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Hoạt động";
            guna2Button1.Click += guna2Panel1_Click;
            // 
            // tenphong
            // 
            tenphong.AutoSize = true;
            tenphong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            tenphong.ForeColor = Color.Gray;
            tenphong.Location = new Point(18, 22);
            tenphong.Name = "tenphong";
            tenphong.Size = new Size(129, 31);
            tenphong.TabIndex = 1;
            tenphong.Text = "Phòng 202";
            tenphong.Click += guna2Panel1_Click;
            // 
            // UC_Card_Room
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel1);
            Margin = new Padding(20, 20, 3, 3);
            Name = "UC_Card_Room";
            Size = new Size(324, 323);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label tenphong;
        private Label label1;
    }
}
