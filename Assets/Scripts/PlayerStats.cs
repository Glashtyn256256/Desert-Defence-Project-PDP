using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public Text currencyText;
    public Text playerHealthText;

    public int startCurrency = 400;
    public static int Currency;

    public float startPlayerHealth = 20;
    public static float playerHealth;

    [Header("Unity Specific")]
    public Image playerHealthBar;
    public GameObject losePanel;


    void Start()
	{
        playerHealth = startPlayerHealth;
		Currency = startCurrency;	
	}

	void Update()
	{
        
		currencyText.text ="£" + Mathf.Floor(Currency).ToString();
        playerHealthText.text = Mathf.Floor(playerHealth).ToString() + "%";

        UpdatePlayerHealthBar();
        if (playerHealth <= 0)
        {
            Debug.Log(playerHealth);
            Debug.Log("Game Over");
            losePanel.SetActive(true);

            
        }
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

