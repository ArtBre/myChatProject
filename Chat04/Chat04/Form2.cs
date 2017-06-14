using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//My usings
using Chat04.Model;
using Chat04.Static_Classes;
using Chat04.Supplementaries;
namespace Chat04
{
    public partial class Form2 : Form
    {
        public Form2(string title, int sender, int reciever, string message)
        {
            InitializeComponent();
            this.Text = title;
            this.sender = sender;
            this.reciever = reciever;
            if (message != null)
                this.PrivateChatWindow.Items.Add(message);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrivateSendMessageButton_Click(object sender, EventArgs e)
        {
            if (PrivateSendMessageTextField.Text != "")
            {
                Client.SendMessageToServer(Client.current.id, this.reciever, Client.current.username + ": " + PrivateSendMessageTextField.Text);
                PrivateChatWindow.Items.Add(Client.current.username + ": " + PrivateSendMessageTextField.Text);
                PrivateSendMessageTextField.Text = null;
                PrivateChatWindow.SelectedIndex = (PrivateChatWindow.Items.Count - 1);
                PrivateChatWindow.ClearSelected();
            }
        }

        private void PrivateSendMessageTextField_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (PrivateSendMessageTextField.Text != "")
                {
                    Client.SendMessageToServer(Client.current.id, this.reciever, Client.current.username + ": " + PrivateSendMessageTextField.Text);
                    PrivateChatWindow.Items.Add(Client.current.username + ": " + PrivateSendMessageTextField.Text);
                    PrivateSendMessageTextField.Text = null;
                    PrivateChatWindow.SelectedIndex = (PrivateChatWindow.Items.Count - 1);
                    PrivateChatWindow.ClearSelected();
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            try {
                foreach (Form2 form in Form1.activePrivForms)
                {
                    if (form.reciever == this.reciever)
                    {
                        Form1.activePrivForms.Remove(form);

                    }

                }
            } catch { }
            



        }
    }
}
