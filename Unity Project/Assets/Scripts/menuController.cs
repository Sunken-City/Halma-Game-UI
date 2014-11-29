using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class menuController : MonoBehaviour {

	public GameObject player1Name;
	public GameObject player2Name;
	public GameObject player1URL;
	public GameObject player2URL;
	// Use this for initialization
	void Start () {
		this.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void saveInfo()
	{
		string player1NameText = player1Name.GetComponent<Text>().text;
		string player2NameText = player2Name.GetComponent<Text>().text;
		string player1URLText = player1URL.GetComponent<Text>().text;
		string player2URLText = player2URL.GetComponent<Text>().text;
		if (player1NameText == "" || player2NameText == "" || player1URLText == "" || player2URLText == "")
		{
			return;
		}
		else 
		{
			PlayerPrefs.SetString ("Player1Name", player1Name.GetComponent<Text>().text);
			PlayerPrefs.SetString ("Player2Name", player2Name.GetComponent<Text>().text);
			PlayerPrefs.SetString ("Player1URL", player1URL.GetComponent<Text>().text);
			PlayerPrefs.SetString ("Player2URL", player2URL.GetComponent<Text>().text);
			Application.LoadLevel ("gameScene");
		}
	}
}
