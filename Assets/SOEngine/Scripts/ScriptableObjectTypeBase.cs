using System;
using System.Collections.Generic;
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
		public override void EditorSaveValues()
		{
			if (e_keepChanges)
				return;

			e_savedValue = m_value;
		}

		public override void EditorRestoreValues()
		{
			if (e_keepChanges)
				return;

			m_value = e_savedValue;
		}
#endif

		[SerializeField]
		private T m_value;

		public T Value
		{
			get { return m_value; }
			set { OnValueChanged(value); }
		}

		private List<Action<T>> m_subscribers = new List<Action<T>>();

		private void OnValueChanged(T value)
		{
			m_value = value;

			foreach(Action<T> a in m_subscribers)
			{
				a.Invoke(value);
			}
		}

		public void Subscribe(Action<T> action)
		{
			m_subscribers.Add(action);
		}

		public void Unsubscribe(Action<T> action)
		{
			m_subscribers.Remove(action);
		}
	}
}