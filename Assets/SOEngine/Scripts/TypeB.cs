//using UnityEngine.Events;

namespace SOEngine.Base
{
	[System.Serializable]
	public class TypeB
	{
		public bool m_useLocal = true;
		//private UnityEvent m_onChangeEvent = null;

		//protected void InvokeChangeEvent()
		//{
		//	if (m_onChangeEvent != null)
		//	{
		//		m_onChangeEvent.Invoke();
		//		Debug.Log("ASDASDASDASDASDASD");
		//	}
		//	else
		//		Debug.Log("No event!");
		//}

		//public void AddListener(UnityAction call)
		//{
		//	if (m_onChangeEvent == null)
		//	{
		//		Debug.Log("New Event Added!");
		//		m_onChangeEvent = new UnityEvent();
		//	}

		//	m_onChangeEvent.AddListener(call);
		//}

		//public void RemoveListener(UnityAction call)
		//{
		//	if (m_onChangeEvent != null)
		//		m_onChangeEvent.RemoveListener(call);
		//}
	}
}