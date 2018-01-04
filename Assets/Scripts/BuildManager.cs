using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    private GameObject turretToBuild;

    void Awake()    // Called right before start. 
    {
        instance = this; // There can be only one!
    }

    public GameObject standardTurretPrefab;
    public GameObject secondTurretPrefab;
    public GameObject thirdTurretPrefab;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
	
}
