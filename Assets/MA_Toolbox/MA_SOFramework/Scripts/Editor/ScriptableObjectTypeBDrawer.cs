using UnityEngine;
using UnityEditor;

namespace MA_Toolbox.MA_SOFramework.Base
{
	[CustomPropertyDrawer(typeof(ScriptableObjectTypeB), true)]
	public class ScriptableObjectTypeBDrawer : PropertyDrawer
	{
		private float additionalHeight = 0;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			//Draw label.
			EditorGUI.PropertyField(position, property, GUIContent.none, true);

			//Draw foldout properties
			if (property.isExpanded && property.objectReferenceValue != null)
			{
				EditorGUI.BeginChangeCheck();

				//Get the scriptable object.
				SerializedObject so = new SerializedObject(property.objectReferenceValue);

				//New rect for the foldout property.
				Rect valuePosition = position;
				valuePosition.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;

				//Draw scriptable object property.
				EditorGUI.PropertyField(valuePosition, so.FindProperty("m_value"), GUIContent.none, true);

				if (EditorGUI.EndChangeCheck())
				{
					property.serializedObject.ApplyModifiedProperties();
					so.ApplyModifiedProperties();
				}
			}

			//Draw foldout arrow.
			if (property.objectReferenceValue != null)
				property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none);
			else
				property.isExpanded = false;

			//Set property height.
			if (property.isExpanded)
				additionalHeight = EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
			else
				additionalHeight = 0;

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) + additionalHeight;
		}
	}
}

//Draw scriptable object inspector:

////Cached scriptable object editor
//private Editor editor = null;

//if (!editor)
//	Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor);

//if (editor)
//{
////Draw specific property.
//EditorGUI.PropertyField(valuePosition, editor.serializedObject.FindProperty("m_value"), GUIContent.none, true);

////Draw default inspector.
//editor.OnInspectorGUI();
//}

//Readonly fields:
//Make readonly.
//bool wasEnabled = GUI.enabled;
//GUI.enabled = false;
//GUI.enabled = wasEnabled;