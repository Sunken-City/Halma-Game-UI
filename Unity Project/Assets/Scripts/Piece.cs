using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	public float x, y, z;
	public float initX, initY;
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
	
	public void Initialize(Vector2 desiredPlace, Vector3 realCoors, float tileLength){
		this.x = desiredPlace.x;
		this.y = desiredPlace.y;
		this.z = realCoors.z - 1;

		this.initX = realCoors.x;
		this.initY = realCoors.y;

		this.tileLength = tileLength;


		this.transform.localScale = new Vector3 (1f*calcSize(tileLength), 1f*calcSize(tileLength), 1f);

		this.transform.position = new Vector3(calcPos(initX, x, tileLength), calcPos(initY, y, tileLength), this.z);
	}

	float calcPos(float init, float desired, float leng){
		return init + (desired*leng);
	}

	float calcSize(float leng){
		return leng * (7f / 8f); 
	}

	void move(Vector2 desiredPlace){
		x = desiredPlace.x;
		y = desiredPlace.y;

		this.transform.position = new Vector3(calcPos(initX, x, tileLength), calcPos(initY, y, tileLength), z);		
	}
	
}
