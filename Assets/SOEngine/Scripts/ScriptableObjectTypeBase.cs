using UnityEngine;

namespace SOEngine.Base
{
	public class ScriptableObjectTypeBase<T> : ScriptableObjectTypeB
	{
		private T e_savedValue;
#pragma warning disable CS0414
		[SerializeField, Multiline] private string e_developerDescription = "";
#pragma warning restore CS0414

#if UNITY_EDITOR
		public override void SaveValues()
		{
			if (e_keepChanges)
				return;

			e_savedValue = m_value;
		}

		public override void RestoreValues()
		{
			if (e_keepChanges)
				return;

			m_value = e_savedValue;
		}
#endif

		[SerializeField]
		public T m_value;
	}
}