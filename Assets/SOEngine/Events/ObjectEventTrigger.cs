using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOEngine
{
	public class ObjectEventTrigger : MonoBehaviour
	{
		[Tooltip("Event to trigger.")]
		public eventType m_eventType;
		public float m_test;

		public void TriggerEvent()
		{
			m_eventType.InvokeEvent();
		}
	}
}