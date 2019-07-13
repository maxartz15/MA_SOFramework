using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SOEngine.Base;

public class HealthUI : MonoBehaviour
{
	[SerializeField] private Text text = null;
	[SerializeField] private floatObject health = null;

	private void OnEnable()
	{
		health.Subscribe(Health_OnValueChangedEvent);
	}

	private void Health_OnValueChangedEvent(float value)
	{
		if (text != null)
		{
			text.text = "Health: " + health.Value;
		}
	}

	private void OnDisable()
	{
		health.Unsubscribe(Health_OnValueChangedEvent);
	}
}