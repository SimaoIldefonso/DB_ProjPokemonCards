namespace AppPokemon
{
    partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.UserNameInput = new System.Windows.Forms.TextBox();
            this.UsernameTxt = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.AppTabs = new System.Windows.Forms.TabControl();
            this.LoginTab = new System.Windows.Forms.TabPage();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.RegisterTab = new System.Windows.Forms.TabPage();
            this.RegisterBtn1 = new System.Windows.Forms.Button();
            this.LoginBtn1 = new System.Windows.Forms.Button();
            this.ConfPasswordInput = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordtxt = new System.Windows.Forms.Label();
            this.PasswordInput1 = new System.Windows.Forms.TextBox();
            this.PasswordTxt1 = new System.Windows.Forms.Label();
            this.UserNameInput1 = new System.Windows.Forms.TextBox();
            this.UsernameTxt1 = new System.Windows.Forms.Label();
            this.Home = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CollectionBtn = new System.Windows.Forms.Button();
            this.Collection = new System.Windows.Forms.TabPage();
            this.Trade = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.AddFriends = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.HomeTabTest = new System.Windows.Forms.Button();
            this.AppTabs.SuspendLayout();
            this.LoginTab.SuspendLayout();
            this.RegisterTab.SuspendLayout();
            this.Home.SuspendLayout();
            this.Trade.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNameInput
            // 
            this.UserNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameInput.Location = new System.Drawing.Point(684, 215);
            this.UserNameInput.Name = "UserNameInput";
            this.UserNameInput.PasswordChar = 'a';
            this.UserNameInput.Size = new System.Drawing.Size(115, 23);
            this.UserNameInput.TabIndex = 1;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.AutoSize = true;
            this.UsernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt.Location = new System.Drawing.Point(571, 217);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(83, 20);
            this.UsernameTxt.TabIndex = 2;
            this.UsernameTxt.Text = "Username";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.AutoSize = true;
            this.PasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.Location = new System.Drawing.Point(576, 256);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(78, 20);
            this.PasswordTxt.TabIndex = 3;
            this.PasswordTxt.Text = "Password";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Location = new System.Drawing.Point(684, 254);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(115, 23);
            this.PasswordInput.TabIndex = 4;
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn.Location = new System.Drawing.Point(552, 383);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(111, 47);
            this.RegisterBtn.TabIndex = 5;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // AppTabs
            // 
            this.AppTabs.Controls.Add(this.LoginTab);
            this.AppTabs.Controls.Add(this.RegisterTab);
            this.AppTabs.Controls.Add(this.Home);
            this.AppTabs.Controls.Add(this.Collection);
            this.AppTabs.Controls.Add(this.Trade);
            this.AppTabs.Controls.Add(this.tabPage4);
            this.AppTabs.Controls.Add(this.tabPage5);
            this.AppTabs.Location = new System.Drawing.Point(0, -3);
            this.AppTabs.Name = "AppTabs";
            this.AppTabs.SelectedIndex = 0;
            this.AppTabs.Size = new System.Drawing.Size(1516, 822);
            this.AppTabs.TabIndex = 6;
            this.AppTabs.TabStop = false;
            // 
            // LoginTab
            // 
            this.LoginTab.BackColor = System.Drawing.Color.DarkGray;
            this.LoginTab.Controls.Add(this.HomeTabTest);
            this.LoginTab.Controls.Add(this.LoginBtn);
            this.LoginTab.Controls.Add(this.UserNameInput);
            this.LoginTab.Controls.Add(this.RegisterBtn);
            this.LoginTab.Controls.Add(this.UsernameTxt);
            this.LoginTab.Controls.Add(this.PasswordInput);
            this.LoginTab.Controls.Add(this.PasswordTxt);
            this.LoginTab.Location = new System.Drawing.Point(4, 25);
            this.LoginTab.Name = "LoginTab";
            this.LoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginTab.Size = new System.Drawing.Size(1508, 793);
            this.LoginTab.TabIndex = 0;
            this.LoginTab.Text = "Login";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.Location = new System.Drawing.Point(695, 383);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(104, 47);
            this.LoginBtn.TabIndex = 6;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            // 
            // RegisterTab
            // 
            this.RegisterTab.BackColor = System.Drawing.Color.DarkGray;
            this.RegisterTab.Controls.Add(this.RegisterBtn1);
            this.RegisterTab.Controls.Add(this.LoginBtn1);
            this.RegisterTab.Controls.Add(this.ConfPasswordInput);
            this.RegisterTab.Controls.Add(this.ConfirmPasswordtxt);
            this.RegisterTab.Controls.Add(this.PasswordInput1);
            this.RegisterTab.Controls.Add(this.PasswordTxt1);
            this.RegisterTab.Controls.Add(this.UserNameInput1);
            this.RegisterTab.Controls.Add(this.UsernameTxt1);
            this.RegisterTab.Location = new System.Drawing.Point(4, 25);
            this.RegisterTab.Name = "RegisterTab";
            this.RegisterTab.Padding = new System.Windows.Forms.Padding(3);
            this.RegisterTab.Size = new System.Drawing.Size(1508, 793);
            this.RegisterTab.TabIndex = 1;
            this.RegisterTab.Text = "Register";
            // 
            // RegisterBtn1
            // 
            this.RegisterBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn1.Location = new System.Drawing.Point(552, 383);
            this.RegisterBtn1.Name = "RegisterBtn1";
            this.RegisterBtn1.Size = new System.Drawing.Size(111, 47);
            this.RegisterBtn1.TabIndex = 7;
            this.RegisterBtn1.Text = "Register";
            this.RegisterBtn1.UseVisualStyleBackColor = true;
            this.RegisterBtn1.Click += new System.EventHandler(this.RegisterBtn1_Click);
            // 
            // LoginBtn1
            // 
            this.LoginBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn1.Location = new System.Drawing.Point(695, 383);
            this.LoginBtn1.Name = "LoginBtn1";
            this.LoginBtn1.Size = new System.Drawing.Size(104, 47);
            this.LoginBtn1.TabIndex = 6;
            this.LoginBtn1.Text = "Login";
            this.LoginBtn1.UseVisualStyleBackColor = true;
            this.LoginBtn1.Click += new System.EventHandler(this.LoginBtn1_Click);
            // 
            // ConfPasswordInput
            // 
            this.ConfPasswordInput.Location = new System.Drawing.Point(684, 291);
            this.ConfPasswordInput.Name = "ConfPasswordInput";
            this.ConfPasswordInput.Size = new System.Drawing.Size(115, 22);
            this.ConfPasswordInput.TabIndex = 5;
            // 
            // ConfirmPasswordtxt
            // 
            this.ConfirmPasswordtxt.AutoSize = true;
            this.ConfirmPasswordtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordtxt.Location = new System.Drawing.Point(517, 293);
            this.ConfirmPasswordtxt.Name = "ConfirmPasswordtxt";
            this.ConfirmPasswordtxt.Size = new System.Drawing.Size(137, 20);
            this.ConfirmPasswordtxt.TabIndex = 4;
            this.ConfirmPasswordtxt.Text = "Confirm Password";
            // 
            // PasswordInput1
            // 
            this.PasswordInput1.Location = new System.Drawing.Point(684, 254);
            this.PasswordInput1.Name = "PasswordInput1";
            this.PasswordInput1.Size = new System.Drawing.Size(115, 22);
            this.PasswordInput1.TabIndex = 3;
            // 
            // PasswordTxt1
            // 
            this.PasswordTxt1.AutoSize = true;
            this.PasswordTxt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt1.Location = new System.Drawing.Point(576, 256);
            this.PasswordTxt1.Name = "PasswordTxt1";
            this.PasswordTxt1.Size = new System.Drawing.Size(78, 20);
            this.PasswordTxt1.TabIndex = 2;
            this.PasswordTxt1.Text = "Password";
            // 
            // UserNameInput1
            // 
            this.UserNameInput1.Location = new System.Drawing.Point(684, 215);
            this.UserNameInput1.Name = "UserNameInput1";
            this.UserNameInput1.Size = new System.Drawing.Size(115, 22);
            this.UserNameInput1.TabIndex = 1;
            // 
            // UsernameTxt1
            // 
            this.UsernameTxt1.AutoSize = true;
            this.UsernameTxt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt1.Location = new System.Drawing.Point(571, 217);
            this.UsernameTxt1.Name = "UsernameTxt1";
            this.UsernameTxt1.Size = new System.Drawing.Size(83, 20);
            this.UsernameTxt1.TabIndex = 0;
            this.UsernameTxt1.Text = "Username";
            // 
            // Home
            // 
            this.Home.Controls.Add(this.label1);
            this.Home.Controls.Add(this.button1);
            this.Home.Controls.Add(this.button5);
            this.Home.Controls.Add(this.button4);
            this.Home.Controls.Add(this.button3);
            this.Home.Controls.Add(this.CollectionBtn);
            this.Home.Location = new System.Drawing.Point(4, 25);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(1508, 793);
            this.Home.TabIndex = 2;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(527, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 46);
            this.label1.TabIndex = 6;
            this.label1.Text = "PokemonTradingApp";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(484, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "Trades";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(850, 246);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 46);
            this.button5.TabIndex = 4;
            this.button5.Text = "Account";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(572, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 46);
            this.button4.TabIndex = 3;
            this.button4.Text = "Friends";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(774, 343);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "OpenPacks";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // CollectionBtn
            // 
            this.CollectionBtn.Location = new System.Drawing.Point(660, 246);
            this.CollectionBtn.Name = "CollectionBtn";
            this.CollectionBtn.Size = new System.Drawing.Size(122, 46);
            this.CollectionBtn.TabIndex = 1;
            this.CollectionBtn.Text = "Collection";
            this.CollectionBtn.UseVisualStyleBackColor = true;
            this.CollectionBtn.Click += new System.EventHandler(this.CollectionBtn_Click);
            // 
            // Collection
            // 
            this.Collection.Location = new System.Drawing.Point(4, 25);
            this.Collection.Name = "Collection";
            this.Collection.Padding = new System.Windows.Forms.Padding(3);
            this.Collection.Size = new System.Drawing.Size(1508, 793);
            this.Collection.TabIndex = 3;
            this.Collection.Text = "CollectionTab";
            this.Collection.UseVisualStyleBackColor = true;
            // 
            // Trade
            // 
            this.Trade.Controls.Add(this.button9);
            this.Trade.Controls.Add(this.button8);
            this.Trade.Location = new System.Drawing.Point(4, 25);
            this.Trade.Name = "Trade";
            this.Trade.Padding = new System.Windows.Forms.Padding(3);
            this.Trade.Size = new System.Drawing.Size(1508, 793);
            this.Trade.TabIndex = 4;
            this.Trade.Text = "TradeTab";
            this.Trade.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(812, 246);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(122, 46);
            this.button9.TabIndex = 1;
            this.button9.Text = "New trade";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(514, 246);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(122, 46);
            this.button8.TabIndex = 0;
            this.button8.Text = "Check tades";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1508, 793);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "OpenPacksTab";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(607, 265);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(122, 46);
            this.button7.TabIndex = 0;
            this.button7.Text = "Open a new pack";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.AddFriends);
            this.tabPage5.Controls.Add(this.button6);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1508, 793);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "FriendsTab";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // AddFriends
            // 
            this.AddFriends.Location = new System.Drawing.Point(771, 391);
            this.AddFriends.Name = "AddFriends";
            this.AddFriends.Size = new System.Drawing.Size(122, 46);
            this.AddFriends.TabIndex = 1;
            this.AddFriends.Text = "Add Friends";
            this.AddFriends.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(735, 255);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(122, 46);
            this.button6.TabIndex = 0;
            this.button6.Text = "Friend List";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // HomeTabTest
            // 
            this.HomeTabTest.Location = new System.Drawing.Point(201, 253);
            this.HomeTabTest.Name = "HomeTabTest";
            this.HomeTabTest.Size = new System.Drawing.Size(75, 23);
            this.HomeTabTest.TabIndex = 7;
            this.HomeTabTest.Text = "Home";
            this.HomeTabTest.UseVisualStyleBackColor = true;
            this.HomeTabTest.Click += new System.EventHandler(this.HomeTabTest_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 817);
            this.Controls.Add(this.AppTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App";
            this.Text = "PokemonTradingApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.App_Load);
            this.AppTabs.ResumeLayout(false);
            this.LoginTab.ResumeLayout(false);
            this.LoginTab.PerformLayout();
            this.RegisterTab.ResumeLayout(false);
            this.RegisterTab.PerformLayout();
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            this.Trade.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox UserNameInput;
        private System.Windows.Forms.Label UsernameTxt;
        private System.Windows.Forms.Label PasswordTxt;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.TabControl AppTabs;
        private System.Windows.Forms.TabPage LoginTab;
        private System.Windows.Forms.TabPage RegisterTab;
        private System.Windows.Forms.TextBox UserNameInput1;
        private System.Windows.Forms.Label UsernameTxt1;
        private System.Windows.Forms.TextBox ConfPasswordInput;
        private System.Windows.Forms.Label ConfirmPasswordtxt;
        private System.Windows.Forms.TextBox PasswordInput1;
        private System.Windows.Forms.Label PasswordTxt1;
        private System.Windows.Forms.Button RegisterBtn1;
        private System.Windows.Forms.Button LoginBtn1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.TabPage Collection;
        private System.Windows.Forms.TabPage Trade;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button CollectionBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddFriends;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button HomeTabTest;
    }
}

