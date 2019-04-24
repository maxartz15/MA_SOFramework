using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SOEngine.Base
{
	[CustomPropertyDrawer(typeof(ScriptableObjectTypeB), true)]
	public class ScriptableObjectTypeBDrawer : PropertyDrawer
	{
		// Cached scriptable object editor
		Editor editor = null;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Draw label
			EditorGUI.PropertyField(position, property, label, true);

			// Draw foldout arrow
			if (property.objectReferenceValue != null)
			{
				property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none);
			}

			// Draw foldout properties
			if (property.isExpanded)
			{
				int intent = EditorGUI.indentLevel;
				EditorGUI.indentLevel++;

				GUILayout.BeginVertical(/*"box"*/);
				GUILayout.BeginHorizontal();
				GUILayout.Space(position.x - 15);

				if (!editor)
				{
					Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);
				}

				if (editor)
				{
					//Make readonly.
					bool wasEnabled = GUI.enabled;
					GUI.enabled = false;
					//Draw property.
					EditorGUILayout.PropertyField(editor.serializedObject.FindProperty("m_value"), GUIContent.none);
					GUI.enabled = wasEnabled;

					//Draw default inspector.
					//editor.OnInspectorGUI();
				}

				GUILayout.Space(18);
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();

				// Set indent back to what it was
				EditorGUI.indentLevel = intent;
			}
		}
	}
}