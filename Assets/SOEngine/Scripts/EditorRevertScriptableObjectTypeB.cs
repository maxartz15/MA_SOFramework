#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SOEngine.Base
{
	[InitializeOnLoad]
	static class EditorRevertScriptableObjectTypeB
	{
		static EditorRevertScriptableObjectTypeB()
		{
			EditorApplication.playModeStateChanged += OnPlayModeChanged;
		}

		private static void OnPlayModeChanged(PlayModeStateChange state)
		{
			switch (state)
			{
				case PlayModeStateChange.EnteredEditMode:
					//Debug.Log("EnteredEditMode");
					RevertScriptableObjects();
					break;
				case PlayModeStateChange.ExitingEditMode:
					//Debug.Log("ExitingEditMode");
					SaveScriptableObjects();
					break;
				case PlayModeStateChange.EnteredPlayMode:
					//Debug.Log("EnteredPlayMode");
					//SaveScriptableObjects();
					break;
				case PlayModeStateChange.ExitingPlayMode:
					//Debug.Log("ExitingPlayMode");
					//RevertScriptableObjects();
					break;
			}
		}

		private static void SaveScriptableObjects()
		{
			//SaveValues.
			foreach (ScriptableObjectTypeB s in GetScriptableObjectTypeBs("Saving"))
			{
				s.SaveValues();
			}
		}

		private static void RevertScriptableObjects()
		{
			//RestoreValues.
			foreach (ScriptableObjectTypeB s in GetScriptableObjectTypeBs("Reverting"))
			{
				s.RestoreValues();
			}
		}

		private static List<ScriptableObjectTypeB> GetScriptableObjectTypeBs(string debugText = "")
		{
			List<ScriptableObjectTypeB> scriptableObjectTypeBases = new List<ScriptableObjectTypeB>();
			string[] guiIds = AssetDatabase.FindAssets("t:ScriptableObjectTypeB");

			List<string> assetPaths = new List<string>();
			foreach (string s in guiIds)
			{
				assetPaths.Add(AssetDatabase.GUIDToAssetPath(s));
			}

			scriptableObjectTypeBases = new List<ScriptableObjectTypeB>();
			foreach (string s in assetPaths)
			{
				scriptableObjectTypeBases.Add((ScriptableObjectTypeB)AssetDatabase.LoadAssetAtPath(s, typeof(ScriptableObjectTypeB)));
			}

			Debug.Log(debugText + " " + scriptableObjectTypeBases.Count + " scriptableObjectTypeBases.");

			return scriptableObjectTypeBases;
		}
	}
}
#endif