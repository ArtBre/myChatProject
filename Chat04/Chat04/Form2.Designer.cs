namespace Chat04
{
    partial class Form2
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
            this.PrivateChatWindow = new System.Windows.Forms.ListBox();
            this.PrivateSendMessageTextField = new System.Windows.Forms.TextBox();
            this.PrivateSendMessageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrivateChatWindow
            // 
            this.PrivateChatWindow.FormattingEnabled = true;
            this.PrivateChatWindow.Location = new System.Drawing.Point(27, 22);
            this.PrivateChatWindow.Name = "PrivateChatWindow";
            this.PrivateChatWindow.Size = new System.Drawing.Size(673, 342);
            this.PrivateChatWindow.TabIndex = 0;
            // 
            // PrivateSendMessageTextField
            // 
            this.PrivateSendMessageTextField.Location = new System.Drawing.Point(26, 381);
            this.PrivateSendMessageTextField.Name = "PrivateSendMessageTextField";
            this.PrivateSendMessageTextField.Size = new System.Drawing.Size(581, 20);
            this.PrivateSendMessageTextField.TabIndex = 1;
            this.PrivateSendMessageTextField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.PrivateSendMessageTextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrivateSendMessageTextField_KeyPress);
            // 
            // PrivateSendMessageButton
            // 
            this.PrivateSendMessageButton.Location = new System.Drawing.Point(625, 378);
            this.PrivateSendMessageButton.Name = "PrivateSendMessageButton";
            this.PrivateSendMessageButton.Size = new System.Drawing.Size(75, 23);
            this.PrivateSendMessageButton.TabIndex = 2;
            this.PrivateSendMessageButton.Text = "Send";
            this.PrivateSendMessageButton.UseVisualStyleBackColor = true;
            this.PrivateSendMessageButton.Click += new System.EventHandler(this.PrivateSendMessageButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 436);
            this.Controls.Add(this.PrivateSendMessageButton);
            this.Controls.Add(this.PrivateSendMessageTextField);
            this.Controls.Add(this.PrivateChatWindow);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox PrivateChatWindow;
        private System.Windows.Forms.TextBox PrivateSendMessageTextField;
        private System.Windows.Forms.Button PrivateSendMessageButton;
        public int sender { get; private set; }
        public int reciever { get; private set; }
    }
}