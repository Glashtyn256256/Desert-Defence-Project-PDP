using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_BuildingUI : MonoBehaviour {

	public GameObject BuySellUI;
	private Panel_Building target;   //the current Panel
	//public BuildManager
	public Vector3 UIoffSet;

	public void SetTarget(Panel_Building _target) // _target is passed though
	{
		target = _target;

		transform.position = target.GetBuildPosition () + UIoffSet;

		BuySellUI.SetActive (true);
	}

	public void Hide()
	{
		BuySellUI.SetActive (false);
	}

	public void Upgrade()
	{

		Debug.Log ("clieckdkdkd");
		target.UpgradeTurret();
		BuildManager.instance.DeselectPanel_Building ();
	}


	public void Sell()
	{
		Debug.Log ("clieckdkdkd");
		target.SellTurret();
		BuildManager.instance.DeselectPanel_Building ();
	}

}

