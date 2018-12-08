﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootLeft : MonoBehaviour {


	public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsLeft; 
	public Rigidbody m_cannonball; 
	private float rechargeLeftSideTime; 
	public string m_FireButton1; 
	public bool m_FiredLeft; 

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

		/*		if (rechargeRightSideTime <= 0) 
		{ 
			m_FiredRight = false;
		} 
*/
		if (m_FiredLeft == false && Input.GetButton (m_FireButton1)) //The cannonballs haven't been fired and you press down "Ctrl" (To edit what button, either use functionality code or go into edit -> project settings -> input 
		{
			fireLeft ();
			rechargeLeftSideTime = 3; 
			m_FiredLeft = true;
		}

		/*		if (m_FiredRight == false && Input.GetButton (m_FireButton2)) //Alt
		{ // that is, if recharge is done and the above if statement is executed
			fireRight();
			rechargeRightSideTime = 3; 
			m_FiredRight = true; 
		} 
*/
		else if (m_FiredLeft == true) 
		{ //if we fired the button, begin the recharging process
			rechargeLeftSide (); 
		} 

		/*		else if (m_FiredRight == true) 
		{ 
			rechargeRightSide ();	
		} 
*/
	} 

	/// <summary>
	/// SHOOTING LEFT SIDE
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
	/// RECHARGING LEFT SIDE
	/// </summary>
	private void rechargeLeftSide() 
	{ 
		rechargeLeftSideTime -= Time.deltaTime; 
		Debug.Log ("Time until recharging is over : " + rechargeLeftSideTime); 
	}  
}
