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
    bool startDelayTimer = false;

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
		Debug.Log ("Time until right side recharging is over : " + initialRechargeTime); 
	}

    private void subtractFireDelay()
    {
        initialFireDelay -= Time.deltaTime;
        Debug.Log("Time until right side delay is over : " + initialFireDelay);
    }
}
