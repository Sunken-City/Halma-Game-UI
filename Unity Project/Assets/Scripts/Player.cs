using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Transform Piece;

	private ArrayList pieces;
	private ArrayList piecesX = new ArrayList();
	private ArrayList piecesY = new ArrayList();
	// Use this for initialization
	void Start () {
	}

	// Use this to pass parameters to the player entity
	public void Initialize(ArrayList startingLocations, Vector3 originTileLocation, float tileLength) {
		pieces = new ArrayList();

		foreach (Vector2 location in startingLocations) {
			Transform piece = Instantiate(Piece, Vector3.zero, Quaternion.identity) as Transform; 
			piece.GetComponent<Piece>().Initialize(location, originTileLocation, tileLength);
			pieces.Add(piece);
		}
	}

	public void getMove(ArrayList enemyPieces) {
		//Hector, now is your time to shine!
		//Go ahead and use the collection of pieces in the arrayList pieces to make the request with.
		

		//Once you have the piece selected and the places it needs to go, you can pass them in here.
	}

	public ArrayList getPieces() {
		return this.pieces;
	}

	// Update is called once per frame
	void Update () {
	
	}

	bool valid(Vector2 move){
		//Second check should be boards's size
		if(move.x < 0f || move.x > 17f){
			return false;
		}
		if(move.y < 0f || move.y > 17f) {
			return false;
		}
		bool pieceInBetween = pieceExists (move);
		if(pieceInBetween == false){
			return false;
		}
		return true;
	}

	bool pieceExists(Vector2 pieceLocation){
		float x = pieceLocation.x;
		float y = pieceLocation.y;
		foreach (Transform piece in pieces) {
			piecesX.Add(piece.position.x);
			piecesY.Add(piece.position.y);
		}
		bool containsX = piecesX.Contains(x);
		if (containsX == true) {
			bool containsY = piecesY.Contains(y);
			if(containsY == true) {
				return true;
			}
		}
		return false;
	}
}
