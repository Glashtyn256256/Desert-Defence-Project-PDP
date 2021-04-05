using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public AudioSource titleSong;

    

	// Use this for initialization
	public void LoadGame()
    {
        Debug.Log("Load the Game");
        Wave_Spawner.enemiesAlive = 0;
        SceneManager.LoadScene(1);
    }
    public void LoadHighscore()
    {
        Wave_Spawner.enemiesAlive = 0;
        SceneManager.LoadScene(2);
    }

    public void GoToStartMenu()
    {
        Debug.Log("Going to Start Menu");
        Wave_Spawner.enemiesAlive = 0;
        SceneManager.LoadScene(0);
    }

	public void SubmitScore()
	{
		PlayerStats.AddHighscore ();
	}
}
