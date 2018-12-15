using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootRight : MonoBehaviour {

	public float minDelay = 1f; 
	public float maxDelay = 5f; 
	public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsRight; 
	public Rigidbody m_cannonball; 

	public float initialRechargeTime = 3f; 
	public float initialFireDelay = 0f; 

	private float localRecharge;
	private float localDelay;

	bool delayRunning = false; 
	bool allowedToFire = false; 
	bool allowTrigger = false; 
	bool allowedToFire2 = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if (allowTrigger == true) 
		{
			Trigger ();
		}
	}


	void OnTriggerStay(Collider other)
	{
		if (other.name.Equals ("AiShootTriggerRight")) 
		{
			allowTrigger = true;
		}
	}

	void OnTriggerExit(Collider other)
	{ 
		if (other.name.Equals ("AiShootTriggerRight")) 
		{ 
			allowTrigger = false;
			allowedToFire2 = true;
			localRecharge = 01f;
			delayRunning = false;
			allowedToFire = false;

		} 
	} 

	/// <summary>
	/// TRIGGER FUNCTIONALITY FOR SHIP SHOOTING FROM RIGHT SIDE
	/// </summary>
	private void Trigger() 
	{ 
		//If recharge is below 0 
		if (localRecharge <= 0 && allowedToFire2 == true) //recharging is done, so we can trigger the fire again 
		{ 
			allowedToFire = true; 
		} 
		// if allowed to fire and you press the fire button 
		if (allowedToFire == true && allowedToFire2 == true) { //activating delay for shooting cannonballs 
			delayRunning = true; 
			initialFireDelay = Random.Range (minDelay, maxDelay); 
			allowedToFire2 = false; 
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
			fireRight (); 
			localRecharge = initialRechargeTime; 
			allowedToFire = false; 
			allowedToFire2 = true;
		} 
	} 

	private void fireRight() 
	{ 
		foreach (var canon in canonsRight) 
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
		//Debug.Log("Time until right side recharging is over : " + initialRechargeTime);
	} 

	private void subtractFireDelay() 
	{ 
		initialFireDelay -= Time.deltaTime; 
		//Debug.Log("Time until right side recharging is over : " + initialRechargeTime);
	} 
} 