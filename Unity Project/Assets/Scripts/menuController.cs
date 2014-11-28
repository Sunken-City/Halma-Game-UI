using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class menuController : MonoBehaviour {

	public GameObject player1Name;
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
		if (player1NameText != "")
		{
			PlayerPrefs.SetString ("Player1Name", player1Name.GetComponent<Text>().text);
			Debug.Log(PlayerPrefs.GetString ("Player1Name"));
			Application.LoadLevel ("gameScene");
		}
		else 
		{
			Debug.Log ("Nope.avi");
		}
	}
}
