using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 0;
	private int n = 0;
	public float mass;
	public float accelerationfactor;
	public float speedLimit;
	public float slowfactor;
	public float turnfactor;
	bool moving;
	float moveHorizontal;
	float moveVertical;
	private Vector3 lookDirection = Vector3.zero;
	Rigidbody ship;
	// Use this for initialization
	void Start () 
	{
		ship = GetComponent<Rigidbody> ();
		moving = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		#region sets top speed and lowest speed

		//Currently just stops the moment the fingers are taken off the up key or down key
		//Adds/removes speed everytime the script updates
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
		{
			if(speed <= 2f)
			{
				speed = speed + 0.2f;
			}
		}
		else 
		{
			if(speed > 0f)
			{
				speed = speed - 0.2f;
			}
		}
		#endregion

		#region movement
		moveHorizontal = Input.GetAxis ("Horizontal")*Time.deltaTime*speed;
		//moveVertical = Input.GetAxis ("Vertical")*Time.deltaTime*speed;

	
		//moveHorizontal = moveHorizontal * (-1); // reverts movement based on input (due to bug, goes left when pressing right, and vise versa)


/*		Vector3 curve = new Vector3(moveVertical, 0.0f, moveHorizontal);
		Vector3 changeCurve = new Vector3 (moveHorizontal,0.0f,moveVertical);
		Vector3 newCurve = changeCurve + curve;


		//Vector3 movement = new Vector3(transform.forward, 0.0f, moveHorizontal);
		//ship.AddRelativeForce(Vector3.forward * speed);
		transform.Translate(transform.forward * speed, Space.World); //With vector movements
		//transform.localPosition = 

		#endregion


		#region Looking direction
		//looks in moving direction and keeps direction after finished movement.

		Vector3 lookDirection = new Vector3(moveHorizontal*(-1), 0.0f, moveVertical);
		if(lookDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.9f);
		#endregion 

		//transform.Translate (moveVertical, 0.0f, moveHorizontal , Space.World); //without float movement
	

		#region tilts the ship akwardly, could possibly be used
		/*		
 		lookDirection += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
		transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, targetRotation, speed*Time.deltaTime);
		#endregion

		#region



		#endregion
		*/

		n = 1;
		moveCharacter ();
		RotateCharacter ();
	}

	void moveCharacter()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (moving == false) {
				speed = speed + 0.001f;
				moving = true;
			}
			if (speed <= speedLimit) {
				float speedfactor = accelerationfactor / mass;
				speed = speed + speedfactor;

				//An attempt on "gradual speed increase"
				/*if (speed < 2f)
					speed = speed + 0.01f;
					//speed = speed + 0.05f;
				if (speed < 5f && speed > 2f)
					speed = speed + 0.07f;
					speed = speed + 0.2f;
					speed = speed + speed + 0.2f; //can be used for burst skill
				*/
			}
		}
		// Down arrow impl.
		/*
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				if (speed > 0f)
				{
					speed = speed - 0.2f;
				}
			}

		*/	
			else if (!Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
			if (speed > 0f) {
				float decreasefactor = slowfactor / mass;
				speed = speed * 0.99f;
				//speed = speed - 0.01f; //slows down linearly
				/*if(speed >= 2f) 
					speed = speed - 0.02f*speed;
				if (speed < 2 && speed > 0f)
					speed = speed - 0.04f * speed;
				}*/
			}
		}
		if (speed < 0.001f) 
			{
				speed = 0f;
			}
		transform.Translate (transform.right * speed * Time.deltaTime, Space.World); //the coordinate system of the ship has switched horizontal with right and up so we do the same.
	}

	void RotateCharacter()
	{
		/*
		 * turnfactor should be based on mass and a procentage factor
		 * procentage factor should be based on buffs.
		 */
		if(Input.GetKey(KeyCode.LeftArrow) && speed != 0) //rotation needs to be based on speed!. ALSO, implement speedup in relation to mass in the above code. //display backwards.
		{
			float rotationfactor = (turnfactor * speed);
			transform.Rotate (transform.up, (-1*rotationfactor) * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.RightArrow) && speed != 0)
		{
			float rotationfactor = turnfactor * speed;
			transform.Rotate (transform.up, rotationfactor * Time.deltaTime, Space.World);
		}
	}
}