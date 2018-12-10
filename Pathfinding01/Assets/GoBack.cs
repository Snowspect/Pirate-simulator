using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GoBack : MonoBehaviour { 

	Button start; 
	// Use this for initialization 
	void Start () 
	{ 
		start = GameObject.Find("Return").GetComponent<Button>(); 
		start.onClick.AddListener(() => ButtonClicked()); 
	} 
	
	// Update is called once per frame 
	void Update () 
	{ 
		
	} 

	public void ButtonClicked () 
	{ 
		Debug.Log ("This iiiiss the value!!!: " + UserData.firstScene);
		SceneManager.LoadScene ("Choose ship and buff", LoadSceneMode.Single); 
	} 
} 