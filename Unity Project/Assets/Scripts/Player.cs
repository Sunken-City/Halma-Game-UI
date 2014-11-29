using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	public Transform Piece;
	
	private ArrayList pieces;
	private ArrayList destinations;
	private ArrayList piecesX = new ArrayList();
	private ArrayList piecesY = new ArrayList();
	private string webServiceURL = "http://lyle.smu.edu/~tbgeorge/cse4345/a1/getMove.php";
	
	// Use this for initialization
	void Start () {
		
	}

	// Use this to pass parameters to the player entity
	public void Initialize(int pieceStyleNumber, ArrayList startingLocations, ArrayList destinations, Vector3 originTileLocation, float tileLength) {
		pieces = new ArrayList();
		this.destinations = destinations;

		foreach (Vector2 location in startingLocations) {
			Transform piece = Instantiate(Piece, Vector3.zero, Quaternion.identity) as Transform; 
			piece.GetComponent<Piece>().Initialize(pieceStyleNumber, location, originTileLocation, tileLength);
			pieces.Add(piece);
		}
	}
	
	public void setURL(string URL)
	{
		webServiceURL = URL;
	}
	
	public JSONObject arrayListToJSON(ArrayList serializable)
	{
		JSONObject locationJSON = new JSONObject(JSONObject.Type.ARRAY);
		foreach (Vector2 location in serializable)
		{
			JSONObject xyJSON = new JSONObject(JSONObject.Type.OBJECT);
			xyJSON.AddField("x", location.x);
			xyJSON.AddField("y", location.y);
			locationJSON.Add(xyJSON);
		}
		return locationJSON;
	}

	public JSONObject pieceListToJSON(ArrayList pieces)
	{
		JSONObject locationJSON = new JSONObject(JSONObject.Type.ARRAY);
		foreach (Transform piece in pieces)
		{
			Vector2 location = piece.GetComponent<Piece>().getLocation();
			JSONObject xyJSON = new JSONObject(JSONObject.Type.OBJECT);
			xyJSON.AddField("x", location.x);
			xyJSON.AddField("y", location.y);
			locationJSON.Add(xyJSON);
		}
		return locationJSON;
	}
	
	public void getMove(ArrayList enemyPieces, ArrayList enemyDestinations) 
	{
		JSONObject httpRequestJSON = new JSONObject(JSONObject.Type.OBJECT);
		httpRequestJSON.AddField("boardsize", 18);
		httpRequestJSON.AddField("pieces", pieceListToJSON(pieces));
		httpRequestJSON.AddField("destinations", arrayListToJSON(destinations));
		httpRequestJSON.AddField("enemy", pieceListToJSON(enemyPieces));
		httpRequestJSON.AddField("enemydestinations", arrayListToJSON(enemyDestinations));
		
		WWWForm postData = new WWWForm();
		postData.AddField("board", httpRequestJSON.print());
		
		sendWebRequest(postData);
	}
	
	IEnumerator sendWebRequest(WWWForm postData)
	{
		WWW webRequest = new WWW(webServiceURL, postData);
		yield return webRequest;
		if (!String.IsNullOrEmpty(webRequest.error))
			Debug.Log(webRequest.error);
		else
			Debug.Log (webRequest.text);
	}

	public ArrayList getPieces() {
		return this.pieces;
	}

	// Update is called once per frame
	void Update () {
	
	}

	bool valid(Vector2 move){
		//Second check should be boards's size
		if(move.x < 0f || move.x > 17f){
			return false;
		}
		if(move.y < 0f || move.y > 17f) {
			return false;
		}
		bool pieceInBetween = pieceExists (move);
		if(pieceInBetween == false){
			return false;
		}
		return true;
	}

	bool pieceExists(Vector2 pieceLocation){
		float x = pieceLocation.x;
		float y = pieceLocation.y;
		foreach (Transform piece in pieces) {
			piecesX.Add(piece.position.x);
			piecesY.Add(piece.position.y);
		}
		bool containsX = piecesX.Contains(x);
		if (containsX == true) {
			bool containsY = piecesY.Contains(y);
			if(containsY == true) {
				return true;
			}
		}
		return false;
	}
}
