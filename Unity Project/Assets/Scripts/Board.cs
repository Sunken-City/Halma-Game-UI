using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	public Transform tile;
	public Transform[,] squares = new Transform[18,18];
	public Transform squareTwo;

	// Use this for initialization
	void Start () {
		var size = 18;
		int i = 0;
		int j = 0;
		for(var x = 0; x < size; x++){
			for(var y = 0; y < size; y++){
				float tileWidth = (float)tile.renderer.bounds.size.x;
				float tileHeight = (float)tile.renderer.bounds.size.y;
				squares[i, j] = Instantiate (tile, new Vector3(x*tileWidth, y*tileHeight, 0f), Quaternion.identity) as Transform;
				j++;
			}
			i++;
			j = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

}
