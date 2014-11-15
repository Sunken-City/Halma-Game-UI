using UnityEngine;
using System.Collections;

public class ScrollController : MonoBehaviour {
	public Transform background;
	private Transform leadBackground;
	private Transform followBackground;
	private float backgroundWidth;
	private float halfBackgroundWidth;

	// Use this for initialization
	void Start () {
		backgroundWidth = (float)background.renderer.bounds.size.x;
		halfBackgroundWidth = backgroundWidth / 2.0f;
		leadBackground = Instantiate (background, new Vector3(0f, 0f, 1.0f), Quaternion.identity) as Transform;
		followBackground = Instantiate (background, new Vector3(backgroundWidth, 0f, 1.0f), Quaternion.identity) as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (leadBackground.position.x + (halfBackgroundWidth) < -7.0f)
		{
			leadBackground.position += new Vector3 (halfBackgroundWidth * 4.0f, 0f, 0f);
		}
		else if (followBackground.position.x + (halfBackgroundWidth) < -7.0f)
		{
			followBackground.position += new Vector3 (halfBackgroundWidth * 4.0f, 0f, 0f);
		}
	}
}
