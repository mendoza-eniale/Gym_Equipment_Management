using System;

namespace GEMBusinessLogic{

    public class GEMProcess{
    public class GymEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
    }

        GymEquipment[] equipment = new GymEquipment[100];
        string[] history = new string[100];
        int equipmentCount = 0;
        int historyCount = 0;
        int idCounter = 1;

        public void AddEquipment(string name, string status, int quantity){
            if (equipmentCount >= equipment.Length){
                Console.WriteLine("Storage full! Cannot add more equipment.");
                return;
            }

            GymEquipment newEquipment = new GymEquipment {
                Id = idCounter++,
                Name = name,
                Status = status,
                Quantity = quantity
            };

            equipment[equipmentCount++] = newEquipment;

            if (historyCount < history.Length){
                history[historyCount++] = "Added: {name} (ID: {newEquipment.Id})";
            }
        }

        public bool UpdateEquipment(int id, string newName, string newStatus, int newQuantity) {
        for (int i = 0; i < equipmentCount; i++){
            if (equipment[i].Id == id) {
                equipment[i].Name = newName;
                equipment[i].Status = newStatus;
                equipment[i].Quantity = newQuantity;

            if (historyCount < history.Length) {
                history[historyCount++] = "Updated: {newName} (ID: {id})";
            } return true;
            }

        }return false;
        }

        public bool DeleteEquipment(int id){
            
            for (int i = 0; i < equipmentCount; i++){
            if (equipment[i].Id == id){
                string deletedName = equipment[i].Name;

            for (int j = i; j < equipmentCount - 1; j++){
                equipment[j] = equipment[j + 1];
            }
            equipmentCount--;

            if (historyCount < history.Length){
                history[historyCount++] = "Deleted: {deletedName} (ID: {id})";
            }return true;
        }
    } return false;
        }
        }
}
