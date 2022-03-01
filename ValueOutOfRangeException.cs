using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ErrorMessageHead)
            : base(i_ErrorMessageHead)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }

            set
            {
                m_MaxValue = value;
            }
        }
        public float MinValue
        {
            get
            {
                return m_MinValue;
            }

            set
            {
                m_MinValue = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} value must be in the range [{1},{2}].", Message, MinValue, MaxValue);
        }
    }
}
