using UnityEngine;
using SOEngine.Base;

namespace SOEngine
{
	[System.Serializable]
	public class floatType : TypeBase<float>
	{
		public new floatObject m_objectValue;

		public override float Value
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
