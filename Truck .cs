using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 16;
        private const float k_MaxAirPressure = 26.0f;
        private bool m_isDrivingDangerousMaterials;
        private float m_maxCarryWeight;
        private float m_CurrentFuelAmountInLiter;
        public Truck(EnergySystem i_EnergySystem, bool i_isDrivingDangerousMaterials, float i_maxCarryWeight, float i_CurrentFuelAmountInLiter, string i_modelName,
            string i_liscenceNum, float i_currentAirPressure, string i_wheelsMakerName, eVehicleType i_vehicleType) : base(i_modelName, i_liscenceNum, i_currentAirPressure, i_wheelsMakerName, i_vehicleType)
        {
            m_EnergySystem = i_EnergySystem;
            m_isDrivingDangerousMaterials = i_isDrivingDangerousMaterials;
            m_maxCarryWeight = i_maxCarryWeight;
            m_CurrentFuelAmountInLiter = i_CurrentFuelAmountInLiter;
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

            vehicleDetails.AppendFormat("Is Driving Dangerous Materials: {0}{1}", m_isDrivingDangerousMaterials, Environment.NewLine);
            vehicleDetails.AppendFormat("Max Carry Weight: {0}{1}", m_maxCarryWeight, Environment.NewLine);
            return vehicleDetails.ToString();
        }
    }
}
