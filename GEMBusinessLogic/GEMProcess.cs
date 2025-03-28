using System;
using System.Collections.Generic;

namespace GEMBusinessLogic { 
    public class GEMProcess  {
        public List<(int Id, string Name, string Status, int Quantity)> equipmentList = new List<(int, string, string, int)>();
        static int idCounter = 1;

    public void AddEquipment(string name, string status, int quantity){
        equipmentList.Add((idCounter++, name, status, quantity));
    }

    public bool UpdateEquipment(int id, string newName, string newStatus, int newQuantity) {
        for (int i = 0; i < equipmentList.Count; i++){
        if (equipmentList[i].Id == id){
            equipmentList[i] = (id, newName, newStatus, newQuantity);
            return true;
        }
    } return false;
    }

    public bool DeleteEquipment(int id){
        return equipmentList.RemoveAll(e => e.Id == id) > 0;
    }

    public List<(int Id, string Name, string Status, int Quantity)> GetEquipmentList(){
        return equipmentList;
      }
    }
}
