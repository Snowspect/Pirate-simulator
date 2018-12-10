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
        Debug.Log("Test");
        rightChoiceButton.onClick.AddListener(() => ButtonClicked(2));

    }
	
	// Update is called once per frame
	void Update () 
	{		
		
	}
   

	/// <summary>
	/// CALLED WHEN BUTTON IS CLICKED
	/// </summary>
	public void ButtonClicked(int buttonNumb)
	{
        //this gets triggered twice for some reason, tried to disable leftChoiceButton listener to see if it would only print once when clicked but still prints twice.
        //left side
        if (buttonNumb == 1) {
            UserData.shipBuffList.Add(Buffs.tempLeftBuff);
            UserData.shipDebuffList.Add(Buffs.tempLeftDebuff);
            Debug.Log(Buffs.tempLeftBuff.getDescription());
            Debug.Log(Buffs.tempLeftDebuff.getDescription());
            
        }
        //right side
        if (buttonNumb == 2)
		{
            UserData.shipBuffList.Add(Buffs.tempRightBuff);
            UserData.shipDebuffList.Add(Buffs.tempRightDebuff);
            Debug.Log(Buffs.tempRightBuff.getDescription());
            Debug.Log(Buffs.tempRightDebuff.getDescription());
        }
        leftChoiceButton.interactable = false;
        rightChoiceButton.interactable = false;
    } 
} 