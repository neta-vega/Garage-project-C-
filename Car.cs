using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 32.0f;
        private int m_NumOfDoors;
        private eColor m_eColor;
        public Car(EnergySystem i_EnergySystem, int i_numOfDoors, eColor i_carColor, string i_modelName,
            string i_liscenceNum, float i_currentAirPressure, string i_wheelsMakerName, eVehicleType i_vehicleType) : base(i_modelName, i_liscenceNum, i_currentAirPressure, i_wheelsMakerName, i_vehicleType)
        {
            m_EnergySystem = i_EnergySystem;
            m_NumOfDoors = i_numOfDoors;
            m_eColor = i_carColor;
            m_Wheels = new List<Wheel>();

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel carWheel = new Wheel(i_currentAirPressure, i_wheelsMakerName, k_MaxAirPressure);
                m_Wheels.Add(carWheel);
            }
        }
        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder(base.ToString());

            vehicleDetails.AppendFormat("Number Of Wheels: {0}{1}", k_NumberOfWheels, Environment.NewLine);
            vehicleDetails.AppendFormat("Number Of Doors: {0}{1}", m_NumOfDoors, Environment.NewLine);
            vehicleDetails.AppendFormat("Color: {0}{1}", m_eColor, Environment.NewLine);
            return vehicleDetails.ToString();
        }
        public enum eColor
        {
            Red = 1,
            Silver,
            White,
            Black
        }
    }
}
