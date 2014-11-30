using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class menuController : MonoBehaviour
{
    //Get references to the text boxes in the scene.
    //These are initialized within Unity's UI, so there's no formal initialization
    public GameObject player1Name;
    public GameObject player2Name;
    public GameObject player1URL;
    public GameObject player2URL;

    private int player1Piece = 0;
    private int player2Piece = 1;
    // Use this for initialization
    void Start()
    {
        //Play the background music for this page.
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Although we didn't put anything here, each MonoBehavior needs to have a Start and Update method.
    }

    //This function is called by the piece buttons on the UI
    public void updateP1Piece(int pieceNumber)
    {
        player1Piece = pieceNumber;
    }

    //This function is called by the piece buttons on the UI
    public void updateP2Piece(int pieceNumber)
    {
        player2Piece = pieceNumber;
    }

    //Save the info for the next scene to grab using PlayerPrefs
    public void saveInfo()
    {
        //Grab the text from each of the text fields.
        string player1NameText = player1Name.GetComponent<InputField>().text;
        string player2NameText = player2Name.GetComponent<InputField>().text;
        string player1URLText = player1URL.GetComponent<InputField>().text;
        string player2URLText = player2URL.GetComponent<InputField>().text;
        //If a box is empty, color it red so the user knows what to fill in.
        if (player1NameText == "")
            player1Name.GetComponent<Image>().color = Color.red;
        else if (player2NameText == "")
            player2Name.GetComponent<Image>().color = Color.red;
        else if (player1URLText == "")
            player1URL.GetComponent<Image>().color = Color.red;
        else if (player2URLText == "")
            player2URL.GetComponent<Image>().color = Color.red;
        //If all of the info is available, save it to the PlayerPrefs so we can access it in the next scene.
        else
        {
            PlayerPrefs.SetString("Player1Name", player1Name.GetComponent<InputField>().text);
            PlayerPrefs.SetString("Player2Name", player2Name.GetComponent<InputField>().text);
            PlayerPrefs.SetString("Player1URL", player1URL.GetComponent<InputField>().text);
            PlayerPrefs.SetString("Player2URL", player2URL.GetComponent<InputField>().text);
            PlayerPrefs.SetInt("Player1Piece", player1Piece);
            PlayerPrefs.SetInt("Player2Piece", player2Piece);
            Application.LoadLevel("gameScene");
        }
    }
}
