using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIntegrity : MonoBehaviour {

	public float integrity;
	public float health;
	public float cannonballDmg;
	public Rigidbody rdbod;

	// Use this for initialization
	void Start () {
		integrity = 10f;
		health = 50f;
		cannonballDmg = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		shipFail ();
	}


	void shipFail()
	{
		if (integrity <= 0) {
			Destroy (gameObject);
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("cannonball"))
		{
			health = health - (cannonballDmg / integrity);
			//health -= 5;
			integrity = integrity - 0.5f;
		}
		if (other.tag.Equals ("light") || other.tag.Equals ("medium") || other.tag.Equals ("heavy")) 
		{
			health = health - (cannonballDmg / integrity);
			integrity = integrity - 0.5f;
			//health = health - (something with mass and current ship speed)
		}
	}
}
