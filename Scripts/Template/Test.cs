//MD5Hash:660abe70226cea69fd5ecece62269f3a;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;


public class Test : UnityEngine.MonoBehaviour
{
	public System.Collections.Generic.List<UnityEngine.GameObject> dudeList = new System.Collections.Generic.List<UnityEngine.GameObject>();


	void Awake()
	{
		System.Collections.Generic.List<UnityEngine.GameObject> dudeList1 = null;

		dudeList1 = new System.Collections.Generic.List<UnityEngine.GameObject>();
		dudeList1[0].active = false;
	}
	public System.Collections.IEnumerator Duder()
	{
		yield return new UnityEngine.WaitForSeconds(1f);
	}
	public void Duder2()
	{
		StartCoroutine(Duder().ToString());
	}
}


