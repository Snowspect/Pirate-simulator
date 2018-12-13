using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ChoiceBuff : MonoBehaviour {

	Button leftChoiceButton;
    Button rightChoiceButton;
    Text shipStatsText1;
    Text shipStatsText2;
    Text chosenLeftText;
    Text chosenRightText;
    string shipStatsString1;
    string shipStatsString2;
	public static string buffChoice;
	// Use this for initialization
	void Start () 
	{
		//Gets references

        chosenLeftText = GameObject.Find("chosen_left_text").GetComponent<Text>();
        chosenRightText = GameObject.Find("chosen_right_text").GetComponent<Text>();
        leftChoiceButton = GameObject.Find("left buff button").GetComponent<Button>();
        rightChoiceButton = GameObject.Find("right buff button").GetComponent<Button>();
        shipStatsText1 = GameObject.Find("ship_stats_text1").GetComponent<Text>();
        shipStatsText2 = GameObject.Find("ship_stats_text2").GetComponent<Text>();


        //Adds listener
        leftChoiceButton.onClick.AddListener(() => ButtonClicked(1));
        rightChoiceButton.onClick.AddListener(() => ButtonClicked(2));
        //foreach (float item in ShipData.shipMultipliers) {

        
        shipStatsString1 = "Ships stats: \n";
        shipStatsString1 = shipStatsString1 + "Mass:                 \n";
        shipStatsString1 = shipStatsString1 + "Cannon Delay:         \n";
        shipStatsString1 = shipStatsString1 + "Cannon Recharge Time: \n";
        shipStatsString1 = shipStatsString1 + "Armor:                \n";
        shipStatsString1 = shipStatsString1 + "Health Pool:          \n";
        shipStatsString1 = shipStatsString1 + "Cannonball Fly Time:  \n";
        shipStatsString1 = shipStatsString1 + "Cannonball Damage:    \n";
        shipStatsString1 = shipStatsString1 + "Cannonball Piercing:  \n";
        shipStatsString1 = shipStatsString1 + "Cannon Range:         \n";
        shipStatsString1 = shipStatsString1 + "Cannon Spread:        \n";
        //}
        shipStatsText1.text = shipStatsString1;
    }

    // Update is called once per frame
    void Update()
    { 

        shipStatsString2 = "\n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[0] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[1] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[2] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[3] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[4] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[5] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[6] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[7] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[8] * 100) + "% \n";
        shipStatsString2 = shipStatsString2 + (int)(ShipData.shipMultipliers[9] * 100) + "% \n";
        Debug.Log("test");
        shipStatsText2.text = shipStatsString2;
    }
	/// <summary>
	/// CALLED WHEN BUTTON IS CLICKED
	/// </summary>
	public void ButtonClicked(int buttonNumb)
	{
        //this gets triggered twice for some reason, tried to disable leftChoiceButton listener to see if it would only print once when clicked but still prints twice.
        //left side
        if (buttonNumb == 1) {
            ShipData.shipBuffList.Add(      Buffs.tempLeftBuff);
            ShipData.shipDebuffList.Add(    Buffs.tempLeftDebuff);
            ShipData.applyBuffOrDebuff(     Buffs.tempLeftBuff.getIndex(),   Buffs.tempLeftBuff.getMultiplier());
            ShipData.applyBuffOrDebuff(     Buffs.tempLeftDebuff.getIndex(), Buffs.tempLeftDebuff.getMultiplier());
            chosenLeftText.text = "Buffs Chosen";
;

            Debug.Log(Buffs.tempLeftBuff.getDescription());
            Debug.Log(Buffs.tempLeftDebuff.getDescription());
            
        }
        //right side
        if (buttonNumb == 2)
		{
            ShipData.shipBuffList.Add(      Buffs.tempRightBuff);
            ShipData.shipDebuffList.Add(    Buffs.tempRightDebuff);
            ShipData.applyBuffOrDebuff(     Buffs.tempRightBuff.getIndex(),   Buffs.tempRightBuff.getMultiplier());
            ShipData.applyBuffOrDebuff(     Buffs.tempRightDebuff.getIndex(), Buffs.tempRightDebuff.getMultiplier());
            chosenRightText.text = "Buffs Chosen";

            Debug.Log(Buffs.tempRightBuff.getDescription());
            Debug.Log(Buffs.tempRightDebuff.getDescription());
        }
        leftChoiceButton.interactable = false;
        rightChoiceButton.interactable = false;
    } 
} 