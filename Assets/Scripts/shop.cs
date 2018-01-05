using UnityEngine;

public class shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint secondTurret; //change names later
	public TurretBlueprint thirdTurret;

    // Use this for initialization
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        // Check that you have the money for it first, etc.
        // Closing the shop until you have placed the turret?
        Debug.Log("Standard Turret Purchased.");
       // buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
		buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectSecondTurret()
    {
        // Check that you have the money for it first, etc.
        // Closing the shop until you have placed the turret?
        Debug.Log("Second Turret Purchased.");
		buildManager.SelectTurretToBuild(secondTurret);
    }

    public void SelectThirdTurret()
    {
        // Check that you have the money for it first, etc.
        // Closing the shop until you have placed the turret?
        Debug.Log("Third Turret Purchased.");
        buildManager.SelectTurretToBuild(thirdTurret);

    }
	/*
	public void SelectTurretSell()
	{
		// Check that you have the money for it first, etc.
		// Closing the shop until you have placed the turret?
		Debug.Log("Turret Sold.");
		buildManager.TurretToSell();

	}*/
}
