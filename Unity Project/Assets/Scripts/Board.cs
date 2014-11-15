using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	public Transform tile;
	public Transform square;
	public bool floatup;
	public float boundUp;
	public float boundDown;
	public float stepSize = 0.1f;

	// Use this for initialization
	void Start () {
		floatup = false;
		square = Instantiate (tile, new Vector3 (0f, 0f, 0f), Quaternion.identity) as Transform;
		boundUp = 2f;
		boundDown = -2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (floatup)
			floatingup ();
		else if (!floatup) 
			floatingdown();
	}

	void floatingup() {
		var pos = square.position.y;
		square.position += new Vector3(0f, stepSize, 0f);
		if(pos > boundUp)
			floatup = false;
	}

	void floatingdown() {
		var pos = square.position.y;
		square.position -= new Vector3(0f, stepSize, 0f);
		if(pos < boundDown)
			floatup = true;
	}



}
