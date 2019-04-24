using UnityEngine;
using UnityEditor;

namespace SOEngine.Base
{
	[CustomPropertyDrawer(typeof(TypeB), true)]
	public class TypeBaseDrawer : PropertyDrawer
	{
		private readonly string[] popupOptions = { "local", "object" };
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
			SerializedProperty useLocal = property.FindPropertyRelative("m_useLocal");
			SerializedProperty localValue = property.FindPropertyRelative("m_localValue");
			SerializedProperty objectValue = property.FindPropertyRelative("m_objectValue");

			// Calculate rect for configuration button
			Rect buttonRect = new Rect(position);
			buttonRect.yMin += popupStyle.margin.top;
			buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
			if (!useLocal.boolValue)
			{
				position.xMin = buttonRect.xMax + 10;
			}
			else
			{
				position.xMin = buttonRect.xMax;
			}

			// Store old indent level and set it to 0, the PrefixLabel takes care of it
			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			int result = EditorGUI.Popup(buttonRect, useLocal.boolValue ? 0 : 1, popupOptions, popupStyle);

			useLocal.boolValue = result == 0;

			EditorGUI.PropertyField(position, useLocal.boolValue ? localValue : objectValue, GUIContent.none);

			if (EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();
			}

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}
	}
}