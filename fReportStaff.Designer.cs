namespace Project_Phòng_Trọ
{
    partial class fReportStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReportStaff));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btClose = new Guna.UI2.WinForms.Guna2PictureBox();
            cbCheckStaff = new Guna.UI2.WinForms.Guna2ComboBox();
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
            btClose.Location = new Point(768, 1);
            btClose.Name = "btClose";
            btClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btClose.Size = new Size(30, 29);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 7;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // cbCheckStaff
            // 
            cbCheckStaff.BackColor = Color.Transparent;
            cbCheckStaff.BorderRadius = 10;
            cbCheckStaff.CustomizableEdges = customizableEdges3;
            cbCheckStaff.DrawMode = DrawMode.OwnerDrawFixed;
            cbCheckStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCheckStaff.FocusedColor = Color.FromArgb(94, 148, 255);
            cbCheckStaff.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbCheckStaff.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbCheckStaff.ForeColor = Color.FromArgb(68, 88, 112);
            cbCheckStaff.ItemHeight = 30;
            cbCheckStaff.Location = new Point(582, 63);
            cbCheckStaff.Name = "cbCheckStaff";
            cbCheckStaff.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbCheckStaff.Size = new Size(175, 36);
            cbCheckStaff.TabIndex = 8;
            cbCheckStaff.SelectedIndexChanged += cbCheckStaff_SelectedIndexChanged;
            // 
            // fReportStaff
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 1000);
            Controls.Add(cbCheckStaff);
            Controls.Add(btClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fReportStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fReportStaff";
            Load += fReportStaff_Load;
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox btClose;
        private Guna.UI2.WinForms.Guna2ComboBox cbCheckStaff;
    }
}