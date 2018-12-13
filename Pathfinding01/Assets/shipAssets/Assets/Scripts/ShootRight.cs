using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRight : MonoBehaviour {

    public float minDelay = 2.0f;
    public float maxDelay = 2.0f;
    public float m_MaxLaunchForce = 30f; 
	public List<Transform> canonsRight; 
	public Rigidbody m_cannonball; 
	private float initialRechargeTime; 
    private float initialFireDelay;
	public string m_FireButton2; 
	public bool allowedToFire;
    bool newFloat = true;
    float allowFire = 0f;
    bool fire = false;
    bool buttonPressed = false;
    bool delayRunning = false;

    // Use this for initialization
    void Start () {
		initialRechargeTime = 0f;
        initialFireDelay = Random.Range(minDelay, maxDelay);
    }
	
	// Update is called once per frame
	void Update () {
		Trigger ();
	}


    /// <summary>
    /// SHOOTING AND RECHARGING TRIGGER 
    /// </summary>
    //Trigger is called constantly
    private void Trigger()
    {
		//If recharge is below 0
		if (initialRechargeTime <= 0) //recharging is done, so we can trigger the fire again 
		{ 
			allowedToFire = true; 
		} 
		// if allowed to fire and you press the fire button
		if (allowedToFire == true && Input.GetButton (m_FireButton2)) { //activating delay for shooting cannonballs 
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
			fireRight (); 
			initialRechargeTime = 3; 
			allowedToFire = false; 
		} 


		/*
        //subtracting a small amount from initialFireDelay
        subtractRechargeTime();

        


        //Check if rechargeRightSideTime is below 0 and if the fire button has been pressed
        if (initialRechargeTime <= 0 && Input.GetButton(m_FireButton2)) //Alt
        {
            buttonPressed = true;
            startDelayTimer = true;
        }

        if (startDelayTimer == true)
        {
            //subtracting a small amount from rechargeRightSideTime
            subtractFireDelay();
        }

        if (initialFireDelay < 0 && buttonPressed == true)
        {
            buttonPressed = false;
            initialFireDelay = Random.Range(minDelay, maxDelay);
            initialRechargeTime = 3;  //resetting rechargeRightSide time
            fireRight();
        }
		*/
        
    }

    private void fireRight()
	{
		foreach (var canon in canonsRight) 
		{ 
			Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody; 
			canonBallInstance.velocity = m_MaxLaunchForce * canon.forward; 
		}
	}

	private void subtractRechargeTime()
	{ 
		initialRechargeTime -= Time.deltaTime; 
		//Debug.Log ("Time until right side recharging is over : " + initialRechargeTime); 
	}

    private void subtractFireDelay()
    {
        initialFireDelay -= Time.deltaTime;
        //Debug.Log("Time until right side delay is over : " + initialFireDelay);
    }
}
