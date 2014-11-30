using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour
{
    public Transform tile;
    public int size = 18;
    public float tileScale = 3.3f;
    private float scaleFactor = 3.3f;
    private Vector3 originTilePosition = Vector3.zero;
    Transform[,] squares;
    public bool isInitialized = false;
    // Use this for initialization
    public void Start()
    {
        if (!isInitialized)
        {
            //Declare and Initialize some constants we're going to use.
            float tileWidth = (float)tile.renderer.bounds.size.x;
            float colliderBound = tileWidth;
            BoxCollider2D boxCollider = tile.collider2D as BoxCollider2D;
            squares = new Transform[size, size];

            scaleFactor = tileWidth * tileScale;
            boxCollider.size = new Vector2(colliderBound, colliderBound);
            //Offset each tile's location by 1/2 the size of the board plus an additional amount to center the board.
            float gridOffset = ((size * scaleFactor) / -2.0f) + (scaleFactor / 2.0f);

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    //Each tile's position is determined by scaling it, then offsetting it so that the board is centered.
                    squares[x, y] = Instantiate(tile,
                                      new Vector3(x * scaleFactor + gridOffset, y * scaleFactor + gridOffset, 0f),
                                      Quaternion.identity) as Transform;
                    squares[x, y].transform.localScale = new Vector3(1f * tileScale, 1f * tileScale, 0f);
                }
            }

            //Set the origin tile's position (Board location 0,0) by using the top left tile.
            originTilePosition = squares[0, size - 1].transform.position;
            isInitialized = true;
        }
    }

    //Getters and Setters
    public int getSize()
    {
        return size;
    }

    public float getTileLength()
    {
        return scaleFactor;
    }

    public Vector3 getOriginTile()
    {
        return originTilePosition;
    }

    //Use the destinations for a team to color that team's end zone.
    public void createDestination(ArrayList destinations, int style)
    {
        foreach (Vector2 location in destinations)
        {
            squares[(int)location.x, 17 - (int)location.y].GetComponent<Tile>().changeColor(style);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
