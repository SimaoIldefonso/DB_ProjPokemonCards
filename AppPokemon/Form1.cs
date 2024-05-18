﻿using System;
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
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace AppPokemon
{
    public partial class App : Form
    {
        private SqlConnection cn; // Variável de instância para conexão SQL
        private string currentUsername; // Variável de instância para armazenar o nome de usuário
        private int currentUserID; // Variável de instância para armazenar o ID do usuário

        public App()
        {
            InitializeComponent();
            cn = getSGBDConnection(); // Inicializar a conexão
        }

        private void App_Load(object sender, EventArgs e)
        {
            // Configurações iniciais
            AppTabs.Dock = DockStyle.Fill;
            AppTabs.Appearance = TabAppearance.FlatButtons;
            AppTabs.ItemSize = new Size(0, 1);
            AppTabs.SizeMode = TabSizeMode.Fixed;

            PasswordInput.PasswordChar = '*';
            PasswordInput1.PasswordChar = '*';
            ConfPasswordInput.PasswordChar = '*';

            DeletePokeBTN.Location = new Point(Collection.Width - DeletePokeBTN.Width - 20, Collection.Height - DeletePokeBTN.Height - 20);

            // Configurar o tamanho e a posição dos componentes
            ConfigureCheckTradesComponents();

            CheckTradesBoxinfo.Text = "";

            // Abrir a conexão com o banco de dados
            cn.Open();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source=LAPTOP-SCB9ONGM\\SQLEXPRESS;integrated security=true;initial catalog=PokemonDB");
        }

        private void ConfigureCheckTradesComponents()
        {
            // Dimensões da tela
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Cálculos das dimensões e posições
            int labelWidth = (int)(screenWidth * 0.45);  // 45% da largura da tela
            int labelHeight = (int)(screenHeight * 0.80);  // 80% da altura da tela

            int labelX = screenWidth - (int)(screenWidth * 0.10) - labelWidth;  // 10% da borda direita
            int labelY = (int)(screenHeight * 0.10);  // 10% do topo

            // Ajustar a posição e o tamanho da label CheckTradesLabelBackground
            CheckTradesLabelBackground.Location = new Point(labelX, labelY);
            CheckTradesLabelBackground.Size = new Size(labelWidth, labelHeight);

            // Posição e tamanho dos botões
            int buttonBottomMargin = (int)(screenHeight * 0.10);
            int refreshButtonRightMargin = (int)(screenWidth * 0.15);
            int makeChoiceButtonRightMargin = (int)(screenWidth * 0.25);

            RefreshBtnTrades.Location = new Point(screenWidth - refreshButtonRightMargin - RefreshBtnTrades.Width, screenHeight - buttonBottomMargin - RefreshBtnTrades.Height);
            MakeChoiseBtnTrade.Location = new Point(screenWidth - makeChoiceButtonRightMargin - MakeChoiseBtnTrade.Width, screenHeight - buttonBottomMargin - MakeChoiseBtnTrade.Height);

            // Posição e tamanho da label CheckTradesBoxinfo
            int labelInfoTopMargin = (int)(screenHeight * 0.15);
            int labelInfoRightMargin = (int)(screenWidth * 0.20);

            CheckTradesBoxinfo.Location = new Point(screenWidth - labelInfoRightMargin - CheckTradesBoxinfo.Width, labelInfoTopMargin);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void RegisterBtn1_Click(object sender, EventArgs e)
        {
            string username = UserNameInput1.Text;
            string password = PasswordInput1.Text;
            string confirmPassword = ConfPasswordInput.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            string hashedPassword = HashPassword(password);

            try
            {
                string query = "INSERT INTO PokemonApp.Utilizadores (Nome, Senha) VALUES (@Nome, @Senha)";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Nome", username);
                    cmd.Parameters.AddWithValue("@Senha", hashedPassword);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Register Successful");
                    }
                    else
                    {
                        MessageBox.Show("Error in registration. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            string username = UserNameInput.Text; // Nome de usuário fornecido
            string password = PasswordInput.Text; // Senha fornecida
            string hashedPassword = HashPassword(password); // Cifra a senha fornecida

            try
            {
                string query = "SELECT ID_Utilizador FROM PokemonApp.Utilizadores WHERE Nome = @Nome AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Nome", username);
                    cmd.Parameters.AddWithValue("@Senha", hashedPassword);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        currentUserID = (int)result; // Atualiza o ID do usuário na variável de instância
                        currentUsername = username; // Atualiza o nome de usuário na variável de instância
                        MessageBox.Show("Login Successful");
                        AppTabs.SelectedTab = Home; // Altera para a aba Home
                    }
                    else
                    {
                        MessageBox.Show("Login Failed. Please check your username and password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Accountbtn_Click(object sender, EventArgs e)
        {
            UsernameLabel.Text = currentUsername; // Atualiza a label com o nome de usuário atual
            IDUserLabel.Text = currentUserID.ToString(); // Atualiza a label com o ID do usuário atual
            AppTabs.SelectedTab = Account; // Muda para a aba Account
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = RegisterTab;
        }

        private void LoginBtn1_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = LoginTab;
        }

        private void deleteAccbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM PokemonApp.Utilizadores WHERE ID_Utilizador = @ID_Utilizador";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@ID_Utilizador", currentUserID);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Account deleted successfully.");
                        // Opcional: Redirecionar para a aba de login após exclusão
                        AppTabs.SelectedTab = LoginTab;
                        // Limpar variáveis de instância relacionadas ao usuário
                        currentUsername = null;
                        currentUserID = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error in deleting account. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void CollectionBtn_Click(object sender, EventArgs e, Button button)
        {
            AppTabs.SelectedTab = Collection;
            string projectDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\")); // Ajustar caminho conforme necessário
            string imagesDirectory = Path.Combine(projectDirectory, "Imagens");

            int pokemonsPerRow = 5; // Valor padrão
            int pokemonWidth = 100;
            int pokemonHeight = 100;
            int spacing = 20;

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            pokemonsPerRow = (screenWidth - spacing) / (pokemonWidth + spacing);
            int startY = button.Location.Y + button.Height + spacing;

            if (!Collection.Controls.OfType<PictureBox>().Any()) // Verificar se as imagens já estão carregadas
            {
                var imageFiles = Directory.GetFiles(imagesDirectory, "*.png"); // Obter todos os arquivos PNG na pasta
                for (int i = 0; i < imageFiles.Length; i++)
                {
                    PictureBox pic = new PictureBox();
                    string imagePath = imageFiles[i];
                    string imageName = Path.GetFileNameWithoutExtension(imagePath); // Obter nome do arquivo sem extensão

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

        private void CollectionBtn_Click(object sender, EventArgs e)
        {
            CollectionBtn_Click(sender, e, button2);
        }

        private void HomeTabTest_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }

        private void button3_Click(object sender, EventArgs e)
        {
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

        private void RefreshBtnTrades_Click(object sender, EventArgs e)
        {
            // Cabeçalho da tabela
            string header = String.Format("{0,-10}\t{1,-20}\t{2,-15}", "FriendID", "Friend's Pokemon", "Your Pokemon");
            // Linhas de trocas simuladas
            List<string> trades = new List<string>
            {
                String.Format("{0,-10}\t{1,-20}\t{2,-15}", "12345", "Charizard", "Pikachu"),
                String.Format("{0,-10}\t{1,-20}\t{2,-15}", "67890", "Squirtle", "Bulbasaur")
            };

            // Configurar o texto formatado
            string formattedText = header + Environment.NewLine;
            trades.ForEach(trade => formattedText += trade + Environment.NewLine);

            // Adicionar o texto à label CheckTradesBoxinfo com uma fonte monoespaçada
            CheckTradesBoxinfo.Font = new Font("Courier New", 15, FontStyle.Regular);
            CheckTradesBoxinfo.Text = formattedText;
        }

        private void OpenPackBtn_Click(object sender, EventArgs e)
        {
            string[] pokemonNames = { "Pikachu", "Charizard", "Squirtle", "Bulbasaur", "Jigglypuff", "Meowth" };

            for (int i = 0; i < pokemonNames.Length; i++)
            {
                string message = String.Format("You earned {0}!", pokemonNames[i]);
                MessageBox.Show(message);
            }
        }
    }
}
