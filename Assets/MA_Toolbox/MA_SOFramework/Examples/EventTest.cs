using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
	[SerializeField] private MA_Toolbox.MA_SOFramework.eventType eventType = null;

	public void ButtonClick()
	{
		eventType.InvokeEvent();
	}
}
