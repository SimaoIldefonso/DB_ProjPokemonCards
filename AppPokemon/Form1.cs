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


            DeletePokeBTN.Location = new Point(Collection.Width - DeletePokeBTN.Width - 20, Collection.Height - DeletePokeBTN.Height - 20);

            // Configurar o tamanho e a posição dos componentes
            ConfigureCheckTradesComponents();

            CheckTradesBoxinfo.Text = "";
        }

        private SqlConnection getSGBDConnection()
        {// LAPTOP-S4H22GJP\SQLEXPRESS -Simão
            // LAPTOP-SCB9ONGM\\SQLEXPRESS - Mike
            return new SqlConnection("data source=LAPTOP-S4H22GJP\\SQLEXPRESS;integrated security=true;initial catalog=PokemonDB");
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
                cn.Open();

                // Verifica se o nome de usuário já existe na base de dados
                string checkUserQuery = "SELECT COUNT(*) FROM PokemonApp.Utilizadores WHERE Nome = @Nome";
                using (SqlCommand cmdCheckUser = new SqlCommand(checkUserQuery, cn))
                {
                    cmdCheckUser.Parameters.AddWithValue("@Nome", username);
                    int userExists = (int)cmdCheckUser.ExecuteScalar();
                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                        return;
                    }
                }

                // Insere novo usuário na base de dados
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
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }


        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            string username = UserNameInput.Text; // Nome de usuário fornecido
            string password = PasswordInput.Text; // Senha fornecida
            string hashedPassword = HashPassword(password); // Cifra a senha fornecida

            try
            {
                cn.Open();

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
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
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
            DisplayUserCollection();
            
        }
private void DisplayUserCollection()
{
    // Consulta agora inclui um JOIN para pegar informações de tipo e raridade
    string query = @"
        SELECT c.Nome_Carta, bc.Tipo, bc.Raridade 
        FROM PokemonApp.Carta c
        JOIN PokemonApp.BancoCartas bc ON c.Nome_Carta = bc.Nome_Carta
        WHERE c.ID_Utilizador = @ID_Utilizador";

    SqlCommand cmd = new SqlCommand(query, cn);
    cmd.Parameters.AddWithValue("@ID_Utilizador", currentUserID);

    Button backButton = new Button();
    backButton.Text = "Back to Home";
    backButton.Size = new Size(100, 30);
    backButton.Location = new Point(10, 10);
    backButton.Click += (sender, e) => { AppTabs.SelectedTab = Home; };

    try
    {
        cn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        Collection.Controls.Clear();
        Collection.Controls.Add(backButton);

        int cardWidth = 100;
        int cardHeight = 180; // increased height for additional text
        int margin = 10;
        int availableWidth = Collection.ClientSize.Width;
        int cardsPerRow = availableWidth / (cardWidth + margin);

        int x = margin, y = backButton.Bottom + margin;

        while (reader.Read())
        {
            string cardName = reader["Nome_Carta"].ToString();
            string cardType = reader["Tipo"].ToString();
            string rarity = reader["Raridade"].ToString();
            string rarityText = rarity;

            PictureBox pic = new PictureBox();
            pic.Image = LoadImageFromResources(cardName); // Assume you have this method implemented
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Size = new Size(100, 100);
            pic.Location = new Point(x, y);

            Label nameLabel = new Label();
            nameLabel.Text = cardName;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(x, y + pic.Height + 5);

            Label typeLabel = new Label();
            typeLabel.Text = "Tipo: " + cardType;
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(x, y + pic.Height + 20);

            Label rarityLabel = new Label();
            rarityLabel.Text = "Raridade: " + rarityText;
            rarityLabel.AutoSize = true;
            rarityLabel.Location = new Point(x, y + pic.Height + 35);

            Collection.Controls.Add(pic);
            Collection.Controls.Add(nameLabel);
            Collection.Controls.Add(typeLabel);
            Collection.Controls.Add(rarityLabel);

            x += pic.Width + margin;

            if ((x + cardWidth) > availableWidth) 
            {
                x = margin;
                y += cardHeight + margin;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("An error occurred while loading your collection: " + ex.Message);
    }
    finally
    {
        if (cn.State == ConnectionState.Open)
            cn.Close();
    }
}





        // Você precisa implementar este método ou ajustar conforme sua estrutura de diretórios e recursos
        private Image LoadImageFromResources(string cardName)
        {
            string imagesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Imagens");
            string imagePath = Path.Combine(imagesDirectory, cardName + ".png");
            if (File.Exists(imagePath))
                return Image.FromFile(imagePath);
            else
                return Image.FromFile(Path.Combine(imagesDirectory, "default.png"));  // Imagem padrão caso não encontre a específica
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
    
        private void LogoutBTN_Click(object sender, EventArgs e)
        {
            currentUsername = null;
            currentUserID = 0;

            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }

            cn = getSGBDConnection();
            cn.Open();

            AppTabs.SelectedTab = LoginTab;
        }

        private void OpenPackBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("PokemonApp.AbrirPack", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Utilizador", currentUserID);

                    cmd.ExecuteNonQuery(); // Executar o stored procedure que modifica os dados

                    // Recuperar as últimas 5 cartas adicionadas à coleção do usuário para exibição
                    string query = "SELECT TOP 5 Nome_Carta FROM PokemonApp.Carta WHERE ID_Utilizador = @ID_Utilizador ORDER BY ID_CartaUnica DESC";
                    using (SqlCommand cmdGetCards = new SqlCommand(query, cn))
                    {
                        cmdGetCards.Parameters.AddWithValue("@ID_Utilizador", currentUserID);
                        using (SqlDataReader reader = cmdGetCards.ExecuteReader())
                        {
                            string resultMessage = "You have opened a pack! Here are your new cards:\n";
                            while (reader.Read())
                            {
                                string cardName = reader["Nome_Carta"].ToString();
                                resultMessage += $"{cardName}\n";
                            }
                            MessageBox.Show(resultMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
    }
}
