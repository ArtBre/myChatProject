using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
//My usings
using Chat04.Model;
using Chat04.Static_Classes;
using Chat04.Supplementaries;

namespace Chat04
{
    
    public partial class Form1 : Form
    {
        public static List<Form2> activePrivForms = new List<Form2>();
        Timer timerForGetData = new Timer();
        Timer timerForWakeUpKeeper = new Timer();
        public Form1()
        {
            InitializeComponent();
            timerForGetData.Interval = 1000;
            timerForGetData.Tick += new EventHandler(GetDataFromServer);

            timerForWakeUpKeeper.Interval = 3000;
            timerForWakeUpKeeper.Tick += new EventHandler(DontSleepKeep);

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (ActionSetCombobox.Text == Consts.Combo.CreateAcc)
            {
                if (UsernameTexBox.Text != "" && PasswordTextBox.Text != "")
                 {
                    if (Client.SendLogInMessage(Consts.Addresses.authCreateUser, UsernameTexBox.Text, PasswordTextBox.Text, null)) MessageBox.Show("Account Created !!!");
                    else MessageBox.Show("Operation Failed !!!");
                 }
                 else MessageBox.Show("Missing Values !!!");
        }


            if (ActionSetCombobox.Text == Consts.Combo.LogIn)
            {
                
                if (Client.SendLogInMessage(Consts.Addresses.authLogIn, UsernameTexBox.Text, PasswordTextBox.Text,null))
                {
                    LogInPanel.Visible = false;
                    Client.current=Client.getCurrentUserInstance(UsernameTexBox.Text);
                    timerForGetData.Start();
                    ServerConnection.SendMessage("", Consts.Addresses.requestUserKeeper, Consts.IDs.RequestUserKeeper);
                    timerForWakeUpKeeper.Start();
                    PasswordTextBox.Text = "";
                }
                else MessageBox.Show("Bad login or password"); 
            }


                if (ActionSetCombobox.Text == Consts.Combo.ChangePass && NewPwdTextBox.Text == "")
                    MessageBox.Show("Missing Value !!!");

                if (ActionSetCombobox.Text == "Change Password" && NewPwdTextBox.Text != "")
                {

                    if (Client.SendLogInMessage(Consts.Addresses.authChangePass, UsernameTexBox.Text, PasswordTextBox.Text, NewPwdTextBox.Text))
                    {
                        MessageBox.Show("Password changed");
                    }
                else MessageBox.Show("Something went wrong ;(");
               }


            if (ActionSetCombobox.Text == Consts.Combo.DeleteUser)
            {

                if (Client.SendLogInMessage(Consts.Addresses.authDeleteUsr, UsernameTexBox.Text, PasswordTextBox.Text, null))
                {
                    MessageBox.Show("Account deleted !!! ");
                }
                else MessageBox.Show("Something went wrong ;(");
            }

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Client.SendLogInMessage(Consts.Addresses.authLogOut, Client.current.username, null, null);
            LogInPanel.Visible = true;
            timerForGetData.Stop();
            timerForWakeUpKeeper.Stop();
            Client.current = null;
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            if(SendMessageTextField.Text != "")
            {
                Client.SendMessageToServer(Client.current.id, 0, Client.current.username + ": " + SendMessageTextField.Text);
                SendMessageTextField.Text = null;
                MainChatWindow.SelectedIndex = (MainChatWindow.Items.Count - 1);
                MainChatWindow.ClearSelected();
               
            }
        }

        private void SendMessageTextField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (SendMessageTextField.Text != "")
                {
                    Client.SendMessageToServer(Client.current.id, 0, Client.current.username+": "+SendMessageTextField.Text);
                    SendMessageTextField.Text = null;
                    MainChatWindow.SelectedIndex=(MainChatWindow.Items.Count-1);
                    MainChatWindow.ClearSelected();
                }
            }
        }

        private void NickNameList_DoubleClick(object sender, EventArgs e)  
        {
           
            User user = (User)NickNameList.SelectedItem;
            if (user != null)
            {
                Form2 first = new Form2(user.username,Client.current.id,user.id,null);
                Form1.activePrivForms.Add(first);
                first.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActionSetCombobox.Text == Consts.Combo.CreateAcc) LogInButton.Text = "Create";
            if (ActionSetCombobox.Text == Consts.Combo.LogIn) LogInButton.Text = "LogIn";

            if (ActionSetCombobox.Text == Consts.Combo.ChangePass)
            {
                NewPwdLabel.Visible = true;
                NewPwdTextBox.Visible = true;
                LogInButton.Text = "ChPwd"; 
            }
            if (ActionSetCombobox.Text != Consts.Combo.ChangePass)
            {
                NewPwdLabel.Visible = false;
                NewPwdTextBox.Visible = false;
            }

            if (ActionSetCombobox.Text == Consts.Combo.DeleteUser) LogInButton.Text = "DelUsr";
        }

        //TimeMeth
        public void GetDataFromServer(object sender, EventArgs e)
        {
            Client.GetCurrentDataFromServer(Client.current, this);


        }
        public void DontSleepKeep(object sender, EventArgs e)
        {

            ServerConnection.SendMessage("", Consts.Addresses.requestUserKeeper, Consts.IDs.RequestUserKeeper);

        }
    }

    

}
