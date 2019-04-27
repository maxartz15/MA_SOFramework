using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventTrigger : MonoBehaviour
{
	[Tooltip("Event to trigger.")]
	public EventType m_eventType;

	public void TriggerEvent()
	{
		m_eventType.InvokeEvent();
	}
}