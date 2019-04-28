using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOEngine.Base;

namespace SOEngine
{
	public class ObjectEventTrigger : MonoBehaviour
	{
		[Tooltip("Event to trigger.")]
		public eventObject m_event;

		public void TriggerEvent()
		{
			m_event.InvokeEvent();
		}
	}
}