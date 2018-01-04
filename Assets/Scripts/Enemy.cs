using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int pointIndex = 0;

    void Start()
    {
        target = Waypoint.points[0];
    }

    void Update()
    {   
        // Target Position - the Enemy's position gives relative position.
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            FindNextWaypoint();
        }
    }
	
    void FindNextWaypoint()
    {
        if (pointIndex >= (Waypoint.points.Length - 1))
        {
            Destroy(gameObject);
            return;
        }

        pointIndex++;
        target = Waypoint.points[pointIndex];
    }
}
