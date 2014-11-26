using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector3 originLocation;
	public Transform Piece;
	private ArrayList pieces;
	// Use this for initialization
	void Start () {
		originLocation = new Vector3 (0f, 0f, 0f);
	}

	// Use this to pass parameters to the player entity
	public void Initialize(ArrayList startingLocations) {
		pieces = new ArrayList ();
		foreach (Vector2 location in startingLocations) {
			Transform piece = Instantiate(Piece, new Vector3 (0f, 0f, 0f), Quaternion.identity) as Transform; 
			piece.GetComponent<Piece>().Initialize(location, originLocation, 1.0f);
			pieces.Add(piece);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
