using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public Text currencyText;
	public static int Currency;
	public int startCurrency = 400;



	void Start()
	{
		Currency = startCurrency;	
	}

	void Update()
	{
		currencyText.text ="£" + Mathf.Floor(Currency).ToString();
	}

}
