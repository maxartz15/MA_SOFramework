using SOEngine.Base;

namespace SOEngine
{
	[System.Serializable]
	public class boolType : TypeBase<bool>
	{
		public new boolObject m_objectValue;

		public override bool Value
		{
			get
			{
				return m_useLocal ? m_localValue : m_objectValue.m_value;
			}
			set
			{
				if (m_useLocal)
				{
					m_localValue = value;
				}
				else
				{
					m_objectValue.m_value = value;
				}
			}
		}
	}
}
