using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class Wheel
	{
		private string m_makerName;
		private float m_currentAirPressure;
		private float m_maxAirPressure;
		public Wheel(float i_currentAirPressure, string i_wheelsMakerName, float i_maxAirPressure)
		{
			CurrAirPressure = i_currentAirPressure;
			makerName = i_wheelsMakerName;
			m_maxAirPressure = i_maxAirPressure;
		}
		public override string ToString()
		{
			StringBuilder wheelsDetails = new StringBuilder();

			wheelsDetails.AppendFormat("Maker Name: {0}{1}", m_makerName, Environment.NewLine);
			wheelsDetails.AppendFormat("Current air pressure: {0}{1}", m_currentAirPressure, Environment.NewLine);
			wheelsDetails.AppendFormat("Max air pressure: {0}{1}", m_maxAirPressure, Environment.NewLine);
			return wheelsDetails.ToString();
		}
		public string makerName
		{
			get
			{
				return m_makerName;
			}
			set
			{
				m_makerName = value;
			}
		}
		public float CurrAirPressure
		{
			get
			{
				return m_currentAirPressure;
			}

			set
			{
				m_currentAirPressure = value;
			}
		}
		public float MaxAirPressure
		{
			get
			{
				return m_maxAirPressure;
			}
			set
			{
				m_maxAirPressure = value;
			}
		}
		public void Inflate(float i_howMuchPressureToAdd)
		{
			if (m_currentAirPressure < m_maxAirPressure)
			{
				m_currentAirPressure += i_howMuchPressureToAdd;
			}
			if (m_currentAirPressure > m_maxAirPressure)
			{
				m_currentAirPressure = m_maxAirPressure;
			}
		}
	}
}
