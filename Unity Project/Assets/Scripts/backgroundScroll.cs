using UnityEngine;
using System.Collections;

public class backgroundScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Transform> ().position -= new Vector3 (0.005f, 0f, 0f);
	}
}
