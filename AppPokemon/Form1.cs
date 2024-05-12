using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            
            MessageBox.Show("Login Successful");
            //display password
            MessageBox.Show(PasswordInput.Text);
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
            string projectDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\"));
            string imagesDirectory = Path.Combine(projectDirectory, "Imagens");

            if (!Collection.Controls.OfType<PictureBox>().Any()) // Verifica se já carregou as imagens anteriormente
            {
                var imageFiles = Directory.GetFiles(imagesDirectory, "*.png"); // Obtém todos os arquivos PNG na pasta
                for (int i = 0; i < imageFiles.Length; i++)
                {
                    PictureBox pic = new PictureBox();
                    string imagePath = imageFiles[i];
                    string imageName = Path.GetFileNameWithoutExtension(imagePath); // Obtém o nome do arquivo sem a extensão

                    pic.Image = Image.FromFile(imagePath);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Size = new Size(100, 100);
                    pic.Location = new Point(100 + i * 120, 100); // Alterar conforme necessário para evitar sobreposição

                    Label label = new Label();
                    label.Text = imageName;
                    label.Font = new Font("Arial", 11, FontStyle.Bold);
                    label.AutoSize = true;
                    label.Location = new Point(pic.Location.X, pic.Location.Y - label.Height);

                    Collection.Controls.Add(pic);
                    Collection.Controls.Add(label);
                }
            }
        }


    

    private void HomeTabTest_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }

        private void button3_Click(object sender, EventArgs e)
        {//change to OpenPacks Tab
            AppTabs.SelectedTab = OpenPacksTab;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }

        private void homebtnTrade_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }

        private void homebtnOpen_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }

        private void Tradesbtn_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Trade;

        }

        private void Accountbtn_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Account;
        }

        private void HomebtnAccount_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }


    }
}
