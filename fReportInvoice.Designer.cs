namespace Project_Phòng_Trọ
{
    partial class fReportInvoice
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReportInvoice));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btClose = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)btClose).BeginInit();
            SuspendLayout();
            // 
            // btClose
            // 
            btClose.BackColor = Color.Transparent;
            btClose.CustomizableEdges = customizableEdges3;
            btClose.FillColor = Color.Transparent;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageRotate = 0F;
            btClose.Location = new Point(769, 0);
            btClose.Name = "btClose";
            btClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btClose.Size = new Size(30, 29);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 9;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // fReportInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 800);
            Controls.Add(btClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fReportInvoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fReportInvoice";
            Load += fReportInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox btClose;
    }
}