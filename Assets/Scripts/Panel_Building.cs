using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Panel_Building : MonoBehaviour {

    public Color hoverColor;
	public Vector3 positionOffset;

	public int towerTier;
	public int upgradePrice;	// Made Private. is the Inspector resetting this?
	public int tierLevel;

	public Text upgradeText;
    private Renderer rend;
    private Color startColor;

	[Header("optional")] //
    public GameObject turret;

	//[HideInInspector]
	public TurretBlueprint turretBlueprint;
//	public TurretBlueprint test;
	[HideInInspector]
	public bool isUpgraded = false;

	public PlayerStats playerStats;
    BuildManager buildManager;

    void Start()
    {
		
		upgradePrice = turretBlueprint.upgradePriceTier1;
		towerTier = 1;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
		//upgradePrice = turretBlueprint.upgradePrice;
		Debug.Log (upgradePrice);
		//upgradeText.text = "Tier " + towerTier + "\n\n" + upgradePrice;
    }

	void Update()
	{
		//upgradePriceDisplay();
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	public void upgradePriceDisplay()
	{
		
		if (towerTier == 1) {
			upgradeText.text = "Tier " + towerTier + "\n\n" + upgradePrice; 
		} else if (towerTier == 2) {
			upgradeText.text = "Tier " + towerTier + "\n\n" + upgradePrice; 
		} else if (towerTier == 3) {
			upgradeText.text = "Tier " + towerTier + "\n\n" + upgradePrice; 
		} else if (towerTier == 4) {
			upgradeText.text = "MAX LEVEL";
			towerTier = 0;
		}
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
			// Can't upgrade
			if (towerTier == 4) 
			{	
				upgradePriceDisplay();
				Debug.Log ("Turret upgraded MAX LEVEL");
				return;

			}
			else if (towerTier == 1 && PlayerStats.Currency < turretBlueprint.upgradePriceTier1) // Return if currency is less than price of 2nd tier? regardless of current tier.
			{
				Debug.Log ("Not enough cash to upgrade boiiiiii");
				return;

			} 
			else if (towerTier == 2 && PlayerStats.Currency < turretBlueprint.upgradePriceTier2) // Return if currency is less than price of 3rd tier? regardless of current tier.
			{
				Debug.Log ("Not enough cash to upgrade boiiiiii");
				return;
			}
			else if (towerTier == 3 && PlayerStats.Currency < turretBlueprint.upgradePriceTier3) // Return if currency is less than price of 3rd tier? regardless of current tier.
			{
				Debug.Log ("Not enough cash to upgrade boiiiiii");
				return;
			}
			else if (towerTier == 1) // If you can afford both Tier 2 and Tier 3... And If tower tier is 1...
			{	
				PlayerStats.Currency -= turretBlueprint.upgradePriceTier1;
				//Debug.Log (turretBlueprint.upgradePriceTier2);
				Destroy (turret);  //removes old turret

				GameObject _turret = (GameObject)Instantiate (turretBlueprint.upgradedPrefabTier1, GetBuildPosition (), Quaternion.identity);
				towerTier += 1;
				turret = _turret;
				upgradePrice = turretBlueprint.upgradePriceTier2;
				//upgradePriceDisplay();
				Debug.Log ("Turret upgraded to tier 2");
			} 
			else if (towerTier == 2) 
			{	
				PlayerStats.Currency -= turretBlueprint.upgradePriceTier2;

				Destroy (turret);  //removes old turret

				GameObject _turret = (GameObject)Instantiate (turretBlueprint.upgradedPrefabTier2, GetBuildPosition (), Quaternion.identity);
				towerTier += 1;
				turret = _turret;
				upgradePrice = turretBlueprint.upgradePriceTier3;
				//upgradePriceDisplay();
				Debug.Log ("Turret upgraded to tier 3");
			}
			else if (towerTier == 3) 
			{	
				PlayerStats.Currency -= turretBlueprint.upgradePriceTier3;

				Destroy (turret);  //removes old turret

				GameObject _turret = (GameObject)Instantiate (turretBlueprint.upgradedPrefabTier3, GetBuildPosition (), Quaternion.identity);
				towerTier += 1;
				turret = _turret;
				//upgradePriceDisplay();
				Debug.Log ("Turret upgraded to tier 3");
			}
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
