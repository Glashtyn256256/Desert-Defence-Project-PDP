﻿using System.Collections;
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
	
	// Update is called once per frame
	void Update () {

        howManyEnemies = Wave_Spawner.enemiesAlive;

        if (enemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());    //  Use of a CoRoutine to devolve timing.
            countdown = timeBetweenWaves;   //  countdown instigates the spawning of waves.
            return;
        }

        countdown -= Time.deltaTime;        //  countdown changes smoothly.
        waveCountdownText.text = Mathf.Floor(countdown).ToString(); // Update the UI panel.

        // Possibly implement an If Statement, Only show countdown between 30 - 27 seconds, 15 to 13 second, 5 to 0 seconds
	}

    IEnumerator SpawnWave()
    {
        //Debug.Log("Spawn Wave: " + wave);
        Wave spawningWave = wave[waveIndex];

        for (int i = 0; i < spawningWave.count; i++)
        {
            SpawnEnemy(spawningWave.enemy);
            yield return new WaitForSeconds(1f / spawningWave.rate);
        }

        waveIndex++;

        if (waveIndex >= wave.Length)
        {
            waveIndex = 0;
            winPanel.SetActive(true);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        //Debug.Log("Spawning an Enemy!");
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
