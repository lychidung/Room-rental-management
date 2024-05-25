namespace Project_Phòng_Trọ
{
    partial class fNewTenantsForRoom
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            cbRoom = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            txtCC = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            timeBirthday = new Guna.UI2.WinForms.Guna2DateTimePicker();
            toolTip1 = new ToolTip(components);
            cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(187, 39);
            label1.Name = "label1";
            label1.Size = new Size(156, 41);
            label1.TabIndex = 0;
            label1.Text = "Số phòng:";
            // 
            // cbRoom
            // 
            cbRoom.BackColor = Color.Transparent;
            cbRoom.CustomizableEdges = customizableEdges1;
            cbRoom.DrawMode = DrawMode.OwnerDrawFixed;
            cbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoom.FocusedColor = Color.FromArgb(94, 148, 255);
            cbRoom.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbRoom.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbRoom.ForeColor = Color.FromArgb(68, 88, 112);
            cbRoom.ItemHeight = 30;
            cbRoom.Location = new Point(358, 44);
            cbRoom.Name = "cbRoom";
            cbRoom.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbRoom.Size = new Size(343, 36);
            cbRoom.TabIndex = 1;
            cbRoom.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(195, 104);
            label2.Name = "label2";
            label2.Size = new Size(148, 38);
            label2.TabIndex = 2;
            label2.Text = "Họ và tên:";
            // 
            // txtName
            // 
            txtName.CustomizableEdges = customizableEdges3;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(358, 104);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PlaceholderText = "";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtName.Size = new Size(343, 38);
            txtName.TabIndex = 3;
            // 
            // txtCC
            // 
            txtCC.CustomizableEdges = customizableEdges5;
            txtCC.DefaultText = "";
            txtCC.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCC.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCC.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCC.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCC.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCC.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCC.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCC.Location = new Point(358, 177);
            txtCC.Margin = new Padding(3, 4, 3, 4);
            txtCC.Name = "txtCC";
            txtCC.PasswordChar = '\0';
            txtCC.PlaceholderText = "";
            txtCC.SelectedText = "";
            txtCC.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtCC.Size = new Size(343, 38);
            txtCC.TabIndex = 4;
            txtCC.TextChanged += guna2TextBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(203, 177);
            label3.Name = "label3";
            label3.Size = new Size(140, 38);
            label3.TabIndex = 5;
            label3.Text = "Căn cước:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(203, 258);
            label4.Name = "label4";
            label4.Size = new Size(132, 38);
            label4.TabIndex = 6;
            label4.Text = "Giới tính:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(191, 332);
            label5.Name = "label5";
            label5.Size = new Size(144, 38);
            label5.TabIndex = 9;
            label5.Text = "Năm sinh:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(177, 408);
            label6.Name = "label6";
            label6.Size = new Size(166, 38);
            label6.TabIndex = 10;
            label6.Text = "Thường trú:";
            // 
            // txtAddress
            // 
            txtAddress.CustomizableEdges = customizableEdges7;
            txtAddress.DefaultText = "";
            txtAddress.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAddress.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAddress.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAddress.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAddress.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAddress.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtAddress.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAddress.Location = new Point(358, 408);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.PasswordChar = '\0';
            txtAddress.PlaceholderText = "";
            txtAddress.SelectedText = "";
            txtAddress.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtAddress.Size = new Size(343, 38);
            txtAddress.TabIndex = 12;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges9;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(130, 184, 155);
            guna2Button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(476, 490);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.BorderRadius = 15;
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Button1.ShadowDecoration.Depth = 4;
            guna2Button1.ShadowDecoration.Enabled = true;
            guna2Button1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2Button1.Size = new Size(225, 56);
            guna2Button1.TabIndex = 13;
            guna2Button1.Text = "Thêm";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // timeBirthday
            // 
            timeBirthday.Checked = true;
            timeBirthday.CustomFormat = "yyyy/MM/dd";
            timeBirthday.CustomizableEdges = customizableEdges11;
            timeBirthday.FillColor = Color.White;
            timeBirthday.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            timeBirthday.Format = DateTimePickerFormat.Long;
            timeBirthday.Location = new Point(358, 332);
            timeBirthday.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            timeBirthday.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            timeBirthday.Name = "timeBirthday";
            timeBirthday.ShadowDecoration.CustomizableEdges = customizableEdges12;
            timeBirthday.Size = new Size(343, 45);
            timeBirthday.TabIndex = 15;
            timeBirthday.Value = new DateTime(2023, 11, 8, 0, 0, 0, 0);
            // 
            // cbGender
            // 
            cbGender.BackColor = Color.Transparent;
            cbGender.CustomizableEdges = customizableEdges13;
            cbGender.DrawMode = DrawMode.OwnerDrawFixed;
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.FocusedColor = Color.FromArgb(94, 148, 255);
            cbGender.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbGender.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbGender.ForeColor = Color.FromArgb(68, 88, 112);
            cbGender.ItemHeight = 30;
            cbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbGender.Location = new Point(358, 260);
            cbGender.Name = "cbGender";
            cbGender.ShadowDecoration.CustomizableEdges = customizableEdges14;
            cbGender.Size = new Size(343, 36);
            cbGender.TabIndex = 16;
            // 
            // fNewTenantsForRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(885, 580);
            Controls.Add(cbGender);
            Controls.Add(timeBirthday);
            Controls.Add(guna2Button1);
            Controls.Add(txtAddress);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtCC);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(cbRoom);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "fNewTenantsForRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm người cư trú";
            Load += fNewTenantsForRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbRoom;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtCC;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DateTimePicker timeBirthday;
        private ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
    }
}