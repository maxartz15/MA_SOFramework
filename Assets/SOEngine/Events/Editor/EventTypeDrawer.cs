using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EventType), true)]
public class EventTypeDrawer : PropertyDrawer
{
	private readonly string[] popupOptions = { "unityEvent", "objectEvent" };
	private GUIStyle popupStyle;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (popupStyle == null)
		{
			popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
			popupStyle.imagePosition = ImagePosition.ImageOnly;
		}

		label = EditorGUI.BeginProperty(position, label, property);
		position = EditorGUI.PrefixLabel(position, label);

		EditorGUI.BeginChangeCheck();

		// Get properties
		SerializedProperty useUnity = property.FindPropertyRelative("m_useUnity");
		SerializedProperty unityEvent = property.FindPropertyRelative("m_unityEvent");
		SerializedProperty objectEvent = property.FindPropertyRelative("m_objectEvent");

		// Calculate rect for configuration button
		Rect buttonRect = new Rect(position);
		buttonRect.yMin += popupStyle.margin.top;
		buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
		if (!useUnity.boolValue)
		{
			position.xMin = buttonRect.xMax + 10;
		}
		else
		{
			position.xMin = buttonRect.xMax;
			GUILayout.Space(EditorGUI.GetPropertyHeight(unityEvent, true));
		}

		// Store old indent level and set it to 0, the PrefixLabel takes care of it
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		int result = EditorGUI.Popup(buttonRect, useUnity.boolValue ? 0 : 1, popupOptions, popupStyle);

		useUnity.boolValue = result == 0;

		EditorGUI.PropertyField(position, useUnity.boolValue ? unityEvent : objectEvent, GUIContent.none);

		if (EditorGUI.EndChangeCheck())
		{
			property.serializedObject.ApplyModifiedProperties();
		}

		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}
}