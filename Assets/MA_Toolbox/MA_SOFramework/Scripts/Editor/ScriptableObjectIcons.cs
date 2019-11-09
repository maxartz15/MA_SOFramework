//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//using UnityEditor.Callbacks;
//using SOEngine.Base;

//public class ScriptableObjectIcons
//{
//	[DidReloadScripts]
//	static void GizmoIconUtility()
//	{
//		EditorApplication.projectWindowItemOnGUI = ItemOnGUI;
//	}

//	static void ItemOnGUI(string guid, Rect rect)
//	{
//		string assetPath = AssetDatabase.GUIDToAssetPath(guid);

//		ScriptableObjectTypeB obj = AssetDatabase.LoadAssetAtPath(assetPath, typeof(ScriptableObjectTypeB)) as ScriptableObjectTypeB;

//		if (obj != null)
//		{
//			//Debug.Log(rect.height);
//			//rect.width = rect.height;

//			if (rect.height == 16)
//			{
//				rect.width = rect.height;
//			}
//			else
//			{
//				rect.height = rect.width;
//			}

//			EditorGUI.DrawRect(rect, Color.blue /*(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Gizmos/SOEngine/Base/Icon.png", typeof(Texture2D))*/);
//		}
//	}
//}