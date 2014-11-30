using UnityEngine;
using System.Collections;

public class backgroundScroll : MonoBehaviour
{
    //This can be changed in the inspector, but this is the default value.
    public float scrollSpeed = 0.005f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Slowly move the background across the screen.
        this.GetComponent<Transform>().position -= new Vector3(scrollSpeed, 0f, 0f);
    }
}
