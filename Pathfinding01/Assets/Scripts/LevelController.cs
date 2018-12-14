using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 

public class LevelController { 

	public static int level = 1; 


	// Use this for initialization 
	void Start () 
	{ 
		
	} 
	
	// Update is called once per frame 
	void Update () 
	{ 
		
	} 

	public static void IncrementLevel() 
	{ 
		level++; 
	} 

	public static int GameEnd() 
	{ 
		return level;
		//load scene that shows the end scene (possibly button that redirects to mainpage so player and play again 
	} 
} 