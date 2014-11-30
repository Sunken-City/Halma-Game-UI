using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour
{

    float tileLength;
    Vector2 boardPosition;
    Vector3 originPosition;

    public Sprite[] styles;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Grab the piece's location on the game board.
    public Vector2 getLocation()
    {
        return this.boardPosition;
    }

    public void Initialize(int pieceStyleNumber, Vector2 boardLocation, Vector3 originTileLocation, float tileLength)
    {
        this.tileLength = tileLength;
        this.originPosition = originTileLocation;
        this.boardPosition = boardLocation;
        this.transform.localScale = new Vector3(1f * calcSize(tileLength), 1f * calcSize(tileLength), 1f);
        this.transform.position = calcPos(originTileLocation, boardLocation, tileLength);
        this.GetComponent<SpriteRenderer>().sprite = styles[pieceStyleNumber];
    }

    //Calculate the position in the scene a piece needs to be at for a specific tile on the board.
    Vector3 calcPos(Vector3 originPosition, Vector2 boardPosition, float tileLength)
    {
        return new Vector3(originPosition.x + (boardPosition.x * tileLength), originPosition.y - (boardPosition.y * tileLength), -1f);
    }

    //Calculate the scale of the piece based on the size of the tiles.
    float calcSize(float tileLength)
    {
        return (float)tileLength / (float)this.renderer.bounds.size.x;
    }

    //Move a piece to a location on the board.
    public void move(Vector2 placeToMove)
    {
        this.transform.position = calcPos(originPosition, placeToMove, tileLength);
        this.boardPosition = placeToMove;
    }

}
