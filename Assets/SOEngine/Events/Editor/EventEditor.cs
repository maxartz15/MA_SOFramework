﻿using UnityEditor;
using UnityEngine;

namespace SOEngine.Base
{
	[CustomEditor(typeof(eventObject))]
	public class EventEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			bool wasEnabled = GUI.enabled;
			GUI.enabled = Application.isPlaying;

			eventObject e = target as eventObject;
			if (GUILayout.Button("InvokeEvent"))
			{
				e.InvokeEvent();
			}

			GUI.enabled = wasEnabled;
		}
	}
}