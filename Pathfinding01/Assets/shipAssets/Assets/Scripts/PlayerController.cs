using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 


public class PlayerController : MonoBehaviour { 

	public static float speed; 
	public static float mass; 
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


	// Use this for initialization
	void Start () 
	{ 
		setShipStandard (); 
	} 
	
	// Update is called once per frame
	void Update () 
	{ 
		setShipStandard (); 
		moveCharacter (); //implementation of movement
		RotateCharacter (); //implementation of rotation

	} 

	/// <summary>
	/// Moves the character.
	/// </summary>
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

			// up arrow key isn't pressed
			else if (!Input.GetKey (KeyCode.UpArrow)) {
			if (speed > minimumSpeed) {
				speed = speed * 0.99f;
				//the below commented out code is an attempt at making mass and the slowfactor play a role, but it isn't properly converted to 0.99f. so not ready yet.
				//the massremovalfactor defines the number we have to remove from the decrease factor as these two play a crucial rule together
				//float massremovalfactor = mass/100;
				//slowfactor = mass - massremovalfactor;
			} 
		}
		//so the ship doesn't go into a n^e factor indefinietly.
		if (speed < minimumSpeedTrigger) 
			{
				speed = minimumSpeed;
			}

		//moves the ship in relation to the world, taking the ships internal coordinate system into consideration (found through experimentation)
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);

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
			float rotationfactor = turnfactor;

			transform.Rotate (transform.up, (-1*rotationfactor) * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.RightArrow) && speed != minimumSpeed && speed >= minimumRotationSpeed)
		{
			float rotationfactor = turnfactor;

			transform.Rotate (transform.up, rotationfactor * Time.deltaTime, Space.World);
		}
	}


	/// <summary>
	/// GETS THE STANDARD OF THE SHIP AND SETS ITS STATS ACCORDINGLY TO ITS TAG/TYPE
	/// </summary>
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
			//RectTransform t = this.GetComponent<RectTransform> (); //not sure why this is here

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
			//ShipShooting.canons.Capacity = 4;
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

/*		#region til	ts the ship akwardly, could possibly be used	
 		lookDirection += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
		transform.rotation = Quaternion.lerpUnclamped(transform.rotation, targetRotation, speed*Time.deltaTime);
		#endregion
*/  