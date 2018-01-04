using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Spawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    public float countdown = 7f;
    public float timeBetweenEnemies = 0.3f;
    private int wave = 1;
	
	// Update is called once per frame
	void Update () {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());    //  Use of a CoRoutine to devolve timing.
            countdown = timeBetweenWaves;   //  countdown instigates the spawning of waves.
        }

        countdown -= Time.deltaTime;        //  countdown changes smoothly.
        waveCountdownText.text = Mathf.Floor(countdown).ToString(); // Update the UI panel.

        // Possibly implement an If Statement, Only show countdown between 30 - 27 seconds, 15 to 13 second, 5 to 0 seconds
	}

    IEnumerator SpawnWave()
    {
        //Debug.Log("Spawn Wave: " + wave);

        for (int i = 0; i < wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }

        wave++;
    }

    void SpawnEnemy()
    {
        //Debug.Log("Spawning an Enemy!");
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
