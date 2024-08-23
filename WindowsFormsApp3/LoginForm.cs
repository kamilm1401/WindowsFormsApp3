﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HIMP
{
    public partial class LoginForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;

        private static List<LoginClass> registeredUsers = new List<LoginClass>
        {
            new LoginClass("admin", "password"), // Example user
            // Add more users as needed
        };

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.usernameTextBox = new TextBox();
            this.passwordTextBox = new TextBox();
            this.loginButton = new Button();
            this.SuspendLayout();

            // usernameTextBox
            this.usernameTextBox.Location = new System.Drawing.Point(12, 12);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(260, 20);
            this.usernameTextBox.TabIndex = 0;

            // passwordTextBox
            this.passwordTextBox.Location = new System.Drawing.Point(12, 38);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(260, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;

            // loginButton
            this.loginButton.Location = new System.Drawing.Point(197, 64);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new EventHandler(this.loginButton_Click);

            // LoginForm
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 96);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(usernameTextBox.Text, passwordTextBox.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Check if the provided username and password match any registered user
            foreach (var user in registeredUsers)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
