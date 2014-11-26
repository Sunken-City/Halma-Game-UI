using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	public float x, y;
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
	
	void Initialize(Vector2 desiredPlace, Vector3 realCoors, float tileLength){
		this.x = desiredPlace.x;
		this.y = desiredPlace.y;

		this.initX = realCoors.x;
		this.initY = realCoors.y;

		this.tileLength = tileLength;

		this.transform.position = new Vector3(calcPos(initX, x, tileLength), calcPos(initY, y, tileLength), realCoors.z - 1);
	}

	float calcPos(float init, float desired, float leng){
		return init + (desired*leng);
	}
	
}
