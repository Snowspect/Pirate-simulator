using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour { 

	Text RightText; 
	Text LeftText; 
	// Use this for initialization
	void Start () { 
		string[] buffs = new string[] {"Buff nr: [1] \nBuff: 15% faster sailing \nDebuff: no cannons on right side", "Buff nr: [2] \nBuff: 3 cannons each side \nDebuff: recharge increased by 10%", 
			"Buff nr: [3] \nBuff: 20% decreased recharge \nDebuff: 1 cannon each side"}; 

		RightText = GameObject.Find ("right_cube_text").GetComponent<Text> (); 
		LeftText = GameObject.Find ("left_cube_text").GetComponent<Text> (); 

		// Initiates the buff texts 
		bool run = true; 
		while (run) 
		{ 
			int buffChosen = Random.Range (1, 3); 
			int rightChosenBuff = 0; 
			Debug.Log (buffChosen); 
			if (RightText.text.Equals ("No Input")) 
			{ 
				rightChosenBuff = buffChosen; 
				RightText.text = buffs [buffChosen]; 
			} 
			else 
			{ 
				// Checks if we hit the same buff as the rightText and if so, try again as we don't want the same buff to appear in two places.
				buffChosen = Random.Range (1, 3); 
				if (buffChosen != rightChosenBuff) 
				{ 
					LeftText.text = buffs [buffChosen]; 
					run = false; 
				} 
			} 
		} 
	} 
	
	// Update is called once per frame 
	void Update () { 
		
	} 
} 