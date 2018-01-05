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

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret!= null)
        {
            Debug.Log("Already have a turret here.");
            return;
        }

		buildManager.BuildTurretOn (this);
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
