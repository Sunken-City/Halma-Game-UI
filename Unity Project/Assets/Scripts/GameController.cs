using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Transform Player1;
	public Transform Player2;

	private Transform player1;
	private Transform player2;
	private ArrayList player1Start;
	// Use this for initialization
	void Start () {
		InitializeStartingPositions ();
		player1 = Instantiate(Player1, new Vector3 (0f, 0f, 0f), Quaternion.identity) as Transform; 
		player1.GetComponent<Player>().Initialize(player1Start);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeStartingPositions()
	{
		player1Start = new ArrayList ();
		player1Start.Add (new Vector2 (0, 15));
		player1Start.Add (new Vector2 (1, 15));
		player1Start.Add (new Vector2 (2, 15));
		player1Start.Add (new Vector2 (0, 16));
		player1Start.Add (new Vector2 (1, 16));
		player1Start.Add (new Vector2 (2, 16));
		player1Start.Add (new Vector2 (0, 17));
		player1Start.Add (new Vector2 (1, 17));
		player1Start.Add (new Vector2 (2, 17));
	}
}
