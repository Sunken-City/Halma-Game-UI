using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	public int x, y;
	public int initX, initY;
	public float size;
	public float tileLength;
	//also will need a Sprite attribute
	//to change the style

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Initialize(Vector2 desiredPlace, Vector3 realCoors, float tileLength){
		x = desiredPlace.x;
		y = desiredPlace.y;

		initX = realCoors.x;
		initY = realCoors.y;



	}
	
}
