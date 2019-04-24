﻿#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace SOEngine.Base
{
	public class TypeCreatorWizard : ScriptableWizard
	{
		public string typeName = "";
		public string objectSavePath = "Assets/SOEngine/Objects/";
		public string typeSavePath = "Assets/SOEngine/Types/";
		[Multiline]
		public string usingAdditions = "";
		public bool overwrite = false;

		[MenuItem("Assets/Create/SOEngine/Create new type")]
		static void CreateWizard()
		{
			ScriptableWizard.DisplayWizard<TypeCreatorWizard>("Create TypeB", "Create");
		}

		void OnWizardCreate()
		{
			typeName = typeName.Replace(" ", "_");

			string filePath = objectSavePath + typeName + "Object.cs";

			//Create object.
			if (File.Exists(filePath) == false || overwrite)
			{
				using (StreamWriter newFile = new StreamWriter(filePath))
				{
					newFile.WriteLine("using UnityEngine;");
					if(!string.IsNullOrEmpty(usingAdditions))
						newFile.WriteLine(usingAdditions);
					newFile.WriteLine("");

					newFile.WriteLine("namespace SOEngine.Base");
					newFile.WriteLine("{");

					newFile.WriteLine("\t[CreateAssetMenu(menuName = \"SOEngine/Objects/" + typeName + "\")]");
					newFile.WriteLine("\tpublic class " + typeName + "Object : ScriptableObjectTypeBase<" + typeName + ">");
					newFile.WriteLine("\t{");

					newFile.WriteLine("\t}");

					newFile.WriteLine("}");
				}
			}
			else
			{
				Debug.Log("File already exist!");
			}

			filePath = typeSavePath + typeName + "Type.cs";

			//Create type.
			if (File.Exists(filePath) == false || overwrite)
			{
				using (StreamWriter newFile = new StreamWriter(filePath))
				{
					newFile.WriteLine("using UnityEngine;");
					newFile.WriteLine("using SOEngine.Base;");
					if (!string.IsNullOrEmpty(usingAdditions))
						newFile.WriteLine(usingAdditions);
					newFile.WriteLine("");

					newFile.WriteLine("namespace SOEngine");
					newFile.WriteLine("{");

					newFile.WriteLine("\t[System.Serializable]");
					newFile.WriteLine("\tpublic class " + typeName + "Type : TypeBase<" + typeName + ">");
					newFile.WriteLine("\t{");

					newFile.WriteLine("\t\tpublic new "+ typeName + "Object m_objectValue;");
					newFile.WriteLine("");
					newFile.WriteLine("\t\tpublic override " + typeName + " Value");
					newFile.WriteLine("\t\t{");

					newFile.WriteLine("\t\t\tget");
					newFile.WriteLine("\t\t\t{");

					newFile.WriteLine("\t\t\t\treturn m_useLocal ? m_localValue : m_objectValue.m_value;");

					newFile.WriteLine("\t\t\t}");
					newFile.WriteLine("\t\t\tset");
					newFile.WriteLine("\t\t\t{");

					newFile.WriteLine("\t\t\t\tif (m_useLocal)");
					newFile.WriteLine("\t\t\t\t{");

					newFile.WriteLine("\t\t\t\t\tm_localValue = value;");

					newFile.WriteLine("\t\t\t\t}");

					newFile.WriteLine("\t\t\t\telse");
					newFile.WriteLine("\t\t\t\t{");

					newFile.WriteLine("\t\t\t\t\tm_objectValue.m_value = value;");

					newFile.WriteLine("\t\t\t\t}");

					newFile.WriteLine("\t\t\t}");

					newFile.WriteLine("\t\t}");

					newFile.WriteLine("\t}");

					newFile.WriteLine("}");
				}
			}
			else
			{
				Debug.Log("File already exist!");
			}

			AssetDatabase.Refresh();
		}
	}
}
#endif