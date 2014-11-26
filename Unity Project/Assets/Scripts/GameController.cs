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
		// Use this for initialization
		void Start ()
		{
				InitializeStartingPositions ();
				board = Instantiate (Board, Vector3.zero, Quaternion.identity) as Transform;
				float tileLength = board.GetComponent<Board> ().getTileLength ();
				Vector3 originTileLocation = board.GetComponent<Board> ().getOriginTile ();
				player1 = Instantiate (Player1, Vector3.zero, Quaternion.identity) as Transform; 
				player1.GetComponent<Player> ().Initialize (player1Start, originTileLocation, tileLength);
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
		}
}
