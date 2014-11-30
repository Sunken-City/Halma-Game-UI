using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    //Since Unity needs to take a ratio of color for each of the RGB values, 
    //and the RGB values you generally get are out of 255, this makes
    //The code more readable if you want to derive what color we're actually using.
    private static Color[] colors = {   new Color(163f / 255f, 73f / 255f, 164f / 255f),
                                        new Color(237f / 255f, 28f / 255f, 36f / 255f) ,
                                        new Color(181f / 255f, 230f / 255f, 29f / 255f) ,
                                        new Color(255f / 255f, 242f / 255f, 0f / 255f) ,
                                        new Color(255f / 255f, 127f / 255f, 39f / 255f) ,
                                        new Color(0f / 255f, 162f / 255f, 232f / 255f) };
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Simple function to change the color of the tile to the piece's color.
    public void changeColor(int styleNumber)
    {
        this.GetComponent<SpriteRenderer>().color = colors[styleNumber];
    }
}
