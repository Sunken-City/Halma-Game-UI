using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuController : MonoBehaviour {

	public GameObject player1Name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void saveInfo()
	{
		Debug.Log(player1Name.GetComponent<Text>().text);
		PlayerPrefs.SetString ("Player1Name", player1Name.GetComponent<Text>().text);
		Debug.Log(PlayerPrefs.GetString ("Player1Name"));
	}
}
