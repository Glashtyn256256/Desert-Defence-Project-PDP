using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public InputField WplayerUsername;
	public InputField LplayerUsername;

	public Text WscoreTextBox;
	public Text LscoreTextBox;

	public static string username;

	public Text currencyText;
    public int startCurrency = 400;
    public static int Currency;

	public Text playerHealthText;
    public float startPlayerHealth = 20;
    public static float playerHealth;

    [Header("Unity Specific")]
    public Image playerHealthBar;
    public GameObject losePanel;
	public Wave_Spawner checkWin;


    void Start()
	{
        playerHealth = startPlayerHealth;
		Currency = startCurrency;	
	}

	void Update()
	{
        
		currencyText.text ="£" + Mathf.Floor(Currency).ToString();
        playerHealthText.text ="Wall: " + Mathf.Floor(playerHealth).ToString();
		InputName ();
        UpdatePlayerHealthBar();
        if (playerHealth <= 0)
        {
           // Debug.Log(playerHealth);
          //  Debug.Log("Game Over");
            losePanel.SetActive(true);

        }
    }

	public void InputName()
	{
		if (checkWin.Win == true) 
		{
			username = WplayerUsername.text;
		}
		else
			username = LplayerUsername.text;
		checkWin.Win = false;
	}

	public static void AddHighscore()
	{
		Debug.Log("done");
		Highscores.AddNewHighscore (username, Currency);
	}
		
    public void UpdatePlayerHealthBar()
    {
        playerHealthBar.fillAmount = playerHealth / startPlayerHealth;
    }
        /*
        //can have a switch here for whewn health is at 75, 50 25 play different animation of the wall falling apart
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    */
}

