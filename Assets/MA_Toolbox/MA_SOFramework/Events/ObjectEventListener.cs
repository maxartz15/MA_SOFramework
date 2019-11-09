using UnityEngine;
using UnityEngine.Events;
using MA_Toolbox.MA_SOFramework.Base;

namespace MA_Toolbox.MA_SOFramework
{
	public class ObjectEventListener : MonoBehaviour
	{
		[Tooltip("Event to register with.")]
		public eventObject m_objectEvent;

		[SerializeField]
		private UnityEvent m_onObjectEvent = null;

		private void OnEnable()
		{
			m_objectEvent.RegisterListener(this);
		}

		private void OnDisable()
		{
			m_objectEvent.UnregisterListener(this);
		}

		public void OnInvokeEvent()
		{
			m_onObjectEvent.Invoke();
		}
	}
}