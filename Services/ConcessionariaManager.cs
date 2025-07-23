using System;
using System.Collections.Generic;
using Model;

namespace Services {
    public class ConcessionariaManager {
        public ConcessionariaManager() {}

        private static List<Vehicle> vehicles = new List<Vehicle>();

        public List<Vehicle> GetVehicles() {
            return vehicles;
        }

        public Vehicle GetVehicle(int id) {
            return vehicles[id];
        }

        public Vehicle UpdateVehicle(int id, string? vehicleType, string? mark, string? model, int? year) {
            var vehicle = this.GetVehicle(id);

            vehicle.SetVehicleType(string.IsNullOrWhiteSpace(vehicleType) ? vehicle.GetVehicleType() : vehicleType);
            vehicle.SetMark(string.IsNullOrWhiteSpace(mark) ? vehicle.GetMark() : mark);
            vehicle.SetModel(string.IsNullOrWhiteSpace(model) ? vehicle.GetModel() : model);
            vehicle.SetYear(year ?? vehicle.GetYear());

            vehicles[id] = vehicle;

            return vehicle;
        }

        public void CreateVehicle(string type, string mark, string model, int year) {
            vehicles.Add(new Vehicle (type, mark, model, year));
        }

        public bool DeleteVehicle(int index)
        {
            if (index < 0 || index >= vehicles.Count)
                return false;

            vehicles.RemoveAt(index);
            return true;
        }
    }
}
