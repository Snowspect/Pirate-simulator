using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour {

	public float m_MinLaunchForce = 15f;
	public float m_MaxLaunchForce = 30f;
	public float m_MaxChargeTime = 0.75f;
	public Transform m_FireTransform;
	public int m_PlayerNumber = 1;
	public Rigidbody m_cannonball;

	private string m_FireButton;
	private float m_CurrentLaunchForce;
	private float m_ChargeSpeed;
	private bool m_Fired;

	private void OnEnable()
	{
		m_CurrentLaunchForce = m_MinLaunchForce; //so we reset the ship when it is remade
	}

	// Use this for initialization
	void Start () 
	{
		m_FireButton = "Fire" + m_PlayerNumber;

		m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired) {
			//at max charge, not fired
			m_CurrentLaunchForce = m_MaxLaunchForce;
			Fire();
		} else if (Input.GetButtonDown (m_FireButton)) {
			//have we pressed the fire for the first time?
			m_Fired = false; 
			m_CurrentLaunchForce = m_MinLaunchForce;
		
		} else if (Input.GetButton (m_FireButton) && !m_Fired) {
			// holding button, not yet fired
			m_CurrentLaunchForce += m_CurrentLaunchForce*Time.deltaTime;

		} else if (Input.GetButtonUp (m_FireButton) && !m_Fired) 
		{
			//we released the button, having not fired yet
			Fire();
		}
	}

	private void Fire()
	{
		m_Fired = true;
		//instanciate a canonBall instance at the position and rotation of our fireTransform
		Rigidbody canonBallInstance = Instantiate (m_cannonball, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;


		canonBallInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
		m_CurrentLaunchForce = m_MinLaunchForce;
	}
}
