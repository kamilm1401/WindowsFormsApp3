using System;
using System.Windows.Forms;

namespace HIMP
{
    public partial class MainForm : Form
    {
        private InventoryManager inventoryManager;
        private Button manageInventoryButton;
        private Button logoutButton;

        public MainForm()
        {
            InitializeComponent();
            inventoryManager = new InventoryManager();
        }

        private void InitializeComponent()
        {
            this.manageInventoryButton = new Button();
            this.logoutButton = new Button();
            this.SuspendLayout();

            // manageInventoryButton
            this.manageInventoryButton.Location = new System.Drawing.Point(12, 12);
            this.manageInventoryButton.Name = "manageInventoryButton";
            this.manageInventoryButton.Size = new System.Drawing.Size(260, 23);
            this.manageInventoryButton.TabIndex = 0;
            this.manageInventoryButton.Text = "Manage Inventory";
            this.manageInventoryButton.UseVisualStyleBackColor = true;
            this.manageInventoryButton.Click += new EventHandler(this.manageInventoryButton_Click);

            // logoutButton
            this.logoutButton.Location = new System.Drawing.Point(12, 41);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(260, 23);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new EventHandler(this.logoutButton_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 76);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.manageInventoryButton);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);
        }

        private void manageInventoryButton_Click(object sender, EventArgs e)
        {
            // Code to open the inventory management form
            InventoryManagementForm inventoryForm = new InventoryManagementForm(inventoryManager);
            inventoryForm.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
