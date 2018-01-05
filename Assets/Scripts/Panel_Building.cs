using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel_Building : MonoBehaviour {

    public Color hoverColor;
	public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

	[Header("optional")] //
    public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	public PlayerStats playerStats;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if (PlayerStats.Currency < blueprint.price) 
		{
			Debug.Log ("Not enough cash boiiiiii");
			return;
		}
		PlayerStats.Currency -= blueprint.price;

		GameObject _turret = (GameObject)Instantiate (blueprint.prefab, GetBuildPosition (), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

	}

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

       

        if (turret!= null)
        {
			buildManager.SelectPanelBuilding(this);
            return;
        }

		if (!buildManager.CanBuild)
			return;
		BuildTurret (buildManager.GetTurretToBuild ());
    }

	public void UpgradeTurret()
	{
		{
			if (PlayerStats.Currency < turretBlueprint.upgradePrice) 
			{
				Debug.Log ("Not enough cash to upgrade boiiiiii");
				return;
			}
				
			PlayerStats.Currency -= turretBlueprint.upgradePrice;

			Destroy (turret);  //removes old turret

			GameObject _turret = (GameObject)Instantiate (turretBlueprint.upgradedPrefab, GetBuildPosition (), Quaternion.identity);
		
			turret = _turret;
			Debug.Log ("Turret upgraded");
		}
	}

	public void SellTurret()
	{
		PlayerStats.Currency += turretBlueprint.sellTower();
		Destroy (turret);
		turretBlueprint = null;
	}


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        Debug.Log("Entered Hover");
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
