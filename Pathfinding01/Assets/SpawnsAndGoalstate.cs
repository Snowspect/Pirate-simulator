using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsAndGoalstate : MonoBehaviour {

    public GameObject spawnPointPlayer;
    public GameObject spawnPointAI;
    public Rigidbody Player;
    public Rigidbody AiShip;
    bool spawnedFirst = false, spawnedSecond = false, spawnedThird = false, spawnedFourth = false;
    private int index = 0;
    List<bool> aiShipAlive = new List<bool>();

    // Use this for initialization
    void Awake()
    {
        Rigidbody PlayerShip;
        PlayerShip = Instantiate(Player, spawnPointPlayer.transform.position, spawnPointPlayer.transform.rotation) as Rigidbody; //will work with different scenes
        PlayerShip.name = "PlayerShip";
        Rigidbody AIShip = Instantiate(AiShip, spawnPointAI.transform.position, spawnPointAI.transform.rotation) as Rigidbody;
        AIShip.name = "AI" + index;
        index++;
        Debug.Log("AI");
        aiShipAlive.Add(false);
        aiShipAlive.Add(false);
        aiShipAlive.Add(false);
        aiShipAlive.Add(false);
        aiShipAlive[0] = true; //activates first player
    }

    void start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //      Debug.Log ("This is the time since startup : " + Time.realtimeSinceStartup);
        if (Time.realtimeSinceStartup > /*1*/19f && Time.realtimeSinceStartup < /*1*/21f /* || GameObject.Find("AI0") == null */)
        {
            if (spawnedSecond == false)
            {
                Debug.Log("tried to spawn AI1");
                spawnAi();
                spawnedSecond = true;
                aiShipAlive[1] = true; //activates second player
            }

        }
        //4 minutes have passed and can't find either the first AISHIP or the second AISHIP
        else if (Time.realtimeSinceStartup > /*2*/39f && Time.realtimeSinceStartup < /*2*/41f /* || GameObject.Find("AI0") == null && GameObject.Find("AI1") == null */)
        {
            if (spawnedThird == false)
            {
                Debug.Log("tried to spawn AI2");
                spawnAi();
                spawnedThird = true;
                aiShipAlive[2] = true; //activates third player
            }
        }
        else if (Time.realtimeSinceStartup > /*3*/59f && Time.realtimeSinceStartup < /*3*/61f /* || GameObject.Find("AI0") == null && GameObject.Find("AI1") == null && GameObject.Find("AI2") == null */)
        {
            if (spawnedFourth == false)
            {
                Debug.Log("tried to spawn AI3");
                spawnAi();
                spawnedFourth = true;
                aiShipAlive[3] = true; //activates fourth player
            }
        }
        CheckIfAIAlive(); //checks for each AI if it is to find.
        Goalstate();
    }

    void spawnAi()
    {
        Rigidbody AIShip = Instantiate(AiShip, spawnPointAI.transform.position, spawnPointAI.transform.rotation) as Rigidbody;
        AIShip.name = "AI" + index;
        index++;
    }

    /// <summary>
    /// GETS TRIGGERED IF ALL SHIPS ARE GONE
    /// </summary>
    void Goalstate()
    {
        if (spawnedFirst == true)
        {
            int counter = 0;
            foreach (bool AIshipStatus in aiShipAlive)
            {
                if (AIshipStatus == false)
                {
                    counter++;
                }
            }
            if (counter == 4)
            {
                Debug.Log("YOU WON");
            }
        }
    }

    /// <summary>
    /// CHECKS IF AI IS ALIVE AND IF CERTAIN TIME HAS PASSED OR IF THE AI HAS BEEN SPAWNED BEFORE (WE CAN'T ACCEPT IT IS GONE IF IT HAVEN'T BEEN SPAWNED BEFORE)
    /// </summary>
    void CheckIfAIAlive()
    {
        if (GameObject.Find("AI0") == null)
        {
            aiShipAlive[0] = false;
        }
        if (GameObject.Find("AI1") == null && (Time.realtimeSinceStartup > 125f || spawnedSecond == true))  //checks if the object exists AND if certain time has passed or if the ship has already been spawned before.
        {
            aiShipAlive[1] = false;
        }
        if (GameObject.Find("AI2") == null && (Time.realtimeSinceStartup > 245f || spawnedThird == true))
        {
            aiShipAlive[2] = false;
        }
        if (GameObject.Find("AI3") == null && (Time.realtimeSinceStartup > 365f || spawnedFourth == true))
        {
            aiShipAlive[3] = false;
        }
    }
}
