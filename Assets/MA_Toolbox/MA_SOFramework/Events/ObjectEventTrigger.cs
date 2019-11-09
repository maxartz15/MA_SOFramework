using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA_Toolbox.MA_SOFramework.Base;

namespace MA_Toolbox.MA_SOFramework
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