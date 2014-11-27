using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	float x, y, z;
	float initX, initY;
	float size;
	float tileLength;
	//also will need a Sprite attribute
	//to change the style

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Initialize(Vector2 boardLocation, Vector3 originTileLocation, float tileLength){
		this.tileLength = tileLength;
		this.transform.localScale = new Vector3 (1f * calcSize(tileLength), 1f * calcSize(tileLength), 1f);
		this.transform.position = new Vector3(calcPos(originTileLocation.x, boardLocation.x, tileLength), calcPos(originTileLocation.y, boardLocation.y, tileLength), -1f);
	}

	float calcPos(float originPosition, float boardPosition, float tileLength){
		return originPosition + (boardPosition * tileLength);
	}

	float calcSize(float tileLength){
		return 2;
	}

	void move(Vector2 desiredPlace){
		x = desiredPlace.x;
		y = desiredPlace.y;

		this.transform.position = new Vector3(calcPos(initX, x, tileLength), calcPos(initY, y, tileLength), z);		
	}
	
}
