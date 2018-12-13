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
        }

    }

    /// <summary>
    /// SHOOTING LEFT SIDE
    /// </summary>
    private void fireLeft()
	{
		if (initialFireDelay <= 0) 
		{
			foreach (var canon in canonsLeft) 
			{ 
				Rigidbody canonBallInstance = Instantiate (m_cannonball, canon.position, canon.rotation) as Rigidbody; 
				canonBallInstance.velocity = m_MaxLaunchForce * canon.forward; 
			}
		}
	}


    private void subtractRechargeTime()
    {
        initialRechargeTime -= Time.deltaTime;
        Debug.Log("Time until right side recharging is over : " + initialRechargeTime);
    }

    private void subtractDelayTime()
    {
        initialFireDelay -= Time.deltaTime;
        Debug.Log("Time until right side recharging is over : " + initialRechargeTime);
    }

} 