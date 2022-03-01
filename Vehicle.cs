using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {

        public const int k_licenseNumberLength = 8;
        private string m_modelName;
        private string m_liscencePlateNumber;
        protected EnergySystem m_EnergySystem;
        protected List<Wheel> m_Wheels;
        private Garage.eVehicleStatus m_vehicleStatus;
        private eVehicleType m_vehicleType;
        private FuelSystem.eFuelType m_fuelType;


        public Vehicle(string i_ModelName, string i_LicenseNum, float i_currAirPressure, string i_wheelsMakerName, eVehicleType i_vehicleType)
        {
            m_modelName = i_ModelName;
            m_liscencePlateNumber = i_LicenseNum;
            m_vehicleType = i_vehicleType;
            m_vehicleStatus = Garage.eVehicleStatus.onGoing;
            setFuelType();
        }
        public enum eVehicleType
        {
            Car = 1,
            Motorcycle,
            Truck
        };
        public enum eEnergyType
        {
            Fuel = 1,
            Electric
        };
        public eVehicleType VehicleType
        {
            get
            {
                return m_vehicleType;
            }

            set
            {
                m_vehicleType = value;
            }
        }
        public FuelSystem.eFuelType FuelType
        {
            get
            {
                return m_fuelType;
            }
        }
        public string ModelName
        {
            get
            {
                return m_modelName;
            }

            set
            {
                m_modelName = value;
            }
        }
        public string LiscencePlateNumber
        {
            get
            {
                return m_liscencePlateNumber;
            }

            set
            {
                bool isLengthValid = value.Length == k_licenseNumberLength;
                bool isFormatValid = StringValidation.ContainsOnlyLettersAndNumbers(value);
                if (isLengthValid && isFormatValid)
                {
                    m_liscencePlateNumber = value;
                }
                else
                {
                    throw new FormatException("License can only contain letters and numbers.");
                }
            }
        }
        public EnergySystem EnergySystem
        {
            get
            {
                return m_EnergySystem;
            }
        }
        public Garage.eVehicleStatus VehicleStatus
        {
            get
            {
                return m_vehicleStatus;
            }
            set
            {
                m_vehicleStatus = value;
            }
        }
        public List<Wheel> WheelList
        {
            get
            {
                return m_Wheels;
            }
        }
        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendFormat("Model Name: {0}{1}", ModelName, Environment.NewLine);
            vehicleDetails.AppendFormat("License Number: {0}{1}", LiscencePlateNumber, Environment.NewLine);
            vehicleDetails.AppendFormat("Vehicle Status: {0}{1}", VehicleStatus, Environment.NewLine);
            return vehicleDetails.ToString();
        }
        private void setFuelType()
        {
            if (VehicleType == eVehicleType.Car)
            {
                m_fuelType = FuelSystem.eFuelType.Octan95;
            }

            if (VehicleType == eVehicleType.Motorcycle)
            {
                m_fuelType = FuelSystem.eFuelType.Octan98;
            }

            if (VehicleType == eVehicleType.Truck)
            {
                m_fuelType = FuelSystem.eFuelType.Soler;
            }
        }
    }
}
