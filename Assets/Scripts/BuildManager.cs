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

	public bool CanBuild{get{ return turretToBuild !=null; } }


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
	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}
   
	
}
