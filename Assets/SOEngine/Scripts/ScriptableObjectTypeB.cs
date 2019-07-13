using UnityEngine;

namespace SOEngine.Base
{
	public abstract class ScriptableObjectTypeB : ScriptableObject
	{
		public bool e_keepChanges = false;


#if UNITY_EDITOR
		public abstract void EditorSaveValues();
		public abstract void EditorRestoreValues();
#endif
	}
}