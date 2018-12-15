using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject ship;

	private Vector3 offset = new Vector3(70,120,70), shipPosition;

    float distance;
    Vector3 playerPrevPos, playerMoveDir;

	// Use this for initialization
	void Start ()
    {
        ship = GameObject.Find("PlayerShip");
        shipPosition = ship.transform.position;

       //transform.SetPositionAndRotation((offset), transform.rotation);

       transform.SetPositionAndRotation((shipPosition), transform.rotation);

        //transform.SetPositionAndRotation(shipPosition,ship.transform.rotation);
        //offset = transform.position - ship.transform.position;
        offset += transform.position - ship.transform.position;
        //transform.position = ship.transform.position + offset;
    }

    // Update is called once per frame
    //void Update () {
    //	transform.position = ship.transform.position + offset;
    //}

    private void LateUpdate()
    {

        transform.LookAt(ship.transform.position);
        transform.position = ship.transform.position + offset;


    }
}

// STEP ONE: Change target to be in front of ship
// STEP TWO: Try to change 

