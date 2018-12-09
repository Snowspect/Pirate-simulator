using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChoiceBuff : MonoBehaviour {

	Button leftChoiceButton;
	Button rightChoiceButton;
	Text leftBuff;
	Text rightBuff;
	public static string buffChoice;
	// Use this for initialization
	void Start () 
	{
		//Gets references
		leftChoiceButton = GameObject.Find ("left buff button").GetComponent<Button> (); 
		rightChoiceButton = GameObject.Find ("right buff button").GetComponent<Button> (); 
		leftBuff = GameObject.Find ("left_cube_text").GetComponent<Text> (); 
		rightBuff = GameObject.Find ("right_cube_text").GetComponent<Text> (); 

		//Adds listener
		leftChoiceButton.onClick.AddListener(() => ButtonClicked(1));
		rightChoiceButton.onClick.AddListener(() => ButtonClicked(2));
	}
	
	// Update is called once per frame
	void Update () 
	{		
		
	}

	/// <summary>
	/// CALLED WHEN BUTTON IS CLICKED
	/// </summary>
	public void ButtonClicked(int buttonNr)
	{ 
		//this gets triggered twice for some reason, tried to disable leftChoiceButton listener to see if it would only print once when clicked but still prints twice.
		if (buttonNr == 1) { 
			dataHolder.buffNr = leftBuff.text.Substring (0, 12); 
			Debug.Log (dataHolder.buffNr); 
		} else 
		{ 
			dataHolder.buffNr = rightBuff.text.Substring (0, 12); 
			Debug.Log (dataHolder.buffNr); 
		} 
	} 
} 