using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.IO;

public class Player : MonoBehaviour
{

    public Transform Piece;

    private ArrayList pieces;
    private ArrayList destinations;
    private string webServiceURL = "http://lyle.smu.edu/~tbgeorge/cse4345/a1/getMove.php";

    // Use this for initialization
    void Start()
    {

    }

    // Use this to pass parameters to the player entity
    public void Initialize(int pieceStyleNumber, ArrayList startingLocations, ArrayList destinations, Vector3 originTileLocation, float tileLength)
    {
        pieces = new ArrayList();
        this.destinations = destinations;

        //Instantiate each of the pieces and place them into an arrayList.
        foreach (Vector2 location in startingLocations)
        {
            Transform piece = Instantiate(Piece, Vector3.zero, Quaternion.identity) as Transform;
            piece.GetComponent<Piece>().Initialize(pieceStyleNumber, location, originTileLocation, tileLength);
            pieces.Add(piece);
        }
    }

    //Setter for the URL
    public void setURL(string URL)
    {
        webServiceURL = URL;
    }

    //Helper method that takes an arrayList and converts it to JSON
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

    //Helper method that takes an arrayList of pieces and converts it to JSON
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

    //Given the enemy's position and destinations, determine which piece to move and where.
    public void getMove(ArrayList enemyPieces, ArrayList enemyDestinations)
    {
        //Encode the state of the game in JSON.
        JSONObject json = new JSONObject(JSONObject.Type.OBJECT);
        json.AddField("boardSize", 18);
        json.AddField("pieces", pieceListToJSON(pieces));
        json.AddField("destinations", arrayListToJSON(destinations));
        json.AddField("enemy", pieceListToJSON(enemyPieces));
        json.AddField("enemydestinations", arrayListToJSON(enemyDestinations));

        //Send the web request and get back the response.
        string responseText = WebRequestinJson(json.print());

        Debug.Log("Response is:");
        Debug.Log(responseText);

        //With the move information available., make the move.
        makeMove(responseText);
    }

    //Take a JSONResponse string and parse the move information from it.
    void makeMove(string JSONResponse)
    {
        JSONObject response = new JSONObject(JSONResponse);
        JSONObject from = response["from"];
        JSONObject to = response["to"];
        //Parse the "to" field from the response, and create a boardLocation vector from it.
        Vector2 pieceToMove = new Vector2(Single.Parse(from["x"].ToString()), Single.Parse(from["y"].ToString()));
        Transform piece = findPieceOnBoard(pieceToMove);
        //If we were able to find a piece
        if (piece != null)
        {
            if (to.IsArray)
            {
                //Parse each of the items in the list.
                foreach (JSONObject jump in to.list)
                {
                    Vector2 placeToMove = new Vector2(Single.Parse(jump["x"].ToString()), Single.Parse(jump["y"].ToString()));
                    //Make the move given the actual place to move.
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

    //Getter method for the pieces arrayList.
    public ArrayList getPieces()
    {
        return this.pieces;
    }

	//Getter method for the pieces arrayList.
	public ArrayList getDestinations()
	{
		return this.destinations;
	}

    // Update is called once per frame
    void Update()
    {

    }

    bool valid(Vector2 move)
    {
        //Second check should be boards's size
        if (move.x < 0f || move.x > 17f)
        {
            return false;
        }
        if (move.y < 0f || move.y > 17f)
        {
            return false;
        }
        bool pieceInBetween = pieceExists(move);
        if (pieceInBetween == false)
        {
            return false;
        }
        return true;
    }

    //Returns a piece on the board given any board Location. Returns null if no piece was found.
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

    //Returns a boolean that represents whether or not a piece exists on the board.
    bool pieceExists(Vector2 pieceLocation)
    {
        foreach (Transform piece in pieces)
        {
            Vector2 currentLocation = piece.GetComponent<Piece>().getLocation();
            if (currentLocation == pieceLocation)
                return true;
        }
        return false;
    }

	public bool allPiecesInDestinations(ArrayList pieces, ArrayList Destinations) 
	{
		int size = pieces.Count;
		ArrayList piecesLocations = new ArrayList ();
		foreach(Transform piece in pieces){
			piecesLocations.Add(piece.GetComponent<Piece>().getLocation());
		}
		int reachedDestination = 0;
		bool pieceInDestination;
		foreach(Vector2 location in destinations) {
			pieceInDestination =  piecesLocations.Contains(location);
			if(pieceInDestination == true){
				reachedDestination++;
			}
		}
		if (reachedDestination == size) {
			return true;
		} else {
			return false;
		}

	}

}
