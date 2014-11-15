using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	public Transform tile;
	public Transform square;
	public bool floatup;
	public int boundUp;
	public int boundDown;

	// Use this for initialization
	void Start () {
		floatup = false;
		square = Instantiate (tile, new Vector3 (0f, 0f, 0f), Quaternion.identity) as Transform;
		boundUp = 2;
		boundDown = -2;
	}
	
	// Update is called once per frame
	void Update () {
		var pos = square.position.y;
		if (boundUp < pos && floatup)
			floatingup ();
		else if (boundDown < pos && !floatup) 
			floatingdown();
	}

	void floatingup() {
		square.position += new Vector3(0f, 0.3f, 0f);
		floatup = false;
	}

	void floatingdown() {
		square.position -= new Vector3(0f, 0.3f, 0f);
		floatup = true;
	}



}
