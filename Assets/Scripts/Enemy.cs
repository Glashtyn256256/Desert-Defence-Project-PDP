using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {


	public float startSpeed = 10f;
	public float speed;
	public bool iceStatus;
	public float startSlowTime = 0f;
	public float slowTime;
	public float xslowtime = 5f;



    private Transform target;

	public int currencyvalue = 10;
	public float startHealth = 100f;
    public int damageToWall = 1;
	private float health;
    private int pointIndex = 0;

    public int path = 1;

    [Header("Unity Specific")]
	public Image healthBar;
	public Image statusBar;

    void Start()
    {
        if (path == 1)
            target = Waypoint.path1points[0];
        else
            target = Waypoint.path2points[0];
        health = startHealth;

		health = startHealth;
		slowTime = startSlowTime;
		speed = startSpeed;
		statusBar.fillAmount = 0.0f;
    }

    void Update()
    {   
        if(PlayerStats.playerHealth <= 0)
        {
            Die();
        }
        // Target Position - the Enemy's position gives relative position.
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            FindNextWaypoint();
        }

		if (iceStatus == true) 
		{
			Debug.Log ("True works");
			if (slowTime == 0) 
			{
				Debug.Log(slowTime + "in update"); 
				iceStatus = false;
				speed = startSpeed;

			}
			else
			{
				Debug.Log ("Fillbar works");

				slowTime -= Time.deltaTime;
				statusBar.fillAmount = slowTime/xslowtime;
				slowTime = Mathf.Clamp(slowTime, 0f, Mathf.Infinity);
				Debug.Log (slowTime);

			}
		}
	}

    

	public void TakeDamage (float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0) 
		{
			PlayerStats.Currency += currencyvalue;
			Die();
		}
	}

	public void TakeSpeedDamage(float damage)
	{

		health -= damage;
		healthBar.fillAmount = health / startHealth;
		speed = 5f;
		slowTime = 5f;
		iceStatus = true;
		Debug.Log (slowTime);
		Debug.Log (speed);

	}

   public void DamageWall()
    {
        PlayerStats.playerHealth -= damageToWall;
    }

	void Die()
	{
        Wave_Spawner.enemiesAlive--;
		Destroy (gameObject);
	}

    void FindNextWaypoint()
    {
        if (path == 1)
        {

            if (pointIndex >= (Waypoint.path1points.Length - 1))
            {
                //Destroy(gameObject);
                DamageWall();
                Die();
                return;
            }
            pointIndex++;
            target = Waypoint.path1points[pointIndex];
        }

        if (path == 2)
        {

            if (pointIndex >= (Waypoint.path2points.Length - 1))
            {
                //Destroy(gameObject);
                DamageWall();
                Die();
                return;
            }
            pointIndex++;
            target = Waypoint.path2points[pointIndex];
        }
    }
}
