using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeLeft : MonoBehaviour {

	public float minDelay = 0.1f;
	public float maxDelay = 0.5f;
	public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsLeft; 
	public Rigidbody m_cannonball; 
	private float rechargeLeftSideTime; 
	public string m_FireButton1; 
	public bool m_FiredLeft; 
	bool delayFire = false;
	bool newFloat = true;
	float allowFire = 0f;
	bool fire = false;

	// Use this for initialization
	void Start () {
		rechargeLeftSideTime = 0f;
	}
	
	// Update is called once per frame
	void Update () { 
		Trigger (); 
	} 

	//TRIGGERING LEFT SIDE
	private void Trigger() 
	{ 
		if (rechargeLeftSideTime <= 0) 
		{ //that is, if the recharging is done, make sure we can fire again 
			m_FiredLeft = false; 
		} 
			
		if (m_FiredLeft == false && Input.GetButton (m_FireButton1)) //The cannonballs haven't been fired and you press down "Ctrl" (To edit what button, either use functionality code or go into edit -> project settings -> input 
		{
			fireLeft ();
			rechargeLeftSideTime = 3; 
			m_FiredLeft = true;
		}
		else if (m_FiredLeft == true) 
		{ //if we fired the button, begin the recharging process
			rechargeLeftSide (); 
		} 
	} 

	/// <summary>
	/// SHOOTING LEFT SIDE
	/// </summary>
	private void fireLeft()
	{
		delayFire = true;
	
		Delay (minDelay, maxDelay);

		if (delayFire == false) 
		{
			foreach (var canon in canonsLeft) 
			{ 
				Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody; 
				canonBallInstance.velocity = m_MaxLaunchForce * canon.forward; 
			}
		}
	} 

	/// <summary>
	/// RECHARGING LEFT SIDE
	/// </summary>
	private void rechargeLeftSide() 
	{ 
		rechargeLeftSideTime -= Time.deltaTime;
		Debug.Log ("Time until recharging is over : " + rechargeLeftSideTime); 
	}  


	private void Delay(float minDelay, float maxDelay)
	{
		if (delayFire == true) 
		{
			if (newFloat == true) {
				allowFire = Random.Range (minDelay, maxDelay);
				newFloat = false;
			} 
			if (allowFire > 0) 
			{ 
				allowFire -= Time.deltaTime;
			} 
			if (allowFire <= 0) 
			{ 
				delayFire = false;
				newFloat = true;
			} 
		} 
	}

} 