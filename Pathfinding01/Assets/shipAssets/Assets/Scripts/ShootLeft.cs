using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLeft : MonoBehaviour {

	public float minDelay = 0.5f;
	public float maxDelay = 1.0f;
	public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsLeft; 
	public Rigidbody m_cannonball;
    private float initialRechargeTime;
    private float initialFireDelay;
    public string m_FireButton1;
    public bool allowedToFire;
	bool delayRunning = false;
	bool newFloat = true;
	bool fire = false;
     
	// Use this for initialization
	void Start () {
        initialRechargeTime = 0f;
        initialFireDelay = Random.Range(minDelay, maxDelay);
    }
	
	// Update is called once per frame
	void Update () { 
		Trigger (); 
	}

    //Trigger is called constantly
    private void Trigger()
    {
		//If recharge is below 0
		if (initialRechargeTime <= 0) //recharging is done, so we can trigger the fire again 
		{ 
			allowedToFire = true; 
		} 
		// if allowed to fire and you press the fire button
		if (allowedToFire == true && Input.GetButton (m_FireButton1)) { //activating delay for shooting cannonballs 
			delayRunning = true;
			initialFireDelay = Random.Range (minDelay, maxDelay); 
		} 
		// if  we have fired and are recharing and the delay before shooting is not running
		else if (allowedToFire == false && delayRunning == false) //starting the recharging process
		{ 
			subtractRechargeTime(); 
		} 
		// if we tried to fire and we have to wait a tiny bit before firing 
		else if (delayRunning == true) //starting the delay process (wait time before firing cannonball) 
		{ 
			Debug.Log ("inside delay process"); 
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
			Debug.Log ("inside firing process"); 
			initialFireDelay = 0.1f; 
			fireLeft (); 
			initialRechargeTime = 3; 
			allowedToFire = false; 
		} 


		/*
        //subtracting a small amount from rechargeRightSideTime
        subtractRechargeTime();

        //subtracting a small amount from initialFireDelay
        subtractDelayTime();
		             
        //Check if rechargeRightSideTime is below 0 and if the fire button has been pressed
        if (initialRechargeTime <= 0 && Input.GetButton(m_FireButton1)) //Alt
        {
            fireLeft();
            initialRechargeTime = 3;  //resetting rechargeRightSide time
            initialFireDelay = Random.Range(minDelay, maxDelay);
        }*/
    }

    /// <summary>
    /// SHOOTING LEFT SIDE
    /// </summary>
    private void fireLeft()
	{
		/*
		if (initialFireDelay <= 0) 
		{
		*/
			foreach (var canon in canonsLeft) 
			{ 
				Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody; 
				canonBallInstance.velocity = m_MaxLaunchForce * canon.forward; 
			} 
	} 


    private void subtractRechargeTime() 
    { 
        initialRechargeTime -= Time.deltaTime; 
        //Debug.Log("Time until right side recharging is over : " + initialRechargeTime);
    } 

    private void subtractFireDelay() 
    { 
        initialFireDelay -= Time.deltaTime; 
       //Debug.Log("Time until right side recharging is over : " + initialRechargeTime);
    } 
} 