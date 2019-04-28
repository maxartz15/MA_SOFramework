using UnityEngine;
using UnityEditor;
using SOEngine;

namespace SOEngine.Base
{
	[CustomPropertyDrawer(typeof(eventType), true)]
	public class EventTypeDrawer : PropertyDrawer
	{
		private readonly string[] popupOptions = { "unityEvent", "objectEvent" };
		private GUIStyle popupStyle;
		private SerializedProperty useUnity = null;
		private SerializedProperty unityEvent = null;
		private float additionalHeight = 0;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (popupStyle == null)
			{
				popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
				popupStyle.imagePosition = ImagePosition.ImageOnly;
			}

			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			EditorGUI.BeginChangeCheck();

			//Get properties.
			useUnity = property.FindPropertyRelative("m_useUnity");
			unityEvent = property.FindPropertyRelative("m_unityEvent");
			SerializedProperty objectEvent = property.FindPropertyRelative("m_objectEvent");

			//Calculate new rect for the popup.
			Rect popupRect = new Rect(position)
			{
				xMin = position.xMax - popupStyle.fixedWidth,
				yMin = position.yMin + popupStyle.margin.top,
				width = popupStyle.fixedWidth
			};
			//Set the xMax rect for the popup.
			position.xMax = popupRect.xMin;

			int result = EditorGUI.Popup(popupRect, useUnity.boolValue ? 0 : 1, popupOptions, popupStyle);
			useUnity.boolValue = result == 0;

			//Set property height.
			if (useUnity.boolValue)
				additionalHeight = EditorGUI.GetPropertyHeight(unityEvent, true);
			else
				additionalHeight = 0;

			EditorGUI.PropertyField(position, useUnity.boolValue ? unityEvent : objectEvent, GUIContent.none);

			if (EditorGUI.EndChangeCheck())
				property.serializedObject.ApplyModifiedProperties();

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) + additionalHeight;
		}
	}
}