using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour
{
		public Transform tile;
		public Transform piece;
		public int size = 18;
		public float tileScale = 3.0f;

		Transform[,] squares;
		
		// Use this for initialization
		void Start ()
		{
			//Declare and Initialize some constants we're going to use.
			float tileWidth = (float)tile.renderer.bounds.size.x;
			float colliderBound = tileWidth;
			BoxCollider2D boxCollider = tile.collider2D as BoxCollider2D;
			squares = new Transform[size, size];

			float scaleFactor = tileWidth * tileScale;
			boxCollider.size = new Vector2 (colliderBound, colliderBound);
			//Offset each tile's location by 1/2 the size of the board plus an additional amount to center the board.
			float gridOffset = ((size * scaleFactor) / -2.0f) + (scaleFactor / 2.0f);
			
			for (int x = 0; x < size; x++) 
			{
					for (int y = 0; y < size; y++) 
					{
							//Each tile's position is determined by scaling it, then offsetting it so that the board is centered.
							squares [x, y] = Instantiate (tile, 
				                              			  new Vector3 (x * scaleFactor + gridOffset, y * scaleFactor + gridOffset, 0f), 
				                              			  Quaternion.identity) as Transform;
					}
			}
			
			for (int x = 0; x < size; x++)
					for (int y = 0; y < size; y++)
							squares [x, y].transform.localScale = new Vector3 (1f * tileScale, 1f * tileScale, 0f);

		}
	
		// Update is called once per frame
		void Update ()
		{

		}
}
