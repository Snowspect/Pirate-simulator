using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootLeft : MonoBehaviour {


	public float minDelay = 1f; 
	public float maxDelay = 5f; 
	public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsLeft; 
	public Rigidbody m_cannonball; 

	public float initialRechargeTime = 0f; 
	public float initialFireDelay = 0f; 
	public float localRecharge;

	public string m_FireButton1; 
	bool delayRunning = false; 
	bool allowedToFire = false; 
	bool allowDelay = true;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () 
	{ 
		Trigger (); 
	} 
		
	/// <summary>
	/// TRIGGER FUNCTIONALITY FOR SHIP SHOOTING FROM LEFT SIDE
	/// </summary>
	private void Trigger() 
	{ 
		//If recharge is below 0
		if (localRecharge <= 0) //recharging is done, so we can trigger the fire again 
		{ 
			allowedToFire = true; 
		} 
		// if allowed to fire and you press the fire button
		if (allowedToFire == true && Input.GetButton (m_FireButton1) && allowDelay == true) { //activating delay for shooting cannonballs 
			delayRunning = true;
			initialFireDelay = Random.Range (minDelay, maxDelay);
			allowDelay = false;
		} 
		// if  we have fired and are recharing and the delay before shooting is not running
		else if (allowedToFire == false && delayRunning == false) //starting the recharging process
		{ 
			subtractRechargeTime(); 
		} 
		// if we tried to fire and we have to wait a tiny bit before firing 
		else if (delayRunning == true) //starting the delay process (wait time before firing cannonball) 
		{ 
			//Debug.Log ("inside delay process"); 
			if (initialFireDelay <= 0)  //done so we don't trigger the else if this belongs to again.
			{ 
				delayRunning = false; 
			} 
			else 
			{ 
				subtractFireDelay(); 
			} 
		} 
		else if (initialFireDelay <= 0) //the delay is done, fire the cannonballs and allow for recharging process. 
		{ 
			//Debug.Log ("inside firing process"); 
			initialFireDelay = 0.1f; //must be set in order not to access this loop indefinietly 
			fireLeft (); 
			localRecharge = initialRechargeTime; 
			allowedToFire = false; 
			allowDelay = true;
		} 
	} 

	/// <summary> 
	/// SHOOTING FROM LEFT SIDE OF SHIP
	/// </summary> 
	private void fireLeft() 
	{ 
		foreach (var canon in canonsLeft) 
		{ 
			Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody; 
			canonBallInstance.velocity = m_MaxLaunchForce * canon.forward; 
			canonBallInstance.name = "cannonball";
		} 
	} 

	/// <summary>
	/// RECHARGING LEFT SIDE OF SHIP
	/// </summary>
	private void subtractRechargeTime() 
	{ 
		localRecharge -= Time.deltaTime; 
		//Debug.Log("Time until left side recharging is over : " + initialRechargeTime);
	} 

	private void subtractFireDelay() 
	{ 
		initialFireDelay -= Time.deltaTime; 
		//Debug.Log("Time until delay is over : " + initialFireDelay);
	} 
} 