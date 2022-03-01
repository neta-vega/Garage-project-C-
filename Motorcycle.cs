using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 30.0f;
        private int m_engineVolume;
        private eLisenceType m_eLisenceType;

        public MotorCycle(EnergySystem i_EnergySystem, eLisenceType i_liscenceType, int i_engineVolume, string i_modelName,
            string i_liscenceNum, float i_currentAirPressure, string i_wheelsMakerName, eVehicleType i_vehicleType) : base(i_modelName, i_liscenceNum, i_currentAirPressure, i_wheelsMakerName, i_vehicleType)
        {
            m_EnergySystem = i_EnergySystem;
            LisenceType = i_liscenceType;
            EngineVolume = i_engineVolume;
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

            vehicleDetails.AppendFormat("Engine Volume: {0}{1}", EngineVolume, Environment.NewLine);
            vehicleDetails.AppendFormat("License Type: {0}{1}", LisenceType, Environment.NewLine);

            return vehicleDetails.ToString();
        }
        public eLisenceType LisenceType
        {
            get
            {
                return m_eLisenceType;
            }
            set
            {
                m_eLisenceType = value;
            }
        }
        public enum eLisenceType
        {
            AA = 1,
            BB,
            B1,
            A,
        };
        public int EngineVolume
        {
            get
            {
                return m_engineVolume;
            }
            set
            {
                m_engineVolume = value;
            }
        }
    }
}
