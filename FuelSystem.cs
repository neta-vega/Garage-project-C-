using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelSystem : EnergySystem
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_FuelCapacityInLiter;
        private float m_CurrentFuelAmountInLiter;
        public FuelSystem(eFuelType i_FuelType, float i_MaxFuelCapacityInLiter, float i_InitialFuelAmountInLiter)
        {
            r_FuelType = i_FuelType;
            r_FuelCapacityInLiter = i_MaxFuelCapacityInLiter;
            m_CurrentFuelAmountInLiter = i_InitialFuelAmountInLiter;
        }
        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmountInLiter;
            }

            private set
            {
                bool doesExceedMaxCapacity = value > MaxFuelCapacity;
                if (!doesExceedMaxCapacity)
                {
                    m_CurrentFuelAmountInLiter = value;
                }
            }
        }
        public float MaxFuelCapacity
        {
            get
            {
                return r_FuelCapacityInLiter;
            }
        }
        public void AddFuel(float i_AmountToAddInLiter, eFuelType i_FuelType)
        {
            CurrentFuelAmount += i_AmountToAddInLiter;

            if (CurrentFuelAmount > MaxFuelCapacity)
            {
                CurrentFuelAmount = MaxFuelCapacity;
            }
        }
        public override string ToString()
        {
            StringBuilder fuelSystemInfo = new StringBuilder();

            fuelSystemInfo.AppendFormat(
                "Fuel tank state: {0} out of {1} liters, {2}{3}",
                CurrentFuelAmount,
                MaxFuelCapacity,
                FuelType,
                Environment.NewLine);

            return fuelSystemInfo.ToString();
        }
        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
