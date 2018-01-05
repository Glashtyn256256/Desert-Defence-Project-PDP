using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Currency;
	public int startCurrency = 400;

	void Start()
	{
		Currency = startCurrency;	
	}
}
