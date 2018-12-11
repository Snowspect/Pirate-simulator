using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour {

    static Text leftBuffText;
    static Text leftDebuffText;
    static Text rightBuffText;
    static Text rightDebuffText;
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
        buffList.Add(new Buff("Less Mass",                       0.05f, 0.10f, 0));
        buffList.Add(new Buff("Smaller Cannon Delay",            0.10f, 0.20f, 1));
        buffList.Add(new Buff("Faster Cannon Recharge Time",     0.10f, 0.20f, 2));
        buffList.Add(new Buff("More Armor",                      0.10f, 0.25f, 3));
        buffList.Add(new Buff("Bigger Health Pool,",             0.05f, 0.15f, 4));
        buffList.Add(new Buff("Faster Cannonball Fly Time",      0.05f, 0.10f, 5));
        buffList.Add(new Buff("More Cannonball Damage",          0.10f, 0.20f, 6));
        buffList.Add(new Buff("More Cannonball Piercing",        0.10f, 0.20f, 7));
        buffList.Add(new Buff("More Cannon Range",               0.05f, 0.10f, 8));
        buffList.Add(new Buff("Less Cannon Spread",              0.05f, 0.10f, 9));


        //Creating Debuffs
        debuffList.Add(new Debuff("Bigger Mass",                  0.05f, 0.10f, 0));
        debuffList.Add(new Debuff("Bigger Cannon delay",          0.10f, 0.20f, 1));
        debuffList.Add(new Debuff("Slower recharge time",         0.10f, 0.20f, 2));
        debuffList.Add(new Debuff("Less Armor",                   0.10f, 0.20f, 3));
        debuffList.Add(new Debuff("Smaller Health Pool",          0.05f, 0.10f, 4));
        debuffList.Add(new Debuff("Slower Cannonball Fly Time",   0.05f, 0.10f, 5));
        debuffList.Add(new Debuff("Less Cannonball Damage",       0.10f, 0.20f, 6));
        debuffList.Add(new Debuff("Less Cannonball Piercing",     0.10f, 0.20f, 7));
        debuffList.Add(new Debuff("Less Cannon Range",            0.05f, 0.10f, 8));
        debuffList.Add(new Debuff("More Cannon Spread",           0.05f, 0.10f, 9));

 
        leftBuffText =      GameObject.Find("left_cube_buff_text").     GetComponent<Text>();
        leftDebuffText =    GameObject.Find("left_cube_debuff_text").   GetComponent<Text>();
        rightBuffText =     GameObject.Find("right_cube_buff_text").    GetComponent<Text>();
        rightDebuffText =   GameObject.Find("right_cube_debuff_text").  GetComponent<Text>();

        //leftBuffText.color =        Color.green;
        //leftDebuffText.color =      Color.red;
        //rightBuffText.color =       Color.green;
        //rightDebuffText.color =     Color.red;

        updateBuffsAndDebuffs();

    }

    // Update is called once per frame 
    void Update() {

    }

    static public void updateBuffsAndDebuffs()
    {
        tempLeftBuff =          getRandomBuff();
        tempLeftDebuff =        getRandomDebuff();
        tempRightBuff =         getRandomBuff();
        tempRightDebuff =       getRandomDebuff();

        leftBuffText.text =     tempLeftBuff.getDescription();
        leftDebuffText.text =   tempLeftDebuff.getDescription();
        rightBuffText.text =    tempRightBuff.getDescription();
        rightDebuffText.text =  tempRightDebuff.getDescription();
        
    }

    static private Buff getRandomBuff()
    {
        switch (Random.Range(0,9))
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
            case 9:
                return buffList[9];
                break;

        }
        return null;    
    }


    static private Debuff getRandomDebuff()
    {

        switch (Random.Range(0, 9))
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
            case 9:
                return debuffList[9];
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
    private int index;


    public Buff(string newName, float newMin, float newMax, int newIndex)
    {
        name = newName;
        min = newMin;
        max = newMax;
        index = newIndex;

        multiplier = this.randomizeMultiplier();
        description = "Applies " + (int)(multiplier * 100) + "% " + name;

        if (index == 0 || index == 1 || index == 2 || index == 5 || index == 9)
        {
            multiplier = multiplier * -1;

        } else
            multiplier = multiplier * 1;

    }

    public string getname()
    {
        return name;
    }

    public int getIndex()
    {
        return index;
    }

    public float randomizeMultiplier()
    {
        return multiplier = Random.Range(min, max);
        
    }

    public float getMultiplier()
    {
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
    private int index;


    public Debuff(string newName, float newMin, float newMax, int newIndex)
    {
        name = newName;
        min = newMin;
        max = newMax;
        index = newIndex;

        multiplier = this.randomizeMultiplier();
        description = "Applies " + (int)(multiplier * 100) + "% " + name;

        if (index == 3 || index == 4 || index == 6 || index == 7 || index == 8)
        {
            multiplier = multiplier * -1;

        }
        else
            multiplier = multiplier * 1;
    }

    public string getname()
    {
        return name;
    }

    public int getIndex()
    {
        return index;
    }

    public float randomizeMultiplier()
    {
        return multiplier = Random.Range(min, max);
    }

    public float getMultiplier()
    {
        return multiplier;
    }

    public string getDescription()
    {
        return description;
    }

}