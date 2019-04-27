using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventObject))]
public class EventEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		GUI.enabled = Application.isPlaying;

		EventObject e = target as EventObject;
		if (GUILayout.Button("InvokeEvent"))
		{
			e.InvokeEvent();
		}
	}
}