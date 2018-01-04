using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _target;

    public float speed = 20f;
    public GameObject splatterEffect;
    public void setTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;   // How fast, normalised against change in framerate

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
//        Debug.Log("Hit!");
        GameObject effect = (GameObject)Instantiate(splatterEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        Destroy(_target.gameObject);
        Destroy(gameObject);
    }
}
