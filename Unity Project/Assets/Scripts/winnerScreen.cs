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

	public void setWinnerName(int playerNumber){
		if (playerNumber == 1) {
			playerName.GetComponent<Text> ().text = PlayerPrefs.GetString ("Player1Name");
		} else if (playerNumber == 2) {
			playerName.GetComponent<Text> ().text = PlayerPrefs.GetString ("Player2Name");
		} else {
			playerName.GetComponent<Text> ().text = "Tie";
		}
	}

	public void playAgainOrTitleScreen(string action)
	{
		if (action == "PlayAgain")
		{
			Application.LoadLevel("gameScene");
		}
		else if (action == "TitleScreen")
		{
			Application.LoadLevel("titleScreen");
		}
	}

}
