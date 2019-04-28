using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOEngine;
using SOEngine.Base;

public class Health : MonoBehaviour
{
	public floatType health = null;
	public floatType health1 = null;
	public float faesoifhase123jlfh;
	public floatType health2 = null;
	public float faesoifhasejlfh;

	public floatObject newHealh = null;

	public floatObject[] dammfloats;

	public floatType[] dammdsdfloats;

	public List<ffffff> fasdfasdf = new List<ffffff>();

	public eventType asldkfjhasdlkf = null;
	public eventType asldkfjhasdlkf1 = null;
	public eventType asldkfjhasdlkf2 = null;

	[System.Serializable]
	public struct ffffff
	{
		public floatType sdfioasheruopahf;
		public float myfloat;
		public floatObject asdkdj;
	}


	void Update()
    {
		if(health.Value > 0)
		{
			health.Value -= Time.deltaTime;
		}
		else
		{
			health.Value = 0;
		}
    }
}
