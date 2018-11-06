using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed;
	public float mass;
	public float accelerationfactor;
	public float maximumSpeed;
	public float minimumSpeed;
	public float minimumSpeedTrigger;
	public float slowfactor;
	public float turnfactor;
	public float speedbuff;
	public float minimumRotationSpeed;
	float moveHorizontal;
	float moveVertical;
	private Vector3 lookDirection = Vector3.zero;
	Rigidbody ship;


	// Use this for initialization
	void Start () 
	{
		setShipStandard ();

		ship = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		setShipStandard ();
		moveCharacter (); //implementation of movement
		RotateCharacter (); //implementation of rotation

	}

	void moveCharacter()
	{
		//accelerate the ship as a factor of its acceleration factor/ mass.
		//the acceleration factor can present for example the ships flags to make it easier to move forward.
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (speed <= maximumSpeed) {
				float speedfactor = accelerationfactor / mass;
				speed = speed + speedfactor;
			}
		}
		// Down arrow impl.
		/* else if (Input.GetKey(KeyCode.DownArrow)) {
				if (speed > 0f) {
					speed = speed - 0.2f;
				} } */	

		//neither up or down is pressed
			else if (!Input.GetKey (KeyCode.UpArrow) /*&& !Input.GetKey (KeyCode.DownArrow)*/) {
			if (speed > minimumSpeed) {
				speed = speed * 0.99f;
				//the below commented out code is an attempt at making mass and the slowfactor play a role, but it isn't properly converted to 0.99f. so not ready yet.
				//the massremovalfactor defines the number we have to remove from the decrease factor as these two play a crucial rule together
				//float massremovalfactor = mass/100;
				//slowfactor = mass - massremovalfactor;
				/*Debug.Log ("slow factor : " + slowfactor);
				Debug.Log ("mass removal : " + massremovalfactor);
				Debug.Log("slow factor times 0.1 : " + slowfactor * 0.1f);


				float decreasefactor = slowfactor - speedbuff;
				*/
				//float decreasefactor = slowfactor / mass;
			} 
		}
		//so the ship doesn't go into a n^e factor indefinietly.
		if (speed < minimumSpeedTrigger) 
			{
				speed = minimumSpeed;
			}
		//moves the ship in relation to the world, taking the ships internal coordinate system into consideration (found through experimentation)
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World); //the coordinate system of the ship has switched horizontal with right and up so we do the same.

/*		lookDirection += new Vector3(0f,0f,0f);
		Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
		transform.rotation = Quaternion.LerpUnclamped(transform.rotation, targetRotation, speed*Time.deltaTime);
		*/
	}

	//allows the ship to curve in left or right direction
	void RotateCharacter()
	{
		/*
		 * TODO
		 * procentage factor should be based on buffs.
		 * rotation needs to be based on speed!. ALSO, implement speedup in relation to mass in the above code. //display backwards.
		 */

		//curves in direction as long as speed isn't zero.
		if(Input.GetKey(KeyCode.LeftArrow) && speed != minimumSpeed && speed >= minimumRotationSpeed) 
		{
			//rotation factor dictactes how sharp the curve is.
			//float rotationfactor = (turnfactor - (speed));
			float rotationfactor = turnfactor;
			//-1*rotation factor is to make it turn left, if we remove it, it turns right.
			//space.World as we want to move it accordingly to the coordinate system in the world.

			transform.Rotate (transform.up, (-1*rotationfactor) * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.RightArrow) && speed != minimumSpeed && speed >= minimumRotationSpeed)
		{
//			float rotationfactor = (turnfactor - (speed));
//			float rotationfactor = (turnfactor / speed);
//			float rotationfactor = turnfactor * speed;
			float rotationfactor = turnfactor;

			transform.Rotate (transform.up, rotationfactor * Time.deltaTime, Space.World);
		}
	}




	void setShipStandard()
	{
		if (this.tag.Equals("light"))
		{
			mass = 180f;
			accelerationfactor = 1000f / mass; 
			maximumSpeed = (1000f / mass); // 6,6
			minimumSpeed = 0f;
			//			minimumSpeedTrigger = 0.01f;
			//			minimumRotationSpeed = 0.01f;
			//slowfactor = 
			//			speedbuff = 0f;
			turnfactor = 7000f / mass;
			RectTransform t = this.GetComponent<RectTransform> ();

		}
		if (this.tag.Equals("medium"))
		{
			mass = 250f;
			accelerationfactor = 1000f / mass; 
			maximumSpeed = (1000f / mass); // 6,6
			minimumSpeed = 0f;
			//			minimumSpeedTrigger = 0.01f;
			//			minimumRotationSpeed = 0.01f;
			//slowfactor = 
			//			speedbuff = 0f;
			turnfactor = 7000f / mass;

		}
		if (this.tag.Equals("heavy"))
		{
			mass = 300f;
			accelerationfactor = 1000f / mass; 
			maximumSpeed = (1000f / mass); // 6,6
			minimumSpeed = 0f;
			//			minimumSpeedTrigger = 0.01f;
			//			minimumRotationSpeed = 0.01f;
			//slowfactor = 
			//			speedbuff = 0f;
			turnfactor = 7000f / mass;
		}
	}
}



//Not used, but could be helpful for other things.

/*
			//An attempt on "gradual speed increase"
				/*if (speed < 2f)
					speed = speed + 0.01f;
					//speed = speed + 0.05f;
				if (speed < 5f && speed > 2f)
					speed = speed + 0.07f;
					speed = speed + 0.2f;
					speed = speed + speed + 0.2f; //can be used for burst skill
				*/
/*
			//speed = speed - 0.01f; //slows down linearly
				/*if(speed >= 2f) 
					speed = speed - 0.02f*speed;
				if (speed < 2 && speed > 0f)
					speed = speed - 0.04f * speed;
				}*/


/*		#region til	ts the ship akwardly, could possibly be used	
 		lookDirection += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
		transform.rotation = Quaternion.lerpUnclamped(transform.rotation, targetRotation, speed*Time.deltaTime);
		#endregion*/