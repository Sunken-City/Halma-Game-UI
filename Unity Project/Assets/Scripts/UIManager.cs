using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject player1Name;
    public GameObject player2Name;
    // Use this for initialization
    void Start()
    {
        //Fill in the player's names using the PlayerPrefs we get from the Main Menu.
        player1Name.GetComponent<Text>().text = PlayerPrefs.GetString("Player1Name");
        player2Name.GetComponent<Text>().text = PlayerPrefs.GetString("Player2Name");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
