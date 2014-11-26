using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Use this to pass parameters to the player entity
	public void Initialize(ArrayList startingLocations) {
		Debug.Log ("hello");
		Debug.Log (startingLocations);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
