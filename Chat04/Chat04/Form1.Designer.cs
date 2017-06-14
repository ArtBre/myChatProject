namespace Chat04
{
    partial class Form1
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
            this.LogInPanel = new System.Windows.Forms.Panel();
            this.NewPwdLabel = new System.Windows.Forms.Label();
            this.ActionSetCombobox = new System.Windows.Forms.ComboBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTexBox = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MainChatWindow = new System.Windows.Forms.ListBox();
            this.SendMessageTextField = new System.Windows.Forms.TextBox();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.NickNameList = new System.Windows.Forms.ListBox();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.NewPwdTextBox = new System.Windows.Forms.TextBox();
            this.LogInPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogInPanel
            // 
            this.LogInPanel.Controls.Add(this.NewPwdTextBox);
            this.LogInPanel.Controls.Add(this.NewPwdLabel);
            this.LogInPanel.Controls.Add(this.ActionSetCombobox);
            this.LogInPanel.Controls.Add(this.PasswordTextBox);
            this.LogInPanel.Controls.Add(this.UsernameTexBox);
            this.LogInPanel.Controls.Add(this.LogInButton);
            this.LogInPanel.Controls.Add(this.PasswordLabel);
            this.LogInPanel.Controls.Add(this.UserNameLabel);
            this.LogInPanel.Controls.Add(this.TitleLabel);
            this.LogInPanel.Location = new System.Drawing.Point(1, 0);
            this.LogInPanel.Name = "LogInPanel";
            this.LogInPanel.Size = new System.Drawing.Size(1052, 613);
            this.LogInPanel.TabIndex = 0;
            // 
            // NewPwdLabel
            // 
            this.NewPwdLabel.AutoSize = true;
            this.NewPwdLabel.Location = new System.Drawing.Point(689, 243);
            this.NewPwdLabel.Name = "NewPwdLabel";
            this.NewPwdLabel.Size = new System.Drawing.Size(53, 13);
            this.NewPwdLabel.TabIndex = 8;
            this.NewPwdLabel.Text = "New Pwd";
            this.NewPwdLabel.Visible = false;
            // 
            // ActionSetCombobox
            // 
            this.ActionSetCombobox.FormattingEnabled = true;
            this.ActionSetCombobox.Items.AddRange(new object[] {
            "LogIn",
            "Create Account",
            "Change Password",
            "Delete User"});
            this.ActionSetCombobox.Location = new System.Drawing.Point(564, 283);
            this.ActionSetCombobox.Name = "ActionSetCombobox";
            this.ActionSetCombobox.Size = new System.Drawing.Size(109, 21);
            this.ActionSetCombobox.TabIndex = 7;
            this.ActionSetCombobox.Text = "LogIn";
            this.ActionSetCombobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(428, 240);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(245, 20);
            this.PasswordTextBox.TabIndex = 6;
            // 
            // UsernameTexBox
            // 
            this.UsernameTexBox.Location = new System.Drawing.Point(428, 217);
            this.UsernameTexBox.Name = "UsernameTexBox";
            this.UsernameTexBox.Size = new System.Drawing.Size(245, 20);
            this.UsernameTexBox.TabIndex = 5;
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(477, 281);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(75, 23);
            this.LogInButton.TabIndex = 4;
            this.LogInButton.Text = this.ActionSetCombobox.Text;
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(356, 243);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Password";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(356, 220);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(55, 13);
            this.UserNameLabel.TabIndex = 1;
            this.UserNameLabel.Text = "Username";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.TitleLabel.Location = new System.Drawing.Point(423, 53);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(209, 26);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Welcome to MyChat";
            // 
            // MainChatWindow
            // 
            this.MainChatWindow.DisplayMember = "message";
            this.MainChatWindow.FormattingEnabled = true;
            this.MainChatWindow.Location = new System.Drawing.Point(12, 12);
            this.MainChatWindow.Name = "MainChatWindow";
            this.MainChatWindow.Size = new System.Drawing.Size(877, 524);
            this.MainChatWindow.TabIndex = 1;
            this.MainChatWindow.TabStop = false;
            // 
            // SendMessageTextField
            // 
            this.SendMessageTextField.Location = new System.Drawing.Point(12, 550);
            this.SendMessageTextField.Name = "SendMessageTextField";
            this.SendMessageTextField.Size = new System.Drawing.Size(781, 20);
            this.SendMessageTextField.TabIndex = 2;
            this.SendMessageTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendMessageTextField_KeyPress);
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Location = new System.Drawing.Point(799, 550);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(90, 23);
            this.SendMessageButton.TabIndex = 3;
            this.SendMessageButton.Text = "Send";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // NickNameList
            // 
            this.NickNameList.DisplayMember = "username";
            this.NickNameList.FormattingEnabled = true;
            this.NickNameList.Location = new System.Drawing.Point(895, 12);
            this.NickNameList.Name = "NickNameList";
            this.NickNameList.Size = new System.Drawing.Size(143, 524);
            this.NickNameList.TabIndex = 4;
            this.NickNameList.DoubleClick += new System.EventHandler(this.NickNameList_DoubleClick);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Location = new System.Drawing.Point(928, 550);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(75, 23);
            this.LogOutButton.TabIndex = 5;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // NewPwdTextBox
            // 
            this.NewPwdTextBox.Location = new System.Drawing.Point(748, 240);
            this.NewPwdTextBox.Name = "NewPwdTextBox";
            this.NewPwdTextBox.Size = new System.Drawing.Size(161, 20);
            this.NewPwdTextBox.TabIndex = 9;
            this.NewPwdTextBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 613);
            this.Controls.Add(this.LogInPanel);
            this.Controls.Add(this.MainChatWindow);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.NickNameList);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.SendMessageTextField);
            this.Name = "Form1";
            this.Text = "MyChat";
            this.LogInPanel.ResumeLayout(false);
            this.LogInPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LogInPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTexBox;
        private System.Windows.Forms.Button LogInButton;
        public System.Windows.Forms.ListBox MainChatWindow;
        private System.Windows.Forms.TextBox SendMessageTextField;
        private System.Windows.Forms.Button SendMessageButton;
        public System.Windows.Forms.ListBox NickNameList;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.ComboBox ActionSetCombobox;
        private System.Windows.Forms.Label NewPwdLabel;
        private System.Windows.Forms.TextBox NewPwdTextBox;
    }
}

