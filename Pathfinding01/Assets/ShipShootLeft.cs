using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootLeft : MonoBehaviour {

	public float minDelay = 1000f;
	public float maxDelay = 5000f;
	public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsLeft; 
	public Rigidbody m_cannonball; 
	private float rechargeLeftSideTime; 
	public string m_FireButton1; 
	public bool m_FiredLeft; 
	bool delayFire = false;
	bool newFloat = true;
	float delayFloat = 0.1f;

	// Use this for initialization
	void Start () {
		delayFloat = 0.1f;
		rechargeLeftSideTime = 0f;
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
		if (rechargeLeftSideTime <= 0) //recharging is done, so we can trigger the fire again
		{ 
			m_FiredLeft = false; 
		} 
		if (m_FiredLeft == false && Input.GetButton (m_FireButton1)) { //activating delay for shooting cannonballs 
			Debug.Log("registered fire button");
			delayFire = true;
			delayFloat = Random.Range (minDelay, maxDelay); 
		} 
		else if (m_FiredLeft == true && delayFire == false) //starting the recharging process
		{ 
			rechargeLeftSide (); 
		} 
		else if (delayFire == true) //starting the delay process (wait time before firing cannonball)
		{ 
			Debug.Log ("inside delay process"); 
			if (delayFloat <= 0) 
			{ 
				delayFire = false;
			} else 
			{ 
				Delay ();				
			} 
		} 
		else if (delayFloat <= 0) //the delay is done, fire the cannonballs and allow for recharging process.
		{
			Debug.Log ("inside firing process"); 
			delayFloat = 0.1f; 
			fireLeft (); 
			rechargeLeftSideTime = 3; 	
			m_FiredLeft = true; 
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
		} 
	} 

	/// <summary>
	/// RECHARGING LEFT SIDE OF SHIP
	/// </summary>
	private void rechargeLeftSide() 
	{ 
		rechargeLeftSideTime -= Time.deltaTime; 
		//Debug.Log ("Time until recharging is over : " + rechargeLeftSideTime); 
	}

	private void Delay()
	{
		delayFloat -= Time.deltaTime; 		
		Debug.Log ("DelayFloat: " + delayFloat);
	} 
}