using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallTrigger : MonoBehaviour {

    public float cannonballDamage;
    public float cannonballArmorDamage;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{

		Destroy (gameObject);
	}
}