using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	float size;
	float tileLength;
	float colliderSize;
	Vector2 boardPosition;
	Vector3 originPosition;
	//also will need a Sprite attribute
	//to change the style

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector2 getLocation()
	{
		return this.boardPosition;
	}
	
	public void Initialize(Vector2 boardLocation, Vector3 originTileLocation, float tileLength){
		this.tileLength = tileLength;
		this.originPosition = originTileLocation;
		this.boardPosition = boardLocation;
		this.transform.localScale = new Vector3 (1f * calcSize(tileLength), 1f * calcSize(tileLength), 1f);
		this.transform.position = calcPos(originTileLocation, boardLocation, tileLength);
	}

	Vector3 calcPos(Vector3 originPosition, Vector2 boardPosition, float tileLength){
		return new Vector3(originPosition.x + (boardPosition.x * tileLength), originPosition.y - (boardPosition.y * tileLength), -1f);
	}

	float calcSize(float tileLength){
		return (float)tileLength / (float)this.renderer.bounds.size.x;
		//return 2;
	}

	void move(Vector2 placeToMove){
		this.transform.position = calcPos(originPosition, placeToMove, tileLength);		
	}
	
}
