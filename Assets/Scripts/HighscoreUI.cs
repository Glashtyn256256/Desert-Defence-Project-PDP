using UnityEngine;
using System.Collections;

public class HighscoreUI : MonoBehaviour {

    
	// Use this for initialization
    public void MainMenuOnClick()
    {
        //if (Application.loadedLevelName == "Highscore")
		GameObject keepscript;
		GameObject MusicMake;
        keepscript = GameObject.FindWithTag("Script");
        Destroy(keepscript);                  //Destroy the script, so we dont have multiple copies and we get a new script empty
		MusicMake = GameObject.FindWithTag ("Music");
		Destroy (MusicMake);     //Destroy the musbox so we dont have one keep being created sounds terrible with 5.
		Application.LoadLevel("Menu");
    }

	public void HighscoreOnClick()
	{
		Application.LoadLevel("Highscore");
	}
}
