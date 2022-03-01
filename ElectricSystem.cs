using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricSystem : EnergySystem
    {
        private readonly float r_MaxChargeInHours;
        private float m_CurrChargeInHours;
        public ElectricSystem(float i_CurChargeInHours, float i_MaxChargeInHours)
        {
            m_CurrChargeInHours = i_CurChargeInHours;
            r_MaxChargeInHours = i_MaxChargeInHours;
        }
        public float CurrentChargeInHours
        {
            get
            {
                return m_CurrChargeInHours;
            }

            private set
            {
                bool doesExceedMaxCapacity = value > MaxChargeInHours;
                if (!doesExceedMaxCapacity)
                {
                    m_CurrChargeInHours = value;
                }
            }
        }

        public float MaxChargeInHours
        {
            get
            {
                return r_MaxChargeInHours;
            }
        }
        public void Charge(float i_HourCountCharge)
        {
            CurrentChargeInHours += i_HourCountCharge;

            if (CurrentChargeInHours > MaxChargeInHours)
            {
                CurrentChargeInHours = MaxChargeInHours;
            }
        }
        public override string ToString()
        {
            StringBuilder electricSystemInfo = new StringBuilder();

            electricSystemInfo.AppendFormat(
                "The maximal electric charge is {0} hours, currently charged {1} hours.{2}",
                r_MaxChargeInHours,
                m_CurrChargeInHours,
                Environment.NewLine);

            return electricSystemInfo.ToString();
        }
    }
}
