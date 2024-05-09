using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPokemon
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();

        }

        private void App_Load(object sender, EventArgs e)
        {
            //Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));


            AppTabs.Dock = DockStyle.Fill;
            AppTabs.Appearance = TabAppearance.FlatButtons;
            AppTabs.ItemSize = new Size(0, 1);
            AppTabs.SizeMode = TabSizeMode.Fixed;


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
           AppTabs.SelectedTab = RegisterTab;

        }



        /*     REGISTER     */
        private void LoginBtn1_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = LoginTab;
        }

        private void RegisterBtn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Register Successful");

        }

        private void CollectionBtn_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Collection;
            int colecao = 3;
            string projectDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\"));
            Boolean loaded = false;
            if (!loaded)
            {
                for (int i = 0; i < colecao; i++)
                {
                    PictureBox pic = new PictureBox();

                    string imageName = "charmander";
                    string imagePath = Path.Combine(projectDirectory, $"Imagens\\{imageName}.png");


                    pic.Image = Image.FromFile(imagePath);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Size = new Size(100, 100);

                    pic.Location = new Point(100 + i * 120, 100);

                    Label label = new Label();
                    label.Text = imageName;
                    label.Font = new Font("Arial", 11, FontStyle.Bold);
                    label.AutoSize = true;
                    label.Location = new Point(pic.Location.X, pic.Location.Y - label.Height);

                    Collection.Controls.Add(pic);
                    Collection.Controls.Add(label);
                }
                loaded = true;
            }


        }

        private void HomeTabTest_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }
    }
}
