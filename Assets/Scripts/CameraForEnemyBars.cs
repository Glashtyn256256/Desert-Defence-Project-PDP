using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraForEnemyBars : MonoBehaviour {

    public Canvas hbsb;
    public Camera mainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hbsb.transform.forward = mainCamera.transform.forward;
	}
}
