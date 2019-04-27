using UnityEngine;
using UnityEngine.Events;

public class ObjectEventListener : MonoBehaviour
{
	[Tooltip("Event to register with.")]
	public EventObject m_objectEvent;

	[SerializeField]
	private UnityEvent m_onObjectEvent = null;

	private void OnEnable()
	{
		m_objectEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		m_objectEvent.UnregisterListener(this);
	}

	public void OnInvokeEvent()
	{
		m_onObjectEvent.Invoke();
	}
}