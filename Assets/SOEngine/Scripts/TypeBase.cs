namespace SOEngine.Base
{
	[System.Serializable]
	public abstract class TypeBase<T> : TypeB
	{
		public T m_localValue;
		public ScriptableObjectTypeBase<T> m_objectValue;

		public TypeBase() { }

		public TypeBase(T value)
		{
			m_useLocal = true;
			m_localValue = value;
		}

		public abstract T Value { get; set; }

		public static implicit operator T(TypeBase<T> value)
		{
			return value.Value;
		}
	}
}