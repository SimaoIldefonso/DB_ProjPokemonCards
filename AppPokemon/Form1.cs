using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPokemon
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();



        }

        private void Login_Load(object sender, EventArgs e)
        {

            LoginRegisterTabs.Appearance = TabAppearance.FlatButtons;
            LoginRegisterTabs.ItemSize = new Size(0, 1);
            LoginRegisterTabs.SizeMode = TabSizeMode.Fixed;


            PasswordInput.PasswordChar = '*';
            PasswordInput1.PasswordChar = '*';
            ConfPasswordInput.PasswordChar = '*';





        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login Successful");
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {   //change to Register Tab
           LoginRegisterTabs.SelectedTab = RegisterTab;

        }



        /*     REGISTER     */
        private void LoginBtn1_Click(object sender, EventArgs e)
        {
            LoginRegisterTabs.SelectedTab = LoginTab;
        }

        private void RegisterBtn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Register Successful");

        }
    }
}
