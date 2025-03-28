using System;
using GEMBusinessLogic;

namespace Gym_Equipment_Management{
    internal class Program {
        static GEMBusinessLogic gemProcess = new GEMBusinessLogic();
        static void Main(string[] args) {
            

            while (true) {
                Console.Clear();
                Console.WriteLine("===== GYM EQUIPMENT MANAGEMENT =====");
                Console.WriteLine("1. Add Equipment");
                Console.WriteLine("2. Update Equipment");
                Console.WriteLine("3. Delete Equipment");
                Console.WriteLine("4. View Equipment List");
                Console.WriteLine("5. View History");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect an option: ");

            switch (Console.ReadLine()){
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
                    Console.WriteLine("\nExiting program...");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();
            }
        }

    static void AddEquipment(){
            Console.Clear();
            Console.WriteLine("=== ADD EQUIPMENT ===");

            Console.Write("Enter Equipment Name: ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name)){
                Console.WriteLine("Equipment name cannot be empty.");
                return;
            }

            Console.Write("Enter Equipment Status (Working/Needs Repair): ");
            string status = Console.ReadLine()?.Trim();

            if (status != "Working" && status != "Needs Repair"){
                Console.WriteLine("Invalid status! Use 'Working' or 'Needs Repair'.");
                return;
            }

            Console.Write("Enter Equipment Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0){
                Console.WriteLine("Invalid quantity! Enter a positive number.");
                return;
            }

            gemProcess.AddEquipment(name, status, quantity);
            Console.WriteLine("Equipment added successfully!");
        }

    static void UpdateEquipment(){
            Console.Clear();
            Console.WriteLine("=== UPDATE EQUIPMENT ===");

            Console.Write("Enter Equipment ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Invalid ID!");
                return;
            }

            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine()?.Trim();

            Console.Write("Enter New Status (Working/Needs Repair): ");
            string newStatus = Console.ReadLine()?.Trim();

            Console.Write("Enter New Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity) || newQuantity <= 0){
                Console.WriteLine("Invalid quantity! Enter a positive number.");
                return;
            }

            Console.WriteLine(gemProcess.UpdateEquipment(id, newName, newStatus, newQuantity)
                ? "Equipment updated successfully!"
                : "Equipment not found!");
        }

    static void DeleteEquipment() {
            Console.Clear();
            Console.WriteLine("=== DELETE EQUIPMENT ===");

            Console.Write("Enter Equipment ID: ");
            if (int.TryParse(Console.ReadLine(), out int id)){
                bool deleted = gemProcess.DeleteEquipment(id);
                Console.WriteLine(deleted ? "Equipment deleted successfully!" : "Equipment not found!");
            } else{
                Console.WriteLine("Invalid ID! Please enter a number.");
            }
        }


    static void ViewEquipmentList() {
            Console.Clear();
            Console.WriteLine("=== EQUIPMENT LIST ===");

            var equipmentList = gemProcess.GetEquipmentList();
            if (equipmentList.Length == 0){
                Console.WriteLine("No equipment found.");
                return;
            }

            foreach (var e in equipmentList){
                if (e != null){
                    Console.WriteLine($"\nID: {e.Id}\nName: {e.Name}\nStatus: {e.Status}\nQuantity: {e.Quantity}");
                }
            }
        }

    static void ViewHistory(){
            Console.Clear();
            Console.WriteLine("=== ACTION HISTORY ===");

            var history = gemProcess.GetHistory();
            if (history.Length == 0){
                Console.WriteLine("No history available.");
                return;
            }

            foreach (var record in history){
                if (!string.IsNullOrEmpty(record)) {
                    Console.WriteLine(record);
                }
            }
        }
    }
}
