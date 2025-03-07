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

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("\nEnter Equipment Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Equipment Status (Working/Needs Repair): ");
                        string status = Console.ReadLine();

                        Console.Write("Enter the Equipment Quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int quantity))
                        {
                            Console.WriteLine("Invalid input! Quantity must be a number.");
                            break;
                        }

                        equipmentList.Add(new GymEquipment { Id = idCounter, Name = name, Status = status, Quantity = quantity });
                        history.Add($"Added: {name} (ID: {idCounter} \nStatus: {status} \n Quantity: {quantity})");
                        idCounter++;

                        Console.WriteLine("Equipment added successfully!");
                        break;

                    case "2":
                        Console.Write("\nEnter Equipment ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            GymEquipment equipment = equipmentList.Find(e => e.Id == id);
                            if (equipment != null)
                            {
                                Console.Write("Enter New Name: ");
                                string newName = Console.ReadLine();
                                Console.Write("Enter New Status: ");
                                string newStatus = Console.ReadLine();

                                history.Add($"Updated: {equipment.Name}\n (ID: {equipment.Id}) -> {newName}\n Status: {newStatus}");
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
                        break;

                    case "3":
                        Console.Write("\nEnter Equipment ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int ID))
                        {
                            GymEquipment equipment = equipmentList.Find(e => e.Id == ID);
                            if (equipment != null)
                            {

                                equipmentList.Remove(equipment);
                                history.Add("Deleted: {equipment.Name} (ID: {equipment.Id})");
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
                        break;

                    case "4":
                        Console.WriteLine("\n--- Equipment List ---");

                        if (equipmentList.Count == 0)
                        {
                            Console.WriteLine("No equipment found.");
                            break;
                        }

                        foreach (var item in equipmentList)
                        {
                            Console.WriteLine($"ID: {item.Id}\n Name: {item.Name}\n Status: {item.Status}\n Quantity: {item.Quantity}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("\n--- History ---");

                        if (history.Count == 0)
                        {
                            Console.WriteLine("No history available.");
                            break;
                        }

                        foreach (var item in history)
                        {
                            Console.WriteLine(item);
                        }
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
    }
}

