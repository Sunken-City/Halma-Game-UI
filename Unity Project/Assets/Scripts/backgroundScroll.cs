using UnityEngine;
using System.Collections;

public class backgroundScroll : MonoBehaviour {
	
	public float scrollSpeed = 0.005f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Transform> ().position -= new Vector3 (scrollSpeed, 0f, 0f);
		//if (this.transform.position.x - halfLength < Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0)).x)
						//this.GetComponent<Transform> ().position = new Vector3 (3f, 0f, 0f);

	}
}
