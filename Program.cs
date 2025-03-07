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

                        break;
                    case "2":
                        Console.Write("\nEnter Equipment ID to Update: ");

                        break;
                    case "3":
                        Console.Write("\nEnter Equipment ID to Delete: ");

                        break;
                    case "4":
                                Console.WriteLine("\n--- Equipment List ---");

                        break;
                    case "5":
                        Console.WriteLine("\n--- History ---");
                        
                        break;

                }
                }
            }

        }
    
    }


