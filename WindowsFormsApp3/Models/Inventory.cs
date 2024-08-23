using System;

namespace HIMP
{
    public class Inventory
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        private static int idCounter = 1;

        public Inventory(string name, string location, string description)
        {
            ID = idCounter++;
            Name = name;
            Location = location;
            Description = description;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Location: {Location}, Description: {Description}";
        }
    }
}
