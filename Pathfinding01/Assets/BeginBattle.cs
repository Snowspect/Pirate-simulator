using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginBattle : MonoBehaviour {

	Button start;
	// Use this for initialization
	void Start () 
	{
		start = GameObject.Find("start battle button").GetComponent<Button>();
//		start = this;
		start.onClick.AddListener(() => ButtonClicked());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ButtonClicked()
	{
		dataHolder.firstScene = true; 
		Debug.Log ("Loading new scene and first scene bool is : " + dataHolder.firstScene);
		SceneManager.LoadScene ("AI Procedural", LoadSceneMode.Single);
	}
}