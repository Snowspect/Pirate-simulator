using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnsAndGoalstate : MonoBehaviour {

    public GameObject spawnPointPlayer;
    public GameObject spawnPointAI;
    public Rigidbody Player;
    public Rigidbody AiShip;
    bool spawnedFirst = false, spawnedSecond = false, spawnedThird = false, spawnedFourth = false;
    private int index = 0;
    List<bool> aiShipAlive = new List<bool>();
	private Button nextScene;
	private Canvas ButtonCanvas;
	Text SpawnText;
	float localSpawnTextDuration = 0f;
	bool startSpawnTextDuration = false;

	Canvas winCanvas;
	Text winText, taskText,levelText;
	Button winButton;

    // Use this for initialization
    void Awake()
    {
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();

		if (LevelController.level == 1) {
			levelText.text = "Level 1/2";
		} else 
		{
			levelText.text = "Level 2/2";
		}

		taskText = GameObject.Find ("TaskText").GetComponent<Text> ();

		winText = GameObject.Find ("WinText").GetComponent<Text>();
		winText.enabled = false;

		winCanvas = GameObject.Find ("WinCanvas").GetComponent<Canvas>();
		winCanvas.enabled = false;

		winButton = GameObject.Find ("WinButton").GetComponent<Button> ();


		AllowSpawnAgain ();
		SpawnText = GameObject.Find ("SpawnText").GetComponent<Text> ();

		// gets the reference to the button that lets you go to buff sccene once you wins
		nextScene = GameObject.Find ("Proceed").GetComponent<Button>();
		nextScene.onClick.AddListener(() => ButtonClickedInGame()); 
		winButton.onClick.AddListener (() => EndGameClick ());


		//gets the references to the canvas that the button is part of (used later to show it once you beat the level)
		ButtonCanvas = GameObject.Find ("ButtonCanvas").GetComponent<Canvas> ();
		ButtonCanvas.enabled = false;


		//spawning initial Player and AI 
		Rigidbody PlayerShip; 

        PlayerShip = Instantiate(Player, spawnPointPlayer.transform.position, spawnPointPlayer.transform.rotation) as Rigidbody; //will work with different scenes 
        PlayerShip.name = "PlayerShip"; 
		Debug.Log ("The ships data type is: " + ShipData.shipType); 
		PlayerShip.tag = ShipData.shipType; 

		if(Player.tag.Equals("heavy"))
		{
			PlayerShip.transform.SetPositionAndRotation(new Vector3(PlayerShip.transform.position.x, 6,PlayerShip.transform.position.z), PlayerShip.transform.rotation);
		}
				

		//Applies buffs to the ship 
		ApplyBuffs tmpScript = new ApplyBuffs(); 
		tmpScript.apply(PlayerShip.gameObject); 



		//Spawns an ai ship
		Rigidbody AIShip = Instantiate(AiShip, spawnPointAI.transform.position, spawnPointAI.transform.rotation) as Rigidbody;
        AIShip.name = "AI" + index;
        index++;
		taskText.text = "Kill 0/2 enemies";

		//List used throughout to check if all AI have spawned and are dead or alive
        aiShipAlive.Add(false); 
        aiShipAlive.Add(false); 
        aiShipAlive.Add(false); 
        aiShipAlive.Add(false);	

        aiShipAlive[0] = true; //activates first spot so now first player is "alive", accordingly to the list
		spawnedFirst = true;

		ShowEnemySpawnText ();
    }

    void start()
    {

    }

    // Update is called once per frame
    void Update() 
    { 
		checkIfPlayerAlive ();
        //      Debug.Log ("This is the time since startup : " + Time.realtimeSinceStartup);
		if ((Time.timeSinceLevelLoad > 119f && Time.timeSinceLevelLoad < 121f) || (GameObject.Find("AI0") == null && spawnedSecond == false))
        { 
            if (spawnedSecond == false)
            {
                Debug.Log("tried to spawn AI1");
                spawnAi();
                spawnedSecond = true;
                aiShipAlive[1] = true; //activates second player
				ShowEnemySpawnText();
            }
        }

		/*
        //4 minutes have passed and can't find either the first AISHIP or the second AISHIP
		if (Time.timeSinceLevelLoad > 239f && Time.timeSinceLevelLoad < 241f || GameObject.Find("AI0") == null && GameObject.Find("AI1") == null)
        {
            if (spawnedThird == false)
            {
                Debug.Log("tried to spawn AI2");
                spawnAi();
                spawnedThird = true;
                aiShipAlive[2] = true; //activates third player
            }
        }
		if (Time.timeSinceLevelLoad > 359f && Time.timeSinceLevelLoad < 361f || GameObject.Find("AI0") == null && GameObject.Find("AI1") == null && GameObject.Find("AI2") == null)
        {
            if (spawnedFourth == false)
            {
                Debug.Log("tried to spawn AI3");
                spawnAi();
                spawnedFourth = true;
                aiShipAlive[3] = true; //activates fourth player
            }
        }*/


		CheckIfAIAlive(); //checks for each AI if it is to find.
		Goalstate(); 

		if (startSpawnTextDuration == true) { 
			DecreaseSpawnTextTime ();
		} 
		if (localSpawnTextDuration <= 0) 
		{ 
			HideEnemySpawnText (); 
		} 
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
//        if (spawnedFourth == true)
		if (spawnedSecond == true)
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
				if (LevelController.GameEnd () == 2) { 
					//Load final scene, as game is won 
					winText.enabled = true; 
					winCanvas.enabled = true; 
				} else 
				{
					ButtonCanvas.enabled = true;
				}
            } 
        } 
    } 

    /// <summary> 
    /// CHECKS IF AI IS ALIVE AND IF CERTAIN TIME HAS PASSED OR IF THE AI HAS BEEN SPAWNED BEFORE (WE CAN'T ACCEPT IT IS GONE IF IT HAVEN'T BEEN SPAWNED BEFORE)
    /// </summary> 
    void CheckIfAIAlive() 
    { 
		//Debug.Log ("Hooooo");
        if (GameObject.Find("AI0") == null)
        { 
            aiShipAlive[0] = false;
			taskText.text = "Kill 1/2 enemies";
        } 
        if (GameObject.Find("AI1") == null && (Time.realtimeSinceStartup > 125f || spawnedSecond == true))  //checks if the object exists AND if certain time has passed or if the ship has already been spawned before.
        { 
            aiShipAlive[1] = false;
			taskText.text = "Kill 2/2 enemies";
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

	void checkIfPlayerAlive() 
	{ 
		if (GameObject.Find ("PlayerShip") == null) 
		{ 
			AllowSpawnAgain ();
			SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single); 
		} 
	} 

	public void ButtonClickedInGame () 
	{ 
		LevelController.IncrementLevel (); //increments the level counter. 
		//AllowSpawnAgain();
		SceneManager.LoadScene ("Choose ship and buff", LoadSceneMode.Single); 
	} 

	void AllowSpawnAgain()
	{
		spawnedFirst = false;
		spawnedSecond = false;
		spawnedThird = false;
		spawnedFourth = false;
	}

	void ShowEnemySpawnText()
	{
		SpawnText.enabled = true;
		localSpawnTextDuration = 3;
		startSpawnTextDuration = true;
	}
	void HideEnemySpawnText()
	{
		SpawnText.enabled = false;	
		startSpawnTextDuration = false;
	}
	void DecreaseSpawnTextTime()
	{
		localSpawnTextDuration -= Time.deltaTime;
	}

	void EndGameClick ()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single); 	
		LevelController.level = 1;
	}
} 