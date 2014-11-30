using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.IO;

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
            xyJSON.AddField("team", 0);
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
            xyJSON.AddField("team", 0);
			locationJSON.Add(xyJSON);
		}
		return locationJSON;
	}
	
	public void getMove(ArrayList enemyPieces, ArrayList enemyDestinations) 
	{
		JSONObject json = new JSONObject(JSONObject.Type.OBJECT);
		json.AddField("boardSize", 18);
		json.AddField("pieces", pieceListToJSON(pieces));
		json.AddField("destinations", arrayListToJSON(destinations));
		json.AddField("enemy", pieceListToJSON(enemyPieces));
		json.AddField("enemydestinations", arrayListToJSON(enemyDestinations));

		Debug.Log("JSON is:");
        Debug.Log(json.print());

        //This is the part that has problems and gets us the 500
		string responseText = WebRequestinJson(json.print());
		
		Debug.Log("Response is:");
		Debug.Log(responseText);
    }
	
    void makeMove(string JSONResponse)
    {
        JSONObject response = new JSONObject(JSONResponse);
        JSONObject from = response["from"];
        JSONObject to = response["to"];
        Vector2 pieceToMove = new Vector2(Single.Parse(from["x"].ToString()), Single.Parse(from["y"].ToString()));
    }

	//Code taken from this SO question: http://stackoverflow.com/questions/4982765/json-call-with-c-sharp
	public string WebRequestinJson(string postData)
	{
		Debug.Log("URL is:");
		Debug.Log(webServiceURL);
		string responseJSON = string.Empty;
		
		StreamWriter requestWriter;
		
		var webRequest = System.Net.WebRequest.Create(webServiceURL) as HttpWebRequest;
		if (webRequest != null)
		{
			webRequest.Method = "POST";
			//webRequest.ServicePoint.Expect100Continue = false;
			webRequest.Timeout = 20000;
			
			webRequest.ContentType = "application/json";
			//POST the data.
			using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
			{
				requestWriter.Write(postData);
			}
		}
		
		HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
		Stream resStream = resp.GetResponseStream();
		StreamReader reader = new StreamReader(resStream);
		responseJSON = reader.ReadToEnd();
		
		return responseJSON;
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
