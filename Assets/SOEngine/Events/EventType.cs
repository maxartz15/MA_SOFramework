﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SOEngine.Base;

namespace SOEngine
{
	[System.Serializable]
	public class eventType
	{
		public bool m_useUnity = true;
		[SerializeField] private UnityEvent m_unityEvent = new UnityEvent();
		[SerializeField] private eventObject m_objectEvent = null;

		public void InvokeEvent()
		{
			if (m_useUnity)
			{
				m_unityEvent.Invoke();
			}
			else if (m_objectEvent != null)
			{
				m_objectEvent.InvokeEvent();
			}
		}
	}
}