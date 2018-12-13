using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 


public class PlayerController : MonoBehaviour {

    public GameObject playerShip;
    public static float speed; 
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

    public float mass;
    public float cannonDelay;
    public float cannonRechargeTime;
    public float armor;
    public float healthPool;
    public float cannonballFlyTime;
    public float cannonballDamage;
    public float cannonballPiercing;
    public float cannonRange;
    public float cannonSpread;
    //0 = Mass                 
    //1 = Smaller Cannon Delay     
    //2 = Cannon Recharge Time
    //3 = Armor
    //4 = Health Pool       
    //5 = Cannonball Fly Time
    //6 = Cannonball Damage    
    //7 = Cannonball Piercing
    //8 = Cannon Range
    //9 = Cannon Spread


    // Use this for initialization 
    void Start () 
	{ 
        playerShip = GameObject.Find("PlayerShip"); 
        setShipStandard(); 
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
			} 
		}
		//so the ship doesn't go into a n^e factor indefinietly.
		if (speed < minimumSpeedTrigger) 
			{
				speed = minimumSpeed;
			}

		//moves the ship in relation to the world, taking the ships internal coordinate system into consideration (found through experimentation)
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);

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
            playerShip.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
			mass = 80f;
            cannonDelay = 0.1f;
            cannonRechargeTime = 2;
            armor = 20;
            healthPool = 50;
            cannonballFlyTime = 30; //shoot acceleration
            cannonballDamage = 10;
            cannonballPiercing = 
            cannonRange = 20; // cannon angle
            cannonSpread = 10; // multipler for shoot cannons script



            accelerationfactor = 1000f / mass; 
			maximumSpeed = (1000f / mass); // 6,6
			minimumSpeed = 0f;
			turnfactor = 7000f / mass;


		}

		if (this.tag.Equals("medium"))
		{
            playerShip.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            mass = 120f;
            cannonDelay = 3f;
            cannonRechargeTime = 2;
            armor = 20;
            healthPool = 50;
            cannonballFlyTime = 30; //shoot acceleration
            cannonballDamage = 20;
            cannonRange = 30; // cannon angle
            cannonSpread = 5; // multipler for shoot cannons script

            accelerationfactor = 1000f / mass; 
			maximumSpeed = (1000f / mass); // 6,6
			minimumSpeed = 0f;
			turnfactor = 7000f / mass;
		}

		if (this.tag.Equals("heavy"))
		{
            playerShip.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

            mass = 160f;
            cannonDelay = 0.1f;
            cannonRechargeTime = 2;
            armor = 20;
            healthPool = 50;
            cannonballFlyTime = 30; //shoot acceleration
            cannonballDamage = 5;
            cannonRange = 50; // cannon angle
            cannonSpread = 15; // multipler for shoot cannons script

            accelerationfactor = 1000f / mass; 
			maximumSpeed = (1000f / mass); // 6,6
			minimumSpeed = 0f;
			turnfactor = 7000f / mass;
		}
	}
}

