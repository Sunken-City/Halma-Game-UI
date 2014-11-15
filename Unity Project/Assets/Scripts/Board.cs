using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	public Transform tile;
	public Transform[,] squares = new Transform[18,18];
	//public Transform squareOne;
	//public Transform squareTwo;

	// Use this for initialization
	void Start () {
		var size = 18;
		int i = 0;
		int j = 0;
		float desiredScale = 3.0f;
		float tileWidth = (float)tile.renderer.bounds.size.x;
		float tileHeight = (float)tile.renderer.bounds.size.y;
		float colliderBound = 0.25f;
		BoxCollider2D boxCollider = tile.collider2D as BoxCollider2D;
		boxCollider.size = new Vector2(colliderBound, colliderBound);
		//squareOne = Instantiate (tile, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as Transform;
		//squareTwo = Instantiate (tile, new Vector3(1.0f*tileWidth, 1.0f*tileHeight, 1.0f*desiredScale), Quaternion.identity) as Transform;
		for(var x = 0.0f; x < size; x++){
			for(var y = 0.0f; y < size; y++){
				squares[i, j] = Instantiate (tile, new Vector3(x*tileWidth*desiredScale, y*tileHeight*desiredScale, 0f), Quaternion.identity) as Transform;
				//squares[i, j] = Instantiate (tile, new Vector3(x*tileWidth, y*tileHeight, 0f), Quaternion.identity) as Transform;
				//squares[i, j] = Instantiate (tile, new Vector3(x, y, 0f), Quaternion.identity) as Transform;
				j++;
			}
			i++;
			j = 0;
		}
		for(i = 0; i < size; i++)
			for(j = 0; j < size; j++)
    			squares[i,j].transform.localScale = new Vector3( 1f*desiredScale, 1f*desiredScale, 0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

}
