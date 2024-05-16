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

            DeletePokeBTN.Location = new Point(Collection.Width - DeletePokeBTN.Width - 20, Collection.Height - DeletePokeBTN.Height - 20);






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

        private void CollectionBtn_Click(object sender, EventArgs e, Button button)
        {
            AppTabs.SelectedTab = Collection;
            string projectDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\")); // Adjust path as necessary
            string imagesDirectory = Path.Combine(projectDirectory, "Imagens");

            int pokemonsPerRow = 5; // Default value
            int pokemonWidth = 100;
            int pokemonHeight = 100;
            int spacing = 20;

            // Get the width and height of the screen
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calculate the number of pokemons per row dynamically based on screen width and pokemon size
            pokemonsPerRow = (screenWidth - spacing) / (pokemonWidth + spacing);

            // Calculate the starting position for displaying Pokémon PictureBox controls
            int startY = button.Location.Y + button.Height + spacing;

            if (!Collection.Controls.OfType<PictureBox>().Any()) // Check if images are already loaded
            {
                var imageFiles = Directory.GetFiles(imagesDirectory, "*.png"); // Get all PNG files in the folder
                for (int i = 0; i < imageFiles.Length; i++)
                {
                    PictureBox pic = new PictureBox();
                    string imagePath = imageFiles[i];
                    string imageName = Path.GetFileNameWithoutExtension(imagePath); // Get filename without extension

                    pic.Image = Image.FromFile(imagePath);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Size = new Size(pokemonWidth, pokemonHeight);

                    int row = i / pokemonsPerRow;
                    int col = i % pokemonsPerRow;

                    int x = spacing + col * (pokemonWidth + spacing);
                    int y = startY + row * (pokemonHeight + spacing);

                    pic.Location = new Point(x, y);

                    Label label = new Label();
                    label.Text = imageName;
                    label.Font = new Font("Arial", 11, FontStyle.Bold);
                    label.AutoSize = true;
                    label.Location = new Point(x, y - label.Height);

                    Collection.Controls.Add(pic);
                    Collection.Controls.Add(label);
                }
            }
        }

        //private int selectedPokemonID = -1;

        //private void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    if (selectedPokemonID != -1)
        //    {
        //        // Delete the selected Pokémon from the collection
        //        DeletePokemon(selectedPokemonID); // Replace this with your actual method to delete Pokémon from the collection
        //        MessageBox.Show("Pokemon deleted successfully!");
        //        // Reload the collection tab to reflect the changes
        //        CollectionBtn_Click(sender, e);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a Pokemon to delete.");
        //    }
        //}

        private void CollectionBtn_Click(object sender, EventArgs e)
        {
            CollectionBtn_Click(sender, e, button2);
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

        private void DeletePokeBTN_Click(object sender, EventArgs e)
        {
            // Query para dar delete, dependendo do selected pokemon (ver o metodo para selecionar o id deste)
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
