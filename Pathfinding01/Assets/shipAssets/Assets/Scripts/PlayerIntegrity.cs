using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float integrity;
	public float health;
	public float cannonballDmg;
	public Rigidbody rdbod;

	// Use this for initialization
	void Start () {
		integrity = 10;
		health = 50;
		cannonballDmg = 10;
		rdbod = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter(Collision collision)
	{
		if (gameObject.tag == "cannonball") 
		{
			health = health - (cannonballDmg / integrity);
			//health -= 5;
			integrity = integrity - 3;
		}
	}

}