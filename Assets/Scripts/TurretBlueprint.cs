using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //Unity will save and load the values inside of this class
public class TurretBlueprint {


	// Use this for initialization
	public GameObject prefab;
	public int price;

	public GameObject upgradedPrefabTier1;
	public GameObject upgradedPrefabTier2;
	public GameObject upgradedPrefabTier3;

	public int upgradePriceTier1 = 40;
	public int upgradePriceTier2 = 80;
	public int upgradePriceTier3 = 160;


	public int selldeduction = 2;

	public int sellTower()
	{
		return price / selldeduction;  
	}
}
