namespace Project_Phòng_Trọ.Uc_Item
{
    partial class UC_Header
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            btFind = new Guna.UI2.WinForms.Guna2Button();
            txtFind = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // guna2ComboBox1
            // 
            guna2ComboBox1.BackColor = Color.Transparent;
            guna2ComboBox1.BorderColor = Color.FromArgb(130, 184, 155);
            guna2ComboBox1.CustomizableEdges = customizableEdges1;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2ComboBox1.ForeColor = Color.FromArgb(130, 184, 155);
            guna2ComboBox1.ItemHeight = 50;
            guna2ComboBox1.Items.AddRange(new object[] { "Tất cả", "Hoạt động", "Đang trống" });
            guna2ComboBox1.Location = new Point(288, 17);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ComboBox1.Size = new Size(257, 56);
            guna2ComboBox1.TabIndex = 3;
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged_1;
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
            guna2Button1.FillColor = Color.FromArgb(130, 184, 155);
            guna2Button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(22, 17);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.BorderRadius = 15;
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.ShadowDecoration.Depth = 4;
            guna2Button1.ShadowDecoration.Enabled = true;
            guna2Button1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2Button1.Size = new Size(225, 56);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Thêm phòng";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // btFind
            // 
            btFind.CustomizableEdges = customizableEdges5;
            btFind.DisabledState.BorderColor = Color.DarkGray;
            btFind.DisabledState.CustomBorderColor = Color.DarkGray;
            btFind.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btFind.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btFind.FillColor = Color.FromArgb(178, 214, 199);
            btFind.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btFind.ForeColor = Color.White;
            btFind.Location = new Point(916, 17);
            btFind.Name = "btFind";
            btFind.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btFind.Size = new Size(118, 56);
            btFind.TabIndex = 13;
            btFind.Text = "Tìm";
            btFind.Click += btFind_Click;
            // 
            // txtFind
            // 
            txtFind.CustomizableEdges = customizableEdges7;
            txtFind.DefaultText = "";
            txtFind.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFind.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFind.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFind.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFind.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFind.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFind.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFind.Location = new Point(613, 17);
            txtFind.Margin = new Padding(4, 6, 4, 6);
            txtFind.Name = "txtFind";
            txtFind.PasswordChar = '\0';
            txtFind.PlaceholderText = "Tìm kiếm phòng...";
            txtFind.RightToLeft = RightToLeft.No;
            txtFind.SelectedText = "";
            txtFind.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtFind.Size = new Size(285, 56);
            txtFind.TabIndex = 12;
            txtFind.TextChanged += txtFind_TextChanged;
            // 
            // UC_Header
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btFind);
            Controls.Add(txtFind);
            Controls.Add(guna2ComboBox1);
            Controls.Add(guna2Button1);
            Name = "UC_Header";
            Size = new Size(1060, 93);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btFind;
        private Guna.UI2.WinForms.Guna2TextBox txtFind;
    }
}
