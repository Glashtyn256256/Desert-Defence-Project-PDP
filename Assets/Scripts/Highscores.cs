using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour 


{
	const string privateCode = "z79OWFRtLU-KrVdSnJiTVg6pNyGjEvaEq0_mLO3KtZiQ";
	const string publicCode = "5a5379c839992a09e4c77b05";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;
	static Highscores instance;
	DisplayHighscores highscoresDisplay;


	void Awake(){
		instance = this;

			highscoresDisplay = GetComponent<DisplayHighscores> ();

	}



	public static void AddNewHighscore(string playerNameHS, int score)  //Saves us having to write startCoroutine each time, we can just call the function.
	{
		instance.StartCoroutine(instance.UploadNewHighscore(playerNameHS, score));
	}

	IEnumerator UploadNewHighscore(string playerNameHS, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(playerNameHS) + "/" + score);
		yield return www;              // This will wait till www has finished uploading the score and username.

		if (string.IsNullOrEmpty (www.error))     // This is to show if a error has occured in the uploading
		{
			print ("Upload Successsful");
			DownloadHighscores();
		}
		else
			print ("Error Uploading: " + www.error); 


	}public void DownloadHighscores()
	{
		StartCoroutine ("DownloadHighscoresFromSite");    //Same again nsaves us having to constantly type out Startcoroutine
	}

	IEnumerator DownloadHighscoresFromSite()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/0/10" );   //Downloads only the top 10 highestscores from website instead of a 1,000
		yield return www;              // The programm waits till www gets the info it needs from the site
		
		if (string.IsNullOrEmpty (www.error))     // This is to show if a error has occured in the uploading
		{
			{
				FormatHighscores (www.text);
				highscoresDisplay.OnHighscoresDownloaded (highscoresList);
			}
		}
		else
			print ("Error Downloading: " + www.error); 
		
		
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split (new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries); // If there is a empty line at the bttom it wont be added as its own entrie
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++) {      //will take the username And score from the entries array and storing it another variable
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string playerNameHS = entryInfo [0];
			int score = int.Parse (entryInfo[1]); //PASSES IT TO A INTEGER
			highscoresList[i] = new Highscore(playerNameHS,score);
			print (highscoresList[i].playerNameHS + ": " + highscoresList[i].score);

		}

	
	}
}

public struct Highscore {
	public string playerNameHS;
	public int score;

	public Highscore(string _playerNameHS, int _score){

		playerNameHS = _playerNameHS;
		score = _score;
	}
}
