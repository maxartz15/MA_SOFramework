using UnityEngine;
using SOEngine.Base;

namespace SOEngine
{
	[System.Serializable]
	public class doubleType : TypeBase<double>
	{
		public new doubleObject m_objectValue;

		public override double Value
		{
			get
			{
				return m_useLocal ? m_localValue : m_objectValue.Value;
			}
			set
			{
				if (m_useLocal)
				{
					m_localValue = value;
				}
				else
				{
					m_objectValue.Value = value;
				}
			}
		}
	}
}
