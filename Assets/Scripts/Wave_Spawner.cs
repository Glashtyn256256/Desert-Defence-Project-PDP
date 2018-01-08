using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Spawner : MonoBehaviour {

    public static int enemiesAlive = 0;

    public Wave[] wave;

    //public Transform enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountdownText;

    public GameObject winPanel;

    public float timeBetweenWaves = 5f;
    public float countdown = 7f;
    public float timeBetweenEnemies = 0.3f;
    public int waveIndex = 0;
    public int howManyEnemies = 0;
	public bool Win = false;
	
	// Update is called once per frame
	void Update () {

        howManyEnemies = Wave_Spawner.enemiesAlive;

        if (enemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f && waveIndex < wave.Length && PlayerStats.playerHealth > 0)
        {
            StartCoroutine(SpawnWave());    //  Use of a CoRoutine to devolve timing.
            countdown = timeBetweenWaves;   //  countdown instigates the spawning of waves.
            return;
        }

        if (waveIndex >= wave.Length && enemiesAlive == 0 && PlayerStats.playerHealth > 0)
        {
            //waveIndex = 0;
            winPanel.SetActive(true);
			Win = true;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        

        //waveCountdownText.text = countdown.ToString(); // Update the UI panel.

	}

    IEnumerator SpawnWave()
    {
        //Debug.Log("Spawn Wave: " + wave);
        
        if(waveIndex < wave.Length)
        {

            Wave spawningWave = wave[waveIndex];

            enemiesAlive = spawningWave.count;
             for (int i = 0; i < spawningWave.count; i++)
             {
                SpawnEnemy(spawningWave.enemy, spawningWave.pathNumber);
                yield return new WaitForSeconds(1f / spawningWave.rate);
             }
            waveIndex++;
        }
    }

    void SpawnEnemy(GameObject enemyGO, int pathNumber)
    {
        //Debug.Log("Spawning an Enemy!");
        GameObject changeMe = (GameObject)Instantiate(enemyGO, spawnPoint.position, spawnPoint.rotation);

        Enemy thisClass = changeMe.GetComponent<Enemy>();
        thisClass.path = pathNumber;

        //enemiesAlive++;
    }
}
