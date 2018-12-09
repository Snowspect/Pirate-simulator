﻿using System.Collections;
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
		SceneManager.LoadScene ("AI Procedural", LoadSceneMode.Single);
	}
}
