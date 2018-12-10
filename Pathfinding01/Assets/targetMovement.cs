using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class targetMovement : MonoBehaviour { 

	public GameObject seekerTarget; 
	public GameObject ship; 
	public GameObject shipOrigin; 
	Vector3 upcomingposition; 
	float z = 0f; 
	// Use this for initialization 
	void Start () 
	{ 
		//z = shipOrigin.transform.localPosition.z; 
	} 
	
	// Update is called once per frame 
	void Update () 
	{ 
		float speedMult = PlayerController.speed;
		float staticRange = 100f;
		float positionValue = speedMult * 30 + staticRange;

		this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, positionValue);

		//float 
	} 
} 