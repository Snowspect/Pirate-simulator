using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour {

    static Text RightText;
    static Text LeftText;
    int randomNumb;
    static List<Buff> buffList = new List<Buff>();
    static List<Debuff> debuffList = new List<Debuff>();
    static public Buff tempLeftBuff;
    static public Debuff tempLeftDebuff;
    static public Buff tempRightBuff;
    static public Debuff tempRightDebuff;

    // Use this for initialization
    void Start() {



        //Creating Buffs
        buffList.Add(new Buff("Less Mass",                       0.05f, 0.10f));
        buffList.Add(new Buff("Smaller Cannon Delay",            0.10f, 0.20f));
        buffList.Add(new Buff("Faster Cannon Recharge Time",     0.10f, 0.20f));
        buffList.Add(new Buff("More Armor",                      0.10f, 0.25f));
        buffList.Add(new Buff("Bigger Health Pool,",             0.05f, 0.15f));
        buffList.Add(new Buff("Faster Cannonball Fly Time",      0.05f, 0.10f));
        buffList.Add(new Buff("More Cannonball Damage",          0.10f, 0.20f));
        buffList.Add(new Buff("More Cannonball Piercing",        0.10f, 0.20f));
        buffList.Add(new Buff("More Cannon Range",               0.05f, 0.10f));


        //Creating Debuffs
        debuffList.Add(new Debuff("Bigger Mass",                  0.05f, 0.10f));
        debuffList.Add(new Debuff("Bigger Cannon delay",          0.10f, 0.20f));
        debuffList.Add(new Debuff("Slower recharge time",         0.10f, 0.20f));
        debuffList.Add(new Debuff("Less Armor",                   0.10f, 0.20f));
        debuffList.Add(new Debuff("Smaller Health Pool",          0.05f, 0.10f));
        debuffList.Add(new Debuff("Slower Cannonball Fly Time",   0.05f, 0.10f));
        debuffList.Add(new Debuff("Less Cannonball Damage",       0.10f, 0.20f));
        debuffList.Add(new Debuff("Less Cannonball Piercing",     0.10f, 0.20f));
        debuffList.Add(new Debuff("Less Cannon Range",            0.05f, 0.10f));


        RightText = GameObject.Find("right_cube_text").GetComponent<Text>();
        LeftText = GameObject.Find("left_cube_text").GetComponent<Text>();

        updateBuffsAndDebuffs();

    }

    // Update is called once per frame 
    void Update() {

    }

    static public void updateBuffsAndDebuffs()
    {
        tempLeftBuff = getRandomBuff();
        tempLeftDebuff = getRandomDebuff();
        tempRightBuff = getRandomBuff();
        tempRightDebuff = getRandomDebuff();

        LeftText.text = tempLeftBuff.getDescription() + "\n" +
                            tempLeftDebuff.getDescription();
        RightText.text = tempRightBuff.getDescription() + "\n" +
                            tempRightDebuff.getDescription();
    }

    static private Buff getRandomBuff()
    {
        switch (Random.Range(0,8))
        {
            case 0:
                return buffList[0];
                break;
            case 1:
                return buffList[1];
                break;
            case 2:
                return buffList[2];
                break;
            case 3:
                return buffList[3];
                break;
            case 4:
                return buffList[4];
                break;
            case 5:
                return buffList[5];
                break;
            case 6:
                return buffList[6];
                break;
            case 7:
                return buffList[7];
                break;
            case 8:
                return buffList[8];
                break;

        }
        return null;    
    }


    static private Debuff getRandomDebuff()
    {

        switch (Random.Range(0, 8))
        {
            case 0:
                return debuffList[0];
                break;
            case 1:
                return debuffList[1];
                break;
            case 2:
                return debuffList[2];
                break;
            case 3:
                return debuffList[3];
                break;
            case 4:
                return debuffList[4];
                break;
            case 5:
                return debuffList[5];
                break;
            case 6:
                return debuffList[6];
                break;
            case 7:
                return debuffList[7];
                break;
            case 8:
                return debuffList[8];
                break;

        }
        return null;
    }
}


public class Buff {
    private string name;
    private float multiplier;
    private float min, max;
    private string description;


    public Buff(string newName, float newMin, float newMax)
    {
        name = newName;
        min = newMin;
        max = newMax;

        this.randomizeMultiplier();
        description = "Applies " + (int)((multiplier - 1) * 100) + "% " + name;
    }

    public string getname()
    {
        return name;
    }

    public void randomizeMultiplier()
    {
        multiplier = 1 + Random.Range(min, max);
        
    }

    public float getMultiplier()
    {
        randomizeMultiplier();
        return multiplier;
    }

    public string getDescription()
    {
        return description;
    }

}

public class Debuff
{
    private string name;
    private float multiplier;
    private float min, max;
    private string description;


    public Debuff(string newName, float newMin, float newMax)
    {
        name = newName;
        min = newMin;
        max = newMax;

        this.randomizeMultiplier();
        description = "Applies " + (int)((-multiplier + 1) * 100) + "% " + name;
    }

    public string getname()
    {
        return name;
    }

    public void randomizeMultiplier()
    {
        multiplier = 1 - Random.Range(min, max);
    }

    public float getMultiplier()
    {
        randomizeMultiplier();
        return multiplier;
    }

    public string getDescription()
    {
        return description;
    }

}