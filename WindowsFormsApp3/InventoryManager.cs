using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HIMP
{
    public class InventoryManager
    {
        private List<Inventory> inventoryList = new List<Inventory>();

        public void AddInventoryElement(string name, string location, string description)
        {
            try
            {
                var newItem = new Inventory(name, description, location);
                inventoryList.Add(newItem);
                MessageBox.Show($"Added new item with ID {newItem.ID}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding inventory element: {ex.Message}");
            }
        }

        public void ShowAllInventory()
        {
            try
            {
                if (inventoryList.Count > 0)
                {
                    string items = string.Join(Environment.NewLine, inventoryList);
                    MessageBox.Show(items);
                }
                else
                {
                    MessageBox.Show("No items in the inventory.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying inventory: {ex.Message}");
            }
        }

        public void ShowInventoryElement(int id)
        {
            try
            {
                var item = inventoryList.Find(i => i.ID == id);
                if (item != null)
                {
                    MessageBox.Show(item.ToString());
                }
                else
                {
                    MessageBox.Show("Item not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying inventory item: {ex.Message}");
            }
        }

        public void ShowOrderBy(Func<Inventory, object> orderByFunc)
        {
            try
            {
                var sortedList = new List<Inventory>(inventoryList);
                sortedList.Sort((x, y) => Comparer<object>.Default.Compare(orderByFunc(x), orderByFunc(y)));

                string items = string.Join(Environment.NewLine, sortedList);
                MessageBox.Show(items);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sorting inventory: {ex.Message}");
            }
        }

        public void DeleteAllInventoryElements()
        {
            try
            {
                if (inventoryList.Count > 0)
                {
                    inventoryList.Clear();
                    MessageBox.Show("All items deleted.");
                }
                else
                {
                    MessageBox.Show("No items to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting all inventory elements: {ex.Message}");
            }
        }

        public void DeleteInventoryElement(int id)
        {
            try
            {
                var item = inventoryList.Find(i => i.ID == id);
                if (item != null)
                {
                    inventoryList.Remove(item);
                    MessageBox.Show($"Item with ID {id} deleted.");
                }
                else
                {
                    MessageBox.Show("Item not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting inventory item: {ex.Message}");
            }
        }

        public void EditInventoryElement(int id, string name, string location, string description)
        {
            try
            {
                var item = inventoryList.Find(i => i.ID == id);
                if (item != null)
                {
                    item.Name = name;
                    item.Location = location;
                    item.Description = description;
                    MessageBox.Show($"Item with ID {id} updated.");
                }
                else
                {
                    MessageBox.Show("Item not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing inventory item: {ex.Message}");
            }
        }

        public void LoadInventoryFromJsonDataBase()
        {
            string dataBaseLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.json");

            try
            {
                if (File.Exists(dataBaseLocation))
                {
                    string jsonData = File.ReadAllText(dataBaseLocation);
                    inventoryList = JsonConvert.DeserializeObject<List<Inventory>>(jsonData) ?? new List<Inventory>();
                    MessageBox.Show("Database successfully retrieved.");
                }
                else
                {
                    MessageBox.Show("Database file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading the database: {ex.Message}");
            }
        }

        public void SaveInventoryToJson()
        {
            string dataBaseLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase.json");

            try
            {
                string jsonData = JsonConvert.SerializeObject(inventoryList, Formatting.Indented);
                File.WriteAllText(dataBaseLocation, jsonData);
                MessageBox.Show("Data has been saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to the database: {ex.Message}");
            }
        }

        public void CloseTheProgram()
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Program Error: {ex.Message}");
            }
        }
    }
}
