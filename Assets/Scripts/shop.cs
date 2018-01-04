using UnityEngine;

public class shop : MonoBehaviour {

    // Use this for initialization
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void purchaseStandardTurret()
    {
        // Check that you have the money for it first, etc.
        // Closing the shop until you have placed the turret?
        Debug.Log("Standard Turret Purchased.");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void purchaseSecondTurret()
    {
        // Check that you have the money for it first, etc.
        // Closing the shop until you have placed the turret?
        Debug.Log("Second Turret Purchased.");
        buildManager.SetTurretToBuild(buildManager.secondTurretPrefab);
    }

    public void purchaseThirdTurret()
    {
        // Check that you have the money for it first, etc.
        // Closing the shop until you have placed the turret?
        Debug.Log("Third Turret Purchased.");
        buildManager.SetTurretToBuild(buildManager.thirdTurretPrefab);
    }

}
