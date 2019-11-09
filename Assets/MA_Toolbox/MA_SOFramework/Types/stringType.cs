using UnityEngine;
using MA_Toolbox.MA_SOFramework.Base;

namespace MA_Toolbox.MA_SOFramework
{
	[System.Serializable]
	public class stringType : TypeBase<string>
	{
		public new stringObject m_objectValue;

		public override string Value
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
