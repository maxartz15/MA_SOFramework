using UnityEngine;
using UnityEditor;

namespace SOEngine.Base
{
	[CustomPropertyDrawer(typeof(TypeB), true)]
	public class TypeBaseDrawer : PropertyDrawer
	{
		private readonly string[] popupOptions = { "local", "object" };
		private GUIStyle popupStyle;
		private SerializedProperty objectValue = null;
		private float additionalHeight = 0;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (popupStyle == null)
			{
				popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
				{
					imagePosition = ImagePosition.ImageOnly
				};
			}

			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			EditorGUI.BeginChangeCheck();

			//Get properties.
			SerializedProperty useLocal = property.FindPropertyRelative("m_useLocal");
			SerializedProperty localValue = property.FindPropertyRelative("m_localValue");
			objectValue = property.FindPropertyRelative("m_objectValue");

			//Calculate new rect for the popup.
			Rect popupRect = new Rect(position)
			{
				xMin = position.xMax - popupStyle.fixedWidth,
				yMin = position.yMin + popupStyle.margin.top,
				width = popupStyle.fixedWidth
			};
			//Set the xMax rect for the popup.
			position.xMax = popupRect.xMin;

			//Draw popup.
			int result = EditorGUI.Popup(popupRect, useLocal.boolValue ? 0 : 1, popupOptions, popupStyle);
			useLocal.boolValue = (result == 0);

			//Reset isExpanded when it uses the local value.
			if (useLocal.boolValue && objectValue != null)
				objectValue.isExpanded = false;

			//Set property height.
			if (objectValue != null && objectValue.isExpanded)
				additionalHeight = EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
			else
				additionalHeight = 0;

			//Draw local or object value.
			EditorGUI.PropertyField(position, useLocal.boolValue ? localValue : objectValue, GUIContent.none);

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