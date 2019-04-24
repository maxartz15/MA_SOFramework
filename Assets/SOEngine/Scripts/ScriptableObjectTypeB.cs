using UnityEngine;

namespace SOEngine.Base
{
	public abstract class ScriptableObjectTypeB : ScriptableObject
	{
		public bool e_keepChanges = false;


#if UNITY_EDITOR
		public abstract void SaveValues();
		public abstract void RestoreValues();
#endif
	}
}