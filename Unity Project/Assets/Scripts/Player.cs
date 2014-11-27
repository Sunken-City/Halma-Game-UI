﻿using UnityEngine;
using System.Collections; 

public class Player : MonoBehaviour {

	public Transform Piece;
	private ArrayList pieces;
	// Use this for initialization
	void Start () {
	}

	// Use this to pass parameters to the player entity
	public void Initialize(ArrayList startingLocations, Vector3 originTileLocation, float tileLength) {
		pieces = new List ();
		foreach (Vector2 location in startingLocations) {
			Transform piece = Instantiate(Piece, Vector3.zero, Quaternion.identity) as Transform; 
			piece.GetComponent<Piece>().Initialize(location, originTileLocation, tileLength);
			pieces.Add(piece);
		}
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

	bool pieceExists(Vector2 piece){
		float x = piece.x;
		float y = piece.y;
		
		List subSetPiecesX = pieces.FindAll(p => p.x == x);
		if (subSetPiecesX.Count() >= 1) {
			List subSetPiecesXandY = pieces.FindAll(p => p.y == y);
			if(subSetPiecesXandY.Count() >= 1) {
				return true;
			}
		}
		return false;
	}
}
