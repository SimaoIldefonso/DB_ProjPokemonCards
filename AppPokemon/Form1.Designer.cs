namespace AppPokemon
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.UserNameInput = new System.Windows.Forms.TextBox();
            this.UsernameTxt = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.LoginRegisterTabs = new System.Windows.Forms.TabControl();
            this.LoginTab = new System.Windows.Forms.TabPage();
            this.RegisterTab = new System.Windows.Forms.TabPage();
            this.RegisterBtn1 = new System.Windows.Forms.Button();
            this.LoginBtn1 = new System.Windows.Forms.Button();
            this.ConfPasswordInput = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordtxt = new System.Windows.Forms.Label();
            this.PasswordInput1 = new System.Windows.Forms.TextBox();
            this.PasswordTxt1 = new System.Windows.Forms.Label();
            this.UserNameInput1 = new System.Windows.Forms.TextBox();
            this.UsernameTxt1 = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.LoginRegisterTabs.SuspendLayout();
            this.LoginTab.SuspendLayout();
            this.RegisterTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNameInput
            // 
            this.UserNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameInput.Location = new System.Drawing.Point(650, 226);
            this.UserNameInput.Name = "UserNameInput";
            this.UserNameInput.PasswordChar = 'a';
            this.UserNameInput.Size = new System.Drawing.Size(104, 23);
            this.UserNameInput.TabIndex = 1;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.AutoSize = true;
            this.UsernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt.Location = new System.Drawing.Point(542, 223);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(83, 20);
            this.UsernameTxt.TabIndex = 2;
            this.UsernameTxt.Text = "Username";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.AutoSize = true;
            this.PasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.Location = new System.Drawing.Point(545, 260);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(78, 20);
            this.PasswordTxt.TabIndex = 3;
            this.PasswordTxt.Text = "Password";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Location = new System.Drawing.Point(650, 264);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(104, 23);
            this.PasswordInput.TabIndex = 4;
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn.Location = new System.Drawing.Point(561, 404);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(111, 47);
            this.RegisterBtn.TabIndex = 5;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = true;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // LoginRegisterTabs
            // 
            this.LoginRegisterTabs.Controls.Add(this.LoginTab);
            this.LoginRegisterTabs.Controls.Add(this.RegisterTab);
            this.LoginRegisterTabs.Location = new System.Drawing.Point(0, -3);
            this.LoginRegisterTabs.Name = "LoginRegisterTabs";
            this.LoginRegisterTabs.SelectedIndex = 0;
            this.LoginRegisterTabs.Size = new System.Drawing.Size(1516, 673);
            this.LoginRegisterTabs.TabIndex = 6;
            this.LoginRegisterTabs.TabStop = false;
            // 
            // LoginTab
            // 
            this.LoginTab.BackColor = System.Drawing.Color.DarkGray;
            this.LoginTab.Controls.Add(this.LoginBtn);
            this.LoginTab.Controls.Add(this.UserNameInput);
            this.LoginTab.Controls.Add(this.RegisterBtn);
            this.LoginTab.Controls.Add(this.UsernameTxt);
            this.LoginTab.Controls.Add(this.PasswordInput);
            this.LoginTab.Controls.Add(this.PasswordTxt);
            this.LoginTab.Location = new System.Drawing.Point(4, 25);
            this.LoginTab.Name = "LoginTab";
            this.LoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginTab.Size = new System.Drawing.Size(1508, 644);
            this.LoginTab.TabIndex = 0;
            this.LoginTab.Text = "Login";
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
            this.RegisterTab.Size = new System.Drawing.Size(1508, 644);
            this.RegisterTab.TabIndex = 1;
            this.RegisterTab.Text = "Register";
            // 
            // RegisterBtn1
            // 
            this.RegisterBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn1.Location = new System.Drawing.Point(545, 382);
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
            this.LoginBtn1.Location = new System.Drawing.Point(695, 382);
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
            this.ConfirmPasswordtxt.Location = new System.Drawing.Point(519, 293);
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
            this.PasswordTxt1.Location = new System.Drawing.Point(578, 256);
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
            this.UsernameTxt1.Location = new System.Drawing.Point(573, 217);
            this.UsernameTxt1.Name = "UsernameTxt1";
            this.UsernameTxt1.Size = new System.Drawing.Size(83, 20);
            this.UsernameTxt1.TabIndex = 0;
            this.UsernameTxt1.Text = "Username";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.Location = new System.Drawing.Point(695, 404);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(104, 47);
            this.LoginBtn.TabIndex = 6;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 817);
            this.Controls.Add(this.LoginRegisterTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "PokemonTradingApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Load);
            this.LoginRegisterTabs.ResumeLayout(false);
            this.LoginTab.ResumeLayout(false);
            this.LoginTab.PerformLayout();
            this.RegisterTab.ResumeLayout(false);
            this.RegisterTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox UserNameInput;
        private System.Windows.Forms.Label UsernameTxt;
        private System.Windows.Forms.Label PasswordTxt;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.TabControl LoginRegisterTabs;
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
    }
}

