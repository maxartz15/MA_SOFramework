using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
	[Tooltip("Event to register with.")]
	public GameEvent gameEvent;

	[SerializeField]
	private UnityEvent onGameEvent = null;

	private void OnEnable()
	{
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnregisterListener(this);
	}

	public void OnInvokeEvent()
	{
		onGameEvent.Invoke();
	}
}