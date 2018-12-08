using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIntegrity : MonoBehaviour {

	public float integrity;
	public float health;
	public float cannonballDmg;
	public float shipCollisionDamage;
	public Rigidbody rdbod;

	// Use this for initialization 
	void Start () 
	{ 
		integrity = 10f; 
		health = 50f; 
		cannonballDmg = 10f; 
	} 
	
	// Update is called once per frame
	void Update () 
	{ 
		shipFail (); 
	} 

	/// <summary>
	/// IF SHIP HAS NO HEALTH BACK
	/// </summary>
	void shipFail() 
	{ 
		if (health < 0) 
		{ 
			Debug.Log ("ship got destroyed by health trigger"); 
			Destroy (gameObject); 
		} 
	} 

	/// <summary>
	/// TRIGGERS WHILE SHIP TOUCHES OTHER COLLIDER CONSTANTLY
	/// </summary>
	void OnTriggerStay(Collider other) 
	{ 
		if (other.tag.Equals ("light") || other.tag.Equals ("medium") || other.tag.Equals ("heavy")) 
		{ 
			if (integrity > 1) 
			{ 
				health = health - (0.3f / integrity); 
				integrity = integrity - (shipCollisionDamage * 0.04f); 
			} 

			else if (integrity <= 1) 
			{ 
				Debug.Log ("Ship has no integrity left"); 
				Debug.Log ("ship taking maximum collision damage"); 
				health = health - (0.5f / (integrity * 10)); 
			} 
		} 
	} 

	/// <summary>
	/// TRIGGERS WHEN A COLLIDER HITS ANOTHER COLLIDER FIRST TIME
	/// </summary>
	void OnTriggerEnter(Collider other) 
	{ 
		if (other.tag.Equals("cannonball")) 
		{ 
			health = health - (cannonballDmg / integrity); 
			integrity = integrity - 0.5f; 
		} 
		if (other.tag.Equals ("light") || other.tag.Equals ("medium") || other.tag.Equals ("heavy")) 
		{ 
			//health = health - (0.8f / integrity); 
			integrity = integrity - shipCollisionDamage; 
		} 
	} 
} 