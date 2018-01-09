using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour {

	public Text[] HighscoreText;
	Highscores HighscoreManager;

	// Use this for initialization
	void Start () {
	
		for (int i = 0; i < HighscoreText.Length; i++)
		{
			HighscoreText[i].text = i+1 + ".Fetching...";

		}

		HighscoreManager = GetComponent<Highscores> ();

		StartCoroutine ("RefreshHighscores");
	}

	public void OnHighscoresDownloaded(Highscore[] highscoreList) 
	{
		Debug.Log ("working OnhighscoresDownload");
		for (int i = 0; i < HighscoreText.Length; i++) 
		{
			HighscoreText[i].text = i+1 +". ";
			if (highscoreList.Length > i)
			{
				HighscoreText[i].text += highscoreList[i].playerNameHS + " - " + highscoreList[i].score;
			}
		}
	}

	IEnumerator RefreshHighscores()
	{
		while (true) {
			//Debug.Log ("working refreshonhighscores");
			HighscoreManager.DownloadHighscores();
			yield return new WaitForSeconds(30); //refreshes the leaderboard every 30 seconds
		}

	}

}
