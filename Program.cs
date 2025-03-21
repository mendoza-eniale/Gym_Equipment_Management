using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Equipment_Management
{
    class GymEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
    }

    class GymEM
    {
        static List<GymEquipment> equipmentList = new List<GymEquipment>();
        static List<string> history = new List<string>();
        static int idCounter = 1;

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Gym Equipment Management ---");
                Console.WriteLine("1. Add Equipment");
                Console.WriteLine("2. Update Equipment");
                Console.WriteLine("3. Delete Equipment");
                Console.WriteLine("4. View Equipment List");
                Console.WriteLine("5. View History");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddEquipment();
                        break;
                    case "2":
                        UpdateEquipment();
                        break;
                    case "3":
                        DeleteEquipment();
                        break;
                    case "4":
                        ViewEquipmentList();
                        break;
                    case "5":
                        ViewHistory();
                        break;
                    case "6":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        static void AddEquipment()
        {
            Console.Write("\nEnter Equipment Name: ");
            string name = Console.ReadLine();

            string status;
            while (true)
            {
                Console.Write("Enter Equipment Status (Working/Needs Repair): ");
                status = Console.ReadLine();
                if (status == "Working" || status == "Needs Repair") break;
                Console.WriteLine("Invalid status! Please enter 'Working' or 'Needs Repair'.");
            }

            Console.Write("Enter the Equipment Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                equipmentList.Add(new GymEquipment { Id = idCounter, Name = name, Status = status, Quantity = quantity });
                history.Add($"Added: {name} (ID: {idCounter}) \nStatus: {status} \n Quantity: {quantity}\n");
                idCounter++;
                Console.WriteLine("Equipment added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid input! Quantity must be a number.");
            }
        }

        static void UpdateEquipment()
        {
            Console.Write("\nEnter Equipment ID to Update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var equipment = equipmentList.Find(e => e.Id == id);
                if (equipment != null)
                {
                    Console.Write("Enter New Name: ");
                    string newName = Console.ReadLine();

                    string newStatus;
                    while (true)
                    {
                        Console.Write("Enter New Status (Working/Needs Repair): ");
                        newStatus = Console.ReadLine();
                        if (newStatus == "Working" || newStatus == "Needs Repair") break;
                        Console.WriteLine("Invalid status! Please enter 'Working' or 'Needs Repair'.");
                    }

                    history.Add($"Updated: {equipment.Name} (ID: {equipment.Id}) -> {newName}\n Status: {newStatus}\n");
                    equipment.Name = newName;
                    equipment.Status = newStatus;
                    Console.WriteLine("Equipment updated successfully!");
                }
                else
                {
                    Console.WriteLine("Equipment not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }

        static void DeleteEquipment()
        {
            Console.Write("\nEnter Equipment ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var equipment = equipmentList.Find(e => e.Id == id);
                if (equipment != null)
                {
                    equipmentList.Remove(equipment);
                    history.Add($"Deleted: {equipment.Name} (ID: {equipment.Id})\n");
                    Console.WriteLine("Equipment deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Equipment not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }

        static void ViewEquipmentList()
        {
            Console.WriteLine("\n--- Equipment List ---");
            if (equipmentList.Count == 0)
            {
                Console.WriteLine("No equipment found.");
            }
            else
            {
                equipmentList.ForEach(e => Console.WriteLine($"ID: {e.Id}\n Name: {e.Name}\n Status: {e.Status}\n Quantity: {e.Quantity}\n"));
            }
        }

        static void ViewHistory()
        {
            Console.WriteLine("\n--- History ---");
            if (history.Count == 0)
            {
                Console.WriteLine("No history available.");
            }
            else
            {
                history.ForEach(Console.WriteLine);
            }
        }
    }
}
