using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awakening : MonoBehaviour {

	Toggle light; 
	Toggle medium; 
	Toggle heavy; 


	// Use this for initialization 
	void Awake () { 
		
		light = GameObject.Find ("light toggle").GetComponent<Toggle> (); 
		medium = GameObject.Find ("medium toggle").GetComponent<Toggle> (); 
		heavy = GameObject.Find ("heavy toggle").GetComponent<Toggle> (); 

		if (UserData.firstScene == true) 
		{
			Debug.Log ("HALLLOOOOO"); 
			light.gameObject.SetActive (false); 
			medium.gameObject.SetActive (false); 
			heavy.gameObject.SetActive (false); 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
