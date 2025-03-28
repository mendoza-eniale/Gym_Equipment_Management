using System;
using GEMBusinessLogic;

namespace GymEquipmentManagement{
    class Program {

        static GEMProcess gemProcess = new GEMProcess();

    static void Main(){

        while (true) {
            Console.Clear();
            Console.WriteLine("===== GYM EQUIPMENT MANAGEMENT =====");
            Console.WriteLine("1. Add Equipment");
            Console.WriteLine("2. Update Equipment");
            Console.WriteLine("3. Delete Equipment");
            Console.WriteLine("4. View Equipment List");
            Console.WriteLine("5. Exit");
            Console.Write("\nSelect an option: ");

        switch (Console.ReadLine()) { 
            case "1": AddEquipment();
                      break;
            case "2": UpdateEquipment();
                      break;
            case "3": DeleteEquipment(); 
                      break;
            case "4": ViewEquipmentList(); 
                      break;
            case "5": return;
            default:
                      Console.WriteLine("Invalid choice! Try again.");
                      break;
        }

        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadLine();
    }
}

    static void AddEquipment(){

            Console.Clear();
            Console.Write("Enter Equipment Name: ");
            string name = Console.ReadLine()?.Trim();

            Console.Write("Enter Status (Working/Needs Repair): ");
            string status = Console.ReadLine()?.Trim();

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0) {
                Console.WriteLine("Invalid quantity! Enter a positive number.");
            return;
            }

            gemProcess.AddEquipment(name, status, quantity);
            Console.WriteLine("Equipment added successfully!");
        }

        static void UpdateEquipment() {

            Console.Clear();
            Console.Write("Enter Equipment ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine()?.Trim();

            Console.Write("Enter New Status: ");
            string newStatus = Console.ReadLine()?.Trim();

            Console.Write("Enter New Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity) || newQuantity <= 0)
                Console.WriteLine("Invalid quantity. Enter Valid Number.");
            return;

            if (gemProcess.UpdateEquipment(id, newName, newStatus, newQuantity))
                Console.WriteLine("Equipment updated successfully!");
            Console.WriteLine("ID: {id}\n Name: {newName} \nStatus: {newStatus} \nQuantity: {newQuantity}");
            else
                Console.WriteLine("Equipment not found!");
        }

    static void DeleteEquipment(){

            Console.Clear();
            Console.Write("Enter Equipment ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            if (gemProcess.DeleteEquipment(id))
                Console.WriteLine("Equipment deleted successfully!");
            else
                Console.WriteLine("Equipment not found!");
        }

    static void ViewEquipmentList(){

            Console.Clear();
            var equipmentList = gemProcess.GetEquipmentList();

            if (equipmentList.Count == 0){
                Console.WriteLine("No equipment available.");
                return;
            }

            foreach (var e in equipmentList)
                Console.WriteLine("\nID: {e.Id}\nName: {e.Name}\nStatus: {e.Status}\nQuantity: {e.Quantity}");
        }
    }
}
