using UnityEngine;
using System.Collections;

public class titleScreen : MonoBehaviour
{

    public
        // Use this for initialization
    void Start()
    {
        //Play the background music for this scene via the attached Audio source
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Go to the main menu if either space or enter is pressed.
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel("mainMenu");
    }
}
