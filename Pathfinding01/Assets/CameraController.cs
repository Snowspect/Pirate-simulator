using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject ship;

	private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        ship = GameObject.Find("PlayerShip");
		offset = transform.position - ship.transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = ship.transform.position + offset;
	}
}

// STEP ONE: Change target to be in front of ship
// STEP TWO: Try to change 

