using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOEngine;
using SOEngine.Base;

public class Health : MonoBehaviour
{
	public floatType health = null;

	void Update()
    {
		if(health.Value > 0)
			health.Value -= Time.deltaTime;
		else
			health.Value = 0;
    }

	public void Damage(float amount)
	{
		health.Value -= amount;
	}
}
