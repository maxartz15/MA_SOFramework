using UnityEngine;
using UnityEditor;

namespace SOEngine.Base
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(MonoBehaviour), true)]
	public class MonoBehaviourEditor : Editor
	{
	}
}