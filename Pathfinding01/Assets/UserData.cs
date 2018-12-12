using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
	static public string shipType = "";
	static public bool firstScene = false;
    static public List<Buff> shipBuffList = new List<Buff>();
    static public List<Debuff> shipDebuffList = new List<Debuff>();
    static public List<float> shipMultipliers = new List<float>();
    
    //Overview of shipMultipliers:

    //0 = Mass                 
    //1 = Smaller Cannon Delay     
    //2 = Cannon Recharge Time
    //3 = Armor
    //4 = Health Pool       
    //5 = Cannonball Fly Time
    //6 = Cannonball Damage    
    //7 = Cannonball Piercing
    //8 = Cannon Range
    //9 = Cannon Spread

    void Start()
    {
        // Initialization of all indices in shipMultipliers
        for (int i = 0; i <= 10; i++)
        {
            Debug.Log("test");
            shipMultipliers.Add(1.0f);
        }
    }
        
    

    static public void applyBuffOrDebuff(int index, float multiplier)
    {
        shipMultipliers[index] = shipMultipliers[index] + multiplier;
    }

    static public float getShipMultiplier(int index)
    {
        return shipMultipliers[index];
    }

    static public Buff getBuff(int index)
    {
        return shipBuffList[index];
    }

    static public Debuff getDebuff(int index)
    {
        return shipDebuffList[index];
    }

    static public void clearBuffsAndDebuffs()
    {
        shipBuffList.Clear();
        shipDebuffList.Clear();
    }


}
