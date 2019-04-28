﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SOEngine.Base
{
	[CreateAssetMenu(menuName = "SOEngine/Objects/Event")]
	public class eventObject : ScriptableObject
	{
		private List<ObjectEventListener> eventListeners = new List<ObjectEventListener>();

		public void InvokeEvent()
		{
			for (int i = eventListeners.Count - 1; i >= 0; i--)
			{
				eventListeners[i].OnInvokeEvent();
			}
		}

		public void RegisterListener(ObjectEventListener listener)
		{
			if (!eventListeners.Contains(listener))
				eventListeners.Add(listener);
		}

		public void UnregisterListener(ObjectEventListener listener)
		{
			if (eventListeners.Contains(listener))
				eventListeners.Remove(listener);
		}
	}
}