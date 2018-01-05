using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
   

    void Awake()    // Called right before start. 
    {
        instance = this; // There can be only one!
    }

    public GameObject standardTurretPrefab;
    public GameObject secondTurretPrefab;
    public GameObject thirdTurretPrefab;

	private TurretBlueprint turretToBuild;
	private Panel_Building selectedPanel;

	public Panel_BuildingUI panel_BuildingUI;

	public bool CanBuild{get{ return turretToBuild !=null; } }

	/*
	public void BuildTurretOn(Panel_Building panel_building)
	{
		if (PlayerStats.Currency < turretToBuild.price) 
		{
			Debug.Log ("Not enough cash boiiiiii");
			return;
		}
		PlayerStats.Currency -= turretToBuild.price;
		GameObject turret = (GameObject)Instantiate (turretToBuild.prefab, panel_building.GetBuildPosition (), Quaternion.identity);
		panel_building.turret = turret;

		Debug.Log ("turret built, currency left" + PlayerStats.Currency);
	}
*/
	public void SelectPanelBuilding(Panel_Building panel_building)
	{
		selectedPanel = panel_building;
		turretToBuild = null;

		panel_BuildingUI.SetTarget(panel_building);
	}

	public void DeselectPanel_Building()
	{
		selectedPanel = null;

		panel_BuildingUI.Hide();
	}
	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
		selectedPanel = null;

		DeselectPanel_Building();
	}
   
	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
	
}
