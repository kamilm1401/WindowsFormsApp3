using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HIMP
{
    public static class MethodsManagementForRegisterAndLogin
    {
        private static List<LoginClass> users = new List<LoginClass>();

        public static void RegisterUser(string username, string password)
        {
            try
            {
                if (users.Any(u => u.Username == username))
                {
                    MessageBox.Show("Username already exists.");
                }
                else
                {
                    users.Add(new LoginClass(username, password));
                    MessageBox.Show("User registered successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}");
            }
        }

        public static bool AuthenticateUser(string username, string password)
        {
            return users.Any(u => u.Username == username && u.Password == password);
        }
    }
}
