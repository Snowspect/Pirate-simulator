﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootRiht : MonoBehaviour {

	public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsRight; 
	public Rigidbody m_cannonball; 
	private float rechargeRightSideTime; 
	public string m_FireButton2; 
	public bool m_FiredRight; 

	// Use this for initialization
	void Start () {
		rechargeRightSideTime = 0f; 
	}

	// Update is called once per frame
	void Update () 
	{
		Trigger ();
	}


	/// <summary>
	/// SHOOTING AND RECHARGING TRIGGER 
	/// </summary>
	private void Trigger() 
	{ 
		/*		if (rechargeLeftSideTime <= 0) 
		{ //that is, if the recharging is done, make sure we can fire again 
			m_FiredLeft = false; 
		} 
*/
		if (rechargeRightSideTime <= 0) 
		{
			m_FiredRight = false;
		}
		/*		if (m_FiredLeft == false && Input.GetButton (m_FireButton1)) //Ctlr 
		{
			fireLeft ();
			rechargeLeftSideTime = 3; 
			m_FiredLeft = true;
		}
*/
		if (m_FiredRight == false && Input.GetButton (m_FireButton2)) //Alt
		{ // that is, if recharge is done and the above if statement is executed
			fireRight();
			rechargeRightSideTime = 3; 
			m_FiredRight = true; 
		} 
		/*		else if (m_FiredLeft == true) 
		{ //if we fired the button, begin the recharging process
			rechargeLeftSide (); 
		} 
*/
		else if (m_FiredRight == true) 
		{ 
			rechargeRightSide ();	
		} 
	} 

	private void fireRight()
	{
		foreach (var canon in canonsRight) 
		{ 
			Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody; 
			canonBallInstance.velocity = m_MaxLaunchForce * canon.forward; 
		}
	}

	private void rechargeRightSide()
	{ 
		rechargeRightSideTime -= Time.deltaTime; 
		Debug.Log ("Time until right side recharging is over : " + rechargeRightSideTime); 
	}
}
