using SOEngine.Base;

namespace SOEngine
{
	[System.Serializable]
	public class stringType : TypeBase<string>
	{
		public new stringObject m_objectValue;

		public override string Value
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
