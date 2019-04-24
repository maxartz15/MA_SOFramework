using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SOEngine;

public class HealthUI : MonoBehaviour
{
	[SerializeField] private Text text = null;
	[SerializeField] private floatType health = null;

    void Update()
    {
        if(text != null)
		{
			text.text = "Health: " + health.Value;
		}
    }
}
