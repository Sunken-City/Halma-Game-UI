using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public Transform Board;
		public Transform Player1;
		public Transform Player2;

		private Transform board;
		private Transform player1;
		private Transform player2;
		private ArrayList player1Start;
		private ArrayList player2Start;

		// Use this for initialization
		void Start ()
		{
				InitializeStartingPositions ();
				board = Instantiate (Board, Vector3.zero, Quaternion.identity) as Transform;
				var boardScript = board.GetComponent<Board> ();
				//Run the board's Start method so that we can get the values for the tile's length and the Origin Tile's location
				boardScript.Start();
				float tileLength = boardScript.getTileLength ();
				Vector3 originTileLocation = boardScript.getOriginTile ();

				player1 = Instantiate (Player1, Vector3.zero, Quaternion.identity) as Transform; 
				player1.GetComponent<Player> ().Initialize (player1Start, originTileLocation, tileLength);
				
				player2 = Instantiate (Player2, Vector3.zero, Quaternion.identity) as Transform; 
				player2.GetComponent<Player> ().Initialize (player2Start, originTileLocation, tileLength);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void InitializeStartingPositions ()
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

				player2Start = new ArrayList ();
				player2Start.Add (new Vector2 (15, 15));
				player2Start.Add (new Vector2 (16, 15));
				player2Start.Add (new Vector2 (17, 15));
				player2Start.Add (new Vector2 (15, 16));
				player2Start.Add (new Vector2 (16, 16));
				player2Start.Add (new Vector2 (17, 16));
				player2Start.Add (new Vector2 (15, 17));
				player2Start.Add (new Vector2 (16, 17));
				player2Start.Add (new Vector2 (17, 17));
		}
}
