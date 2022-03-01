using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleStatus
        {
            onGoing = 1,
            Fixed,
            Payed,
        };

        public static Dictionary<String, Vehicle> vehiclesInTheGarage = new Dictionary<String, Vehicle>();
        public void ChangeVehicleStatus(Vehicle i_Vehicle, Garage.eVehicleStatus i_newStatus)
        {
            i_Vehicle.VehicleStatus = i_newStatus;
        }
        public void FuelVehicle(string i_LicenseNumber, FuelSystem.eFuelType i_FuelType, float i_HowMuchFuelToFill)
        {
            Vehicle vehicle;

            Garage.vehiclesInTheGarage.TryGetValue(i_LicenseNumber, out vehicle);
            FuelSystem fuelSystem = vehicle.EnergySystem as FuelSystem;
            fuelSystem.AddFuel(i_HowMuchFuelToFill, i_FuelType);
        }
        public void ChargeVehicle(string i_LicenseNumber, float i_ChargeHoursAmount)
        {
            Vehicle vehicle;

            Garage.vehiclesInTheGarage.TryGetValue(i_LicenseNumber, out vehicle);
            (vehicle.EnergySystem as ElectricSystem).Charge(i_ChargeHoursAmount);
        }
    }
}

