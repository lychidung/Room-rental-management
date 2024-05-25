namespace Project_Phòng_Trọ
{
    partial class fReportStaffGroup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReportTenant));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btClose = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)btClose).BeginInit();
            SuspendLayout();
            // 
            // btClose
            // 
            btClose.BackColor = Color.Transparent;
            btClose.CustomizableEdges = customizableEdges1;
            btClose.FillColor = Color.Transparent;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageRotate = 0F;
            btClose.Location = new Point(1076, 1);
            btClose.Name = "btClose";
            btClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btClose.Size = new Size(30, 29);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 8;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // fReportTenant
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 800);
            Controls.Add(btClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fReportTenant";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fReportTenant";
            Load += fReportTenant_Load;
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox btClose;
    }
}