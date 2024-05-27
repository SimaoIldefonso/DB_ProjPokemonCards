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
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace AppPokemon
{
    public partial class App : Form
    {
        private SqlConnection cn; 
        private string currentUsername; 
        private int currentUserID; 
        private Dictionary<int, string> rarityMap = new Dictionary<int, string>
        {
            {0, "Comum"},
            {1, "Raro"},
            {2, "Épico"},
            {3, "Lendário"}
        };
        private Dictionary<string, int> userPokemonMap = new Dictionary<string, int>();
        private Dictionary<string, int> friendPokemonMap = new Dictionary<string, int>();
        private Panel cardsPanel; // Mantenha o painel como uma variável de instância


        public App()
        {
            InitializeComponent();
            InitializeCustomListBox();
            cn = getSGBDConnection(); // Inicializar a conexão
        }

        private void InitializeCustomListBox()
        {
            listBoxTrades.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxTrades.MeasureItem += ListBoxTrades_MeasureItem;
            listBoxTrades.DrawItem += ListBoxTrades_DrawItem;
        }

        private void ListBoxTrades_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                string text = listBoxTrades.Items[e.Index].ToString();
                SizeF size = e.Graphics.MeasureString(text, listBoxTrades.Font, listBoxTrades.Width);
                e.ItemHeight = (int)size.Height;
            }
        }

        private void ListBoxTrades_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                string text = listBoxTrades.Items[e.Index].ToString();
                e.Graphics.DrawString(text, listBoxTrades.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void App_Load(object sender, EventArgs e)
        {
            // Configurações iniciais
            AppTabs.Dock = DockStyle.Fill;
            AppTabs.Appearance = TabAppearance.FlatButtons;
            AppTabs.ItemSize = new Size(0, 1);
            AppTabs.SizeMode = TabSizeMode.Fixed;


            // Configurar o tamanho e a posição dos componentes
            ConfigureCheckTradesComponents();

            CheckTradesBoxinfo.Text = "";
            InitializeOpenPackPanel();
            HistoryPanel.SendToBack();
        }

        private SqlConnection getSGBDConnection()
        {// LAPTOP-S4H22GJP\SQLEXPRESS -Simão
            // LAPTOP-SCB9ONGM\\SQLEXPRESS - Mike
            return new SqlConnection("data source=LAPTOP-S4H22GJP\\SQLEXPRESS;integrated security=true;initial catalog=PokemonDB");
        }

        

        private void ConfigureCheckTradesComponents()
        {
            SetupTradeListView();
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
        private void InitializeOpenPackPanel()
        {
            if (cardsPanel == null)
            {
                cardsPanel = new Panel
                {
                    Location = new Point(10, OpenPackBtn.Bottom + 10),
                    Size = new Size(this.ClientSize.Width - 20, 200),
                    AutoScroll = true
                };
                this.Controls.Add(cardsPanel); // Adicione o painel apenas uma vez
            }
        }
        private void RegisterBtn1_Click(object sender, EventArgs e)
        {
            string username = UserNameInput1.Text;
            string password = PasswordInput1.Text;
            string confirmPassword = ConfPasswordInput.Text;

            if (username.Length < 3 || password.Length < 3)
            {
                MessageBox.Show("Username and password must be at least 3 characters long.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("PokemonApp.RegisterUser", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);  // Send the plaintext password

                    SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);

                    cmd.ExecuteNonQuery();

                    string resultMessage = messageParam.Value.ToString();
                    MessageBox.Show(resultMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }





        private PictureBox selectedPokemon = null;

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (selectedPokemon != null)
            {
                selectedPokemon.BorderStyle = BorderStyle.None; // Remove a borda do anteriormente selecionado
            }
            PictureBox pic = sender as PictureBox;
            pic.BorderStyle = BorderStyle.Fixed3D; // Adiciona borda ao clicado
            selectedPokemon = pic;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedPokemon != null)
            {
                DeleteSelectedPokemon((int)selectedPokemon.Tag);
            }
            else
            {
                MessageBox.Show("Please select a Pokemon to delete.");
            }
        }

        private void DeleteSelectedPokemon(int pokemonId)
        {
            try
            {
                // Usar o bloco using aqui garante que a conexão seja fechada após o uso
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                using (SqlCommand cmd = new SqlCommand("PokemonApp.DescartarCarta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_CartaUnica", pokemonId);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Pokemon deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete Pokemon.");
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
                    cn.Close(); // Garantir que a conexão é fechada antes de chamar DisplayUserCollection
            }

            DisplayUserCollection();  // Chamar fora do finally para evitar abrir a conexão enquanto ainda está em um bloco de fechamento
        }

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            string username = UserNameInput.Text;
            string password = PasswordInput.Text;

            if (username.Length < 3 || password.Length < 3)
            {
                MessageBox.Show("Username and password must be at least 3 characters long.");
                return;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("PokemonApp.LoginUser", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlParameter userIdParam = new SqlParameter("@UserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(userIdParam);
                    cmd.Parameters.Add(messageParam);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    if (userIdParam.Value != DBNull.Value)
                    {
                        currentUserID = (int)userIdParam.Value;
                        currentUsername = username;
                        AppTabs.SelectedTab = Home; // Muda para a aba Home se o login for bem-sucedido
                    }
                    MessageBox.Show(messageParam.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }





        private void Accountbtn_Click(object sender, EventArgs e)
        {
            UsernameLabel.Text = currentUsername; // Atualiza a label com o nome de usuário atual
            IDUserLabel.Text = currentUserID.ToString(); // Atualiza a label com o ID do usuário atual
            UpdateCardCounts(); 
            AppTabs.SelectedTab = Account; // Muda para a aba Account
        }
        private void UpdateCardCounts()
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                string message = "Your card counts by rarity:\n";

                for (int rarity = 0; rarity <= 3; rarity++)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT dbo.CountCardsByRarity(@UserID, @Rarity)", cn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserID);
                        cmd.Parameters.AddWithValue("@Rarity", rarity);

                        int count = (int)cmd.ExecuteScalar();
                        string rarityName = rarityMap.ContainsKey(rarity) ? rarityMap[rarity] : "Unknown";
                        message += $"{rarityName}: {count}\n";
                    }
                }

                quantidadeLabel.Text = message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error Updating Card Counts");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
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
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                using (SqlCommand cmd = new SqlCommand("PokemonApp.DeleteUserAndAllAssociations", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", currentUserID);

                    int result = cmd.ExecuteNonQuery(); // Executa o stored procedure
                    if (result >= 0)
                    {
                        MessageBox.Show("Account and all associated records deleted successfully.");
                        currentUsername = null;
                        currentUserID = 0;
                        AppTabs.SelectedTab = LoginTab;
                    }
                    else
                    {
                        MessageBox.Show("No records found to delete.");
                    }
                }
                UserNameInput.Text = "";
                PasswordInput.Text = "";
                UserNameInput1.Text = "";
                PasswordInput1.Text = "";
                ConfPasswordInput.Text = "";
                AppTabs.SelectedTab = LoginTab;
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

        private void CollectionBtn_Click(object sender, EventArgs e, Button button)
        {
            AppTabs.SelectedTab = Collection;
            DisplayUserCollection();
            
        }
        private void SetupDeleteButton()
        {
            Button deleteBtn = new Button();
            deleteBtn.Text = "Delete Pokemon";
            deleteBtn.Size = new Size(150, 30);
            deleteBtn.Location = new Point(Collection.Width - deleteBtn.Width - 10, 10);
            deleteBtn.Click += DeleteBtn_Click;  // Evento Click que chamará o método de deleção
            Collection.Controls.Add(deleteBtn);
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            // Handle the home button click event
            AppTabs.SelectedTab = Home; // Assuming "Home" is the name of the tab/page you want to navigate to
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            if (searchBox.Text != "Search Pokémon..." && !string.IsNullOrWhiteSpace(searchBox.Text))
            {
                DisplayUserCollection(searchBox.Text);
            }
            else
            {
                DisplayUserCollection();  // Chamada sem parâmetros para mostrar todos os Pokémons
            }
        }

        private void DisplayUserCollection(string searchText = "")
        {
            // Definindo a Search Box caso não exista
            TextBox searchBox = Collection.Controls["searchBox"] as TextBox;
            if (searchBox == null)
            {
                searchBox = new TextBox();
                searchBox.Name = "searchBox";
                searchBox.Size = new Size(200, 20);
                searchBox.Location = new Point(10, 10);  // Ajuste conforme necessário
                searchBox.Font = new Font("Microsoft Sans Serif", 10);
                searchBox.ForeColor = Color.Gray;
                searchBox.Text = "Search Pokémon...";

                searchBox.GotFocus += (sender, args) =>
                {
                    if (searchBox.Text == "Search Pokémon...")
                    {
                        searchBox.Text = "";
                        searchBox.ForeColor = Color.Black;
                    }
                };
                searchBox.LostFocus += (sender, args) =>
                {
                    if (string.IsNullOrWhiteSpace(searchBox.Text))
                    {
                        searchBox.Text = "Search Pokémon...";
                        searchBox.ForeColor = Color.Gray;
                    }
                };
                searchBox.TextChanged += (sender, args) =>
                {
                    if (searchBox.Text != "Search Pokémon..." && searchBox.Text != "")
                        DisplayUserCollection(searchBox.Text);
                    else
                        DisplayUserCollection("");  // Limpa o filtro se o texto for o placeholder ou estiver vazio
                };

                Collection.Controls.Add(searchBox);
            }

            SetupDeleteButton();


            // Configurando o comando SQL para usar a stored procedure correta
            using (SqlCommand cmd = new SqlCommand("PokemonApp.GetUserCollection", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", currentUserID);
                cmd.Parameters.AddWithValue("@SearchTerm", string.IsNullOrEmpty(searchText) ? DBNull.Value : (object)searchText);

                // Garante que a conexão esteja aberta
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Panel scrollPanel = Collection.Controls["scrollPanel"] as Panel;
                    if (scrollPanel == null)
                    {
                        scrollPanel = new Panel();
                        scrollPanel.Name = "scrollPanel";
                        scrollPanel.Location = new Point(10, searchBox.Bottom + 10);
                        scrollPanel.Size = new Size(Collection.ClientSize.Width - 20, Collection.ClientSize.Height - searchBox.Height - 20);
                        scrollPanel.AutoScroll = true;
                        Collection.Controls.Add(scrollPanel);
                    }
                    else
                    {
                        scrollPanel.Controls.Clear(); // Limpa os controles existentes antes de adicionar novos
                    }

                    int x = 10, y = 10; // Posição inicial para os PictureBoxes dentro do scrollPanel
                    while (reader.Read())
                    {
                        int cardId = reader.GetInt32(0);
                        string cardName = reader.GetString(1);
                        string cardType = reader.GetString(2);
                        int rarityValue = reader.GetInt32(3);
                        string rarityText = rarityMap.ContainsKey(rarityValue) ? rarityMap[rarityValue] : "Desconhecido";

                        PictureBox pic = new PictureBox();
                        pic.Image = LoadImageFromResources(cardName);  // Assume que você tem uma função para carregar imagens baseada no nome
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Size = new Size(100, 100);
                        pic.Location = new Point(x, y);
                        pic.Click += PictureBox_Click;  // Assume que você tem um manipulador de eventos para clique
                        pic.Tag = cardId;

                        Label nameLabel = new Label { Text = cardName, AutoSize = true, Location = new Point(x, y + pic.Height + 5) };
                        Label typeLabel = new Label { Text = "Tipo: " + cardType, AutoSize = true, Location = new Point(x, y + pic.Height + 20) };
                        Label rarityLabel = new Label { Text = "Raridade: " + rarityText, AutoSize = true, Location = new Point(x, y + pic.Height + 35) };
                        Label cardIdLabel = new Label { Text = "ID " + cardId, AutoSize = true, Location = new Point(x, y + pic.Height + 50) };

                        scrollPanel.Controls.Add(pic);
                        scrollPanel.Controls.Add(nameLabel);
                        scrollPanel.Controls.Add(typeLabel);
                        scrollPanel.Controls.Add(rarityLabel);
                        scrollPanel.Controls.Add(cardIdLabel);

                        x += pic.Width + 10;
                        if (x + pic.Width > scrollPanel.ClientSize.Width)
                        {
                            x = 10;  // Reseta a posição x para a margem esquerda
                            y += pic.Height + 65;  // Move para baixo antes de começar uma nova linha
                        }
                    }
                }
            }

            // Fechar a conexão após completar a operação
            if (cn.State == ConnectionState.Open)
                cn.Close();
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
            label6.Text = currentUserID.ToString();
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            LoadUserPokemons();
            LoadPendingTrades();
            //DisplayTradeHistory();
            AppTabs.SelectedTab = Trade;
            DisplayTrocasHistBTN.BringToFront();
        }

        private void HomebtnAccount_Click(object sender, EventArgs e)
        {
            AppTabs.SelectedTab = Home;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RefreshBtnTrades_Click(object sender, EventArgs e)
        {
            LoadPendingTrades();
        }

        private void LogoutBTN_Click(object sender, EventArgs e)
        {
            currentUsername = null;
            currentUserID = 0;

            if (cn != null)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose(); 
            }

            cn = getSGBDConnection();
            UserNameInput.Text = "";
            PasswordInput.Text = "";
            UserNameInput1.Text = "";
            PasswordInput1.Text = "";
            ConfPasswordInput.Text = "";
            cardsListBox.Items.Clear();

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

                    cmd.ExecuteNonQuery(); // Execute the stored procedure that modifies the data

                    // Retrieve the last 5 cards added to the user's collection for display
                    string query = "SELECT TOP 5 Nome_Carta FROM PokemonApp.Carta WHERE ID_Utilizador = @ID_Utilizador ORDER BY ID_CartaUnica DESC";
                    using (SqlCommand cmdGetCards = new SqlCommand(query, cn))
                    {
                        cmdGetCards.Parameters.AddWithValue("@ID_Utilizador", currentUserID);
                        using (SqlDataReader reader = cmdGetCards.ExecuteReader())
                        {
                            List<string> newCards = new List<string>();
                            string resultMessage = "You have opened a pack! Here are your new cards:\n";
                            while (reader.Read())
                            {
                                string cardName = reader["Nome_Carta"].ToString();
                                newCards.Add(cardName);
                                resultMessage += $"{cardName}\n";
                            }

                            MessageBox.Show(resultMessage); // Display message with new cards

                            // Update the existing ListBox with new cards
                            ListBox listBox = OpenPacksTab.Controls["cardsListBox"] as ListBox; // Make sure the name matches
                            if (listBox != null)
                            {
                                listBox.Items.Clear(); // Clear previous items
                                foreach (string card in newCards)
                                {
                                    listBox.Items.Add(card); // Add new cards to the ListBox
                                }
                            }
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

        /* ------------- Parte das Trocas ---------------*/
        private void LoadUserPokemons()
        {
            using (var cmd = new SqlCommand("PokemonApp.GetPokemonsByUser", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", currentUserID);

                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    comboBox1.Items.Clear();
                    userPokemonMap.Clear();
                    while (reader.Read())
                    {
                        string name = reader["Nome_Carta"].ToString();
                        int id = reader.GetInt32(0);
                        string displayText = $"{name} ID: {id}"; 
                        comboBox1.Items.Add(displayText); 
                        userPokemonMap[name] = id;
                    }
                }
                cn.Close();
            }
        }
        private bool CheckUserExists(int userID)
        {
            using (var connection = getSGBDConnection())  // Usando a conexão definida no seu código.
            {
                using (var cmd = new SqlCommand("PokemonApp.CheckUserExists", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();
                    int userCount = (int)cmd.ExecuteScalar();  // Executa a query e retorna a primeira coluna da primeira linha no conjunto de resultados retornado pela query. Outras colunas ou linhas são ignoradas.
                    connection.Close();

                    return userCount > 0;  // Retorna true se o usuário existe.
                }
            }
        }


        private void CheckFriendBTN_Click(object sender, EventArgs e)
        {
            int friendID;
            if (int.TryParse(textBox1.Text, out friendID))
            {
                if (CheckUserExists(friendID))
                {
                    LoadFriendPokemons(friendID);
                }
                else
                {
                    MessageBox.Show("Friend ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFriendPokemons(int friendID)
        {
            using (var cmd = new SqlCommand("PokemonApp.GetPokemonsByUser", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", friendID);

                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    comboBox2.Items.Clear();
                    friendPokemonMap.Clear();
                    while (reader.Read())
                    {
                        string name = reader["Nome_Carta"].ToString();
                        int id = reader.GetInt32(0);
                        string displayText = $"{name} ID: {id}"; // Combining the name and ID
                        comboBox2.Items.Add(displayText); // Adding the combined string to the comboBox
                        friendPokemonMap[displayText] = id; // Using the displayText as key for map
                    }
                }
                cn.Close();
            }
        }
        private void SendTradeBTN_Click(object sender, EventArgs e)
        {
            // This assumes that the selected item's string is of the format "Name ID: X"
            string selectedPokemonNameWithId = comboBox1.SelectedItem?.ToString();
            string selectedFriendPokemonNameWithId = comboBox2.SelectedItem?.ToString();

            if (selectedPokemonNameWithId == null || selectedFriendPokemonNameWithId == null)
            {
                MessageBox.Show("Please select a Pokémon from both lists.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extract the ID from the selected item string
            int selectedCardID1 = ExtractIdFromName(selectedPokemonNameWithId);
            int selectedCardID2 = ExtractIdFromName(selectedFriendPokemonNameWithId);

            // Additional check if IDs were extracted correctly
            if (selectedCardID1 == -1 || selectedCardID2 == -1)
            {
                MessageBox.Show("Failed to find selected Pokémon IDs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int friendID = int.Parse(textBox1.Text);
            CreateTrade(currentUserID, friendID, selectedCardID1, selectedCardID2);
        }

        private void DisplayTradeHistory()
        {
            using (var cmd = new SqlCommand("PokemonApp.GetUserTradeHistory", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", currentUserID);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No trades have been conducted by this user.", "Trade History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataGridView dgv = new DataGridView
                    {
                        DataSource = dt,
                        Dock = DockStyle.Fill,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        ReadOnly = true,
                        AllowUserToAddRows = false,
                        AllowUserToDeleteRows = false
                    };

                    HistoryPanel.Controls.Clear();
                    HistoryPanel.Controls.Add(dgv);
                }
            }
        }

        private int ExtractIdFromName(string nameWithId)
        {
            // Assuming the format is "Name ID: X"
            int idStart = nameWithId.LastIndexOf("ID: ") + 4; // Get index position after "ID: "
            if (idStart > 3) // Means "ID: " was found
            {
                string idSubstring = nameWithId.Substring(idStart);
                if (int.TryParse(idSubstring, out int id))
                {
                    return id;
                }
            }
            return -1; // Return -1 if parsing fails or "ID: " was not found
        }

        private void CreateTrade(int user1ID, int user2ID, int card1ID, int card2ID)
        {
            using (var cmd = new SqlCommand("PokemonApp.CreateTrade", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID1", user1ID);
                cmd.Parameters.AddWithValue("@UserID2", user2ID);
                cmd.Parameters.AddWithValue("@CardUniqueID1", card1ID);
                cmd.Parameters.AddWithValue("@CardUniqueID2", card2ID);

                cn.Open();
                var result = cmd.ExecuteScalar();
                cn.Close();

                if (result != null)
                {
                    MessageBox.Show($"Trade request sent successfully! Trade ID: {result}", "Trade Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to create trade request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPendingTrades()
        {
            using (var cmd = new SqlCommand("PokemonApp.GetPendingTradesForUser", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", currentUserID);

                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    listBoxTrades.Items.Clear();
                    while (reader.Read())
                    {
                        var tradeInfo = $"Trade ID: {reader["ID_Troca"]}, Offered By: {reader["OfferedBy"]}, " +
                                        $"Offered Card: {reader["OfferedCard"]}, Requested Card: {reader["RequestedCard"]}, " +
                                        $"Status: {((int)reader["Estado_Troca"] == 0 ? "Pending" : "Resolved")}";
                        listBoxTrades.Items.Add(tradeInfo);
                    }
                }
                cn.Close();
            }
        }

        private void SetupTradeListView()
        {
            // Configuração inicial do ListBox
            listBoxTrades.Location = new Point((int)(this.Width * 0.41), listBoxTrades.Location.Y);  // Ajuste para 10% da borda direita
            listBoxTrades.Width = (int)(this.Width * 0.29);
            // ajusta para 30% da altura da tela
            listBoxTrades.Height = (int)(this.Height * 0.45);
        }

        private void MakeChoiseBtnTrade_Click(object sender, EventArgs e)
        {
            if (listBoxTrades.SelectedItem != null)
            {
                string selectedTrade = listBoxTrades.SelectedItem.ToString();
                int tradeId = int.Parse(selectedTrade.Split(',')[0].Split(':')[1].Trim());  // Extraindo o ID da troca da string selecionada

                var result = MessageBox.Show("Do you want to accept the trade?", "Confirm Trade", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Primeiro mostra a mensagem de confirmação
                    MessageBox.Show("Trade will be processed.", "Trade Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Depois processa a troca
                    AcceptTrade(tradeId);
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Trade will be rejected.", "Trade Rejection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RejectTrade(tradeId);
                }
            }
            else
            {
                MessageBox.Show("Please select a trade first.", "No Trade Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AcceptTrade(int tradeId)
        {
            using (var connection = getSGBDConnection())
            using (var cmd = new SqlCommand("PokemonApp.AcceptTrade", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TradeID", tradeId);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    // Mensagem de sucesso após a execução bem-sucedida da troca
                    MessageBox.Show("Trade accepted successfully.", "Trade Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingTrades(); // Atualiza a lista de trocas após aceitar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error accepting trade: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void RejectTrade(int tradeId)
        {
            using (var connection = getSGBDConnection())
            using (var cmd = new SqlCommand("PokemonApp.RejectTrade", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TradeID", tradeId);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    // Mensagem de sucesso após a execução bem-sucedida da rejeição da troca
                    MessageBox.Show("Trade rejected successfully.", "Trade Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingTrades(); // Atualiza a lista de trocas após rejeitar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error rejecting trade: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void DisplayTrocasHistBTN_Click(object sender, EventArgs e)
        {
            DisplayTradeHistory();
        }
    }
}
