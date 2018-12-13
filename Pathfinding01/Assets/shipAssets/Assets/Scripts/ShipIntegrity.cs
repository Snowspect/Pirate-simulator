using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIntegrity : MonoBehaviour {

	public float armor;
	public float health;
	private float cannonballDmg;
    private float cannonballArmorDmg;
	public float shipCollisionDamage;
	public Rigidbody rdbod;

	// Use this for initialization 
	void Start () 
	{
        //armor = PlayerController.armor;
        //health = PlayerController.healthPool; 
		cannonballDmg = 10f; //Skal ændres til ontrigger.getgameobject.getcannonballdmg eller noget i den stil 
	} 
	
	// Update is called once per frame
	void Update () 
	{ 
		checkIntegrity(); 
	} 

	/// <summary>
	/// IF SHIP HAS NO HEALTH BACK
	/// </summary>
	void checkIntegrity() 
	{ 
		if (health < 0) 
		{ 
			Debug.Log ("ship got destroyed by health trigger"); 
			Destroy (gameObject); 
		} 
	} 

	/// <summary>
	/// TRIGGERS WHILE SHIP TOUCHES OTHER COLLIDER CONSTANTLY
	/// CHANGE TO INTEGRITY AS BUFF TO MINIMIZE DAMAGE.
	/// </summary>
/*	void OnTriggerStay(Collider other) 
	{ 
		if (other.tag.Equals ("light") || other.tag.Equals ("medium") || other.tag.Equals ("heavy")) 
		{ 
			if (integrity > 1) 
			{ 
				health = health - (0.3f / integrity); 
				integrity = integrity - (shipCollisionDamage * 0.04f); 
			} 

			else if (integrity <= 1) //if integrity (armor) 
			{ 
				Debug.Log ("Ship has no integrity left"); 
				Debug.Log ("ship taking maximum collision damage"); 
				health = health - (0.5f / (integrity * 10)); 
			} 
		} 
	} 
*/ 

	/// <summary> 
	/// TRIGGERS WHEN A COLLIDER HITS ANOTHER COLLIDER FIRST TIME 
	/// </summary> 
	void OnTriggerEnter(Collider other) 
	{ 
		if (other.tag.Equals("cannonball")) 
		{
            GameObject cannonball =                 other.gameObject.GetComponent<GameObject>();
            CanonBallTrigger cannonballScript =     cannonball.GetComponent<CanonBallTrigger>();
            cannonballDmg =                         cannonballScript.cannonballDamage;
            cannonballArmorDmg =                    cannonballScript.cannonballArmorDamage;

            applyHealthDmgAfterArmor();
            applyArmorDamage();
		} 
		 
	}

    private void applyHealthDmgAfterArmor()
    {
 
        health = cannonballDmg - armor;
    }
    private void applyArmorDamage()
    {
        armor = armor - cannonballArmorDmg;

    }
} 