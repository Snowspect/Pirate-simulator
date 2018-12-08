using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootRight : MonoBehaviour {

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
	/// TRIGGER FUNCTIONALITY FOR SHIP SHOOTING FROM RIGHT SIDE
	/// </summary>
	private void Trigger() 
	{ 
		if (rechargeRightSideTime <= 0) 
		{
			m_FiredRight = false;
		}
		if (m_FiredRight == false && Input.GetButton (m_FireButton2)) //Alt
		{ // that is, if recharge is done and the above if statement is executed
			fireRight();
			rechargeRightSideTime = 3; 
			m_FiredRight = true; 
		} 
		else if (m_FiredRight == true) 
		{ 
			rechargeRightSide ();	
		} 
	} 

	/// <summary>
	/// SHOOTING FROM RIGHT SIDE OF SHIP
	/// </summary>
	private void fireRight()
	{
		foreach (var canon in canonsRight) 
		{ 
			Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody; 
			canonBallInstance.velocity = m_MaxLaunchForce * canon.forward; 
		}
	}
		
	/// <summary>
	/// RECHARGING RIGHT SIDE OF SHIP
	/// </summary>
	private void rechargeRightSide()
	{ 
		rechargeRightSideTime -= Time.deltaTime; 
		Debug.Log ("Time until right side recharging is over : " + rechargeRightSideTime); 
	}
}