﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _target;

	public int damage = 20;

    public float speed = 20f;

    public float explosionRadius = 0f;

    public GameObject splatterEffect;
    public void setTarget(Transform newTarget)
    {
        _target = newTarget;
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
        transform.LookAt(_target);
	}

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy> ();
		if (e != null) 
		{
			e.TakeDamage (damage);
		}

	}

    void HitTarget()
    {
//        Debug.Log("Hit!");
        GameObject effect = (GameObject)Instantiate(splatterEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
    		Damage(_target);
        }

        //Destroy(_target.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        Debug.Log("Missile Has Exploded");
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            if (col.tag == "enemyTag")
            {
                //Damage(col.transform);
                Enemy e = col.GetComponent<Enemy>();
                if (e != null)
                {
                    Debug.Log("enemy to Take Damage");
                    e.TakeDamage(damage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (explosionRadius > 0f)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}
