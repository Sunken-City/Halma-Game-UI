using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.IO;

public class Player : MonoBehaviour {

	public Transform Piece;
	
	private ArrayList pieces;
	private ArrayList destinations;
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

		string responseText = WebRequestinJson(json.print());
		
		Debug.Log("Response is:");
		Debug.Log(responseText);
        makeMove(responseText);
    }
	
    void makeMove(string JSONResponse)
    {
        JSONObject response = new JSONObject(JSONResponse);
        JSONObject from = response["from"];
        JSONObject to = response["to"];
        Vector2 pieceToMove = new Vector2(Single.Parse(from["x"].ToString()), Single.Parse(from["y"].ToString()));
        Transform piece = findPieceOnBoard(pieceToMove);
        if (piece != null)
        {
            if (to.IsArray)
            {
                foreach (JSONObject jump in to.list)
                {
                    Vector2 placeToMove = new Vector2(Single.Parse(jump["x"].ToString()), Single.Parse(jump["y"].ToString()));
                    piece.GetComponent<Piece>().move(placeToMove);
                }
            }
            else
            {
                Vector2 placeToMove = new Vector2(Single.Parse(to["x"].ToString()), Single.Parse(to["y"].ToString()));
                piece.GetComponent<Piece>().move(placeToMove);
            }
        }
        else //The piece didn't exist, invalid move. Do some error handling here
        {
            return;
        }
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

    Transform findPieceOnBoard(Vector2 pieceLocation)
    {
        foreach (Transform piece in pieces)
        {
            Vector2 currentLocation = piece.GetComponent<Piece>().getLocation();
            if (currentLocation == pieceLocation)
                return piece;
        }
        return null;
    }

	bool pieceExists(Vector2 pieceLocation){
        foreach (Transform piece in pieces)
        {
            Vector2 currentLocation = piece.GetComponent<Piece>().getLocation();
            if (currentLocation == pieceLocation)
                return true;
        }
        return false;
	}
}
