using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}

// STEP ONE: Change target to be in front of ship
// STEP TWO: Try to change 

