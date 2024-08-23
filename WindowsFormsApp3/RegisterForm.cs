using System;
using System.Windows.Forms;

namespace HIMP
{
    public partial class RegisterForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button registerButton;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.usernameTextBox = new TextBox();
            this.passwordTextBox = new TextBox();
            this.registerButton = new Button();
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

            // registerButton
            this.registerButton.Location = new System.Drawing.Point(197, 64);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 2;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new EventHandler(this.registerButton_Click);

            // RegisterForm
            this.AcceptButton = this.registerButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 96);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Name = "RegisterForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            MethodsManagementForRegisterAndLogin.RegisterUser(usernameTextBox.Text, passwordTextBox.Text);
        }
    }
}
