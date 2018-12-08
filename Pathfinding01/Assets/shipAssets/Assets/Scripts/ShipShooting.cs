using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour {

	public float m_MinLaunchForce = 15f;
	public float m_MaxLaunchForce = 30f;
	public float m_MaxChargeTime = 0.75f;
	public List<Transform> canons;
	public List<Transform> canons2;
	public Transform m_FireTransform_rightSide_back;
	public Transform m_FireTransform_rightSide_mid;
	public Transform m_FireTransform_rightSide_front;
	public int m_PlayerNumber = 1;
	public Rigidbody m_cannonball;

	private string m_FireButton;
	private float m_CurrentLaunchForce;
	//private float m_ChargeSpeed;
	private bool m_Fired; 

	private void OnEnable() 
	{ 
		m_CurrentLaunchForce = m_MinLaunchForce; //so we reset the ship when it is remade 

	} 

	// Use this for initialization
	void Start () 
	{ 
		m_FireButton = "Fire" + m_PlayerNumber; 
		canons = new List<Transform> (2); 
		canons2.Add(m_FireTransform_rightSide_back); 
		canons2.Add(m_FireTransform_rightSide_front); 
		canons2.Add(m_FireTransform_rightSide_mid); 
		//m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime; 
	} 
 	
	// Update is called once per frame
	void Update () 
	{ 
		if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired) { //Gets triggered if we have max charge 
			//at max charge, not fired //currently just firing due to cannons not needing to charge 
			m_CurrentLaunchForce = m_MaxLaunchForce; 
			//Fire2(); 
			//recharge ();
		} else if (Input.GetButtonDown (m_FireButton)) { //only gets triggered if we aren't pressing the button
			//have we pressed the fire for the first time? 
			m_Fired = false; 
//			m_CurrentLaunchForce = m_MinLaunchForce; 
		} else if (Input.GetButton (m_FireButton) && !m_Fired) { 
			// holding button, not yet fired 
			// m_CurrentLaunchForce += m_CurrentLaunchForce*Time.deltaTime; 
		} 
		else if (Input.GetButtonUp (m_FireButton) && !m_Fired) //Used 
		{ 
			//we released the button, having not fired yet 
			//Fire(); 
			Fire2 (); 
		} 
	} 

	private void Fire() 
	{ 
		m_Fired = true; 
		//instanciate a canonBall instance at the position and rotation of our fireTransform
		Rigidbody canonBallInstance = Instantiate (m_cannonball, m_FireTransform_rightSide_back.position, m_FireTransform_rightSide_back.rotation) as Rigidbody;
		canonBallInstance.velocity = m_CurrentLaunchForce * m_FireTransform_rightSide_back.forward;
		m_CurrentLaunchForce = m_MinLaunchForce;
		Rigidbody canonBallInstance1 = Instantiate (m_cannonball, m_FireTransform_rightSide_mid.position, m_FireTransform_rightSide_mid.rotation) as Rigidbody;
		canonBallInstance1.velocity = m_CurrentLaunchForce * m_FireTransform_rightSide_mid.forward;
		m_CurrentLaunchForce = m_MinLaunchForce;
		Rigidbody canonBallInstance2 = Instantiate (m_cannonball, m_FireTransform_rightSide_front.position, m_FireTransform_rightSide_front.rotation) as Rigidbody;
		canonBallInstance2.velocity = m_CurrentLaunchForce * m_FireTransform_rightSide_front.forward;
		m_CurrentLaunchForce = m_MinLaunchForce;
	}
	private void Fire2()
	{
		m_Fired = true;
		foreach (var canon in canons2) {
			Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody;
			canonBallInstance.velocity = m_CurrentLaunchForce * canon.forward;
			m_CurrentLaunchForce = m_MinLaunchForce;

		}
	}

	private void recharge()
	{
		float counter = 0; 
		while (counter <= 10) 
		{ 
			counter += Time.deltaTime;
			Debug.Log (counter);
		} 
	} 
} 