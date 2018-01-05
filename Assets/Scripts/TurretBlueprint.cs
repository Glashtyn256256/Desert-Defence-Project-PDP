using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //Unity will save and load the values inside of this class
public class TurretBlueprint {


	// Use this for initialization
	public GameObject prefab;
	public int price;

	public GameObject upgradedPrefab;
	public int upgradePrice;


	public int selldeduction = 2;

	public int sellTower()
	{
		return price / selldeduction;  
	}
}
