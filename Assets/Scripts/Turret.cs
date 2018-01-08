using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    public float range = 15;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    Vector3 measureFromMe;


    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        partToRotate = this.transform;
        measureFromMe = transform.position;
        measureFromMe.y = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Vector3 rotation = lookRotation.eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
	}

    void Shoot()
    {
        // Instantiate Bullet, and setting a target for that bullet.
       // Debug.Log("Turret Shoots.");
        GameObject bulletFired = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletFired.GetComponent<Bullet>();

        if (bullet != null)
            bullet.setTarget(target);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemyTag");

        float shortestDistance = range * 2;
        GameObject closestTarget = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(measureFromMe, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestTarget = enemy;
            }
        }

        if (closestTarget != null && shortestDistance <= range)
        {
            target = closestTarget.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 drawMe = transform.position;
        drawMe.y = 2f;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(drawMe, range);
    }
}
