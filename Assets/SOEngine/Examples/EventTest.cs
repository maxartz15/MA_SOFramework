using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOEngine;

public class EventTest : MonoBehaviour
{
	[SerializeField] private SOEngine.eventType eventType = null;

	public void ButtonClick()
	{
		eventType.InvokeEvent();
	}
}
