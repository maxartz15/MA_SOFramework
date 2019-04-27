using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
	[SerializeField] private EventType eventType = null;

	public void ButtonClick()
	{
		eventType.InvokeEvent();
	}
}
