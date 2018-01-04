using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	public void LoadGame()
    {
        Debug.Log("Load the Game");
        SceneManager.LoadScene(1);
    }
}
