using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public Transform Board;
		public Transform Player1;
		public Transform Player2;

		private Transform board;
		private Player player1;
		private Player player2;
		private ArrayList player1Start;
		private ArrayList player2Start;
		private ArrayList player1End;
		private ArrayList player2End;
		private string player1URLText;
		private string player2URLText;

		// Use this for initialization
		void Start ()
		{
			player1URLText = PlayerPrefs.GetString ("Player1URL");
			player2URLText = PlayerPrefs.GetString ("Player2URL");
			int player1PieceStyle = PlayerPrefs.GetInt ("Player1Piece");
			int player2PieceStyle = PlayerPrefs.GetInt ("Player2Piece");
			
			InitializeStartingPositions ();
			board = Instantiate (Board, Vector3.zero, Quaternion.identity) as Transform;
			Board boardScript = board.GetComponent<Board> ();
			//Run the board's Start method so that we can get the values for the tile's length and the Origin Tile's location
			boardScript.Start();
			float tileLength = boardScript.getTileLength ();
			Vector3 originTileLocation = boardScript.getOriginTile ();

			Transform player = Instantiate (Player1, Vector3.zero, Quaternion.identity) as Transform; 
			player1 = player.GetComponent<Player> ();
			player1.Initialize (player1PieceStyle, player1Start, player1End, originTileLocation, tileLength);
			
			player = Instantiate (Player2, Vector3.zero, Quaternion.identity) as Transform; 
			player2 = player.GetComponent<Player> ();	
			player2.Initialize (player2PieceStyle, player2Start, player2End, originTileLocation, tileLength);

		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}

		public void takeTurn()
		{
			player1.getMove(player2.getPieces(), player2End);
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
				
				player1End = new ArrayList ();
				player1End.Add (new Vector2 (15, 0));
				player1End.Add (new Vector2 (16, 0));
				player1End.Add (new Vector2 (17, 0));
				player1End.Add (new Vector2 (15, 1));
				player1End.Add (new Vector2 (16, 1));
				player1End.Add (new Vector2 (17, 1));
				player1End.Add (new Vector2 (15, 2));
				player1End.Add (new Vector2 (16, 2));
				player1End.Add (new Vector2 (17, 2));
		
				player2End = new ArrayList ();
				player2End.Add (new Vector2 (0, 0));
				player2End.Add (new Vector2 (1, 0));
				player2End.Add (new Vector2 (2, 0));
				player2End.Add (new Vector2 (0, 1));
				player2End.Add (new Vector2 (1, 1));
				player2End.Add (new Vector2 (2, 1));
				player2End.Add (new Vector2 (0, 2));
				player2End.Add (new Vector2 (1, 2));
				player2End.Add (new Vector2 (2, 2));
		}
}
