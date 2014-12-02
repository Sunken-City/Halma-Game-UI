using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class winnerScreen : MonoBehaviour {
	
	public GameObject playerName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setWinnerName()
	{
			playerName.GetComponent<Text> ().text = PlayerPrefs.GetString ("WinnerPlayerName");
	}

	public void playAgainOrTitleScreen(string action)
	{
		if (action == "PlayAgain")
		{
			Application.LoadLevel("gameScene");
		}
		else if (action == "ReturnToTitle")
		{
			Application.LoadLevel("titleScreen");
		}
	}

}
