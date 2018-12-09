using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Toggled : MonoBehaviour, IPointerClickHandler {

	public static string activeShip;
	Toggle light;
	Toggle medium;
	Toggle heavy;

	// Use this for initialization
	void Start () {
		light = GameObject.Find ("light toggle").GetComponent<Toggle> (); 
		medium = GameObject.Find ("medium toggle").GetComponent<Toggle> (); 
		heavy = GameObject.Find ("heavy toggle").GetComponent<Toggle> (); 

		light.isOn = false;
		medium.isOn = false;
		heavy.isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		if (this.name.Equals ("light toggle")) 
		{
			medium.isOn = false; 
			heavy.isOn = false;	
			dataHolder.shipName = "light";
			Debug.Log(dataHolder.shipName);
		} else if (this.name.Equals ("medium toggle")) 
		{
			light.isOn = false; 
			heavy.isOn = false; 
			dataHolder.shipName = "medium";
			Debug.Log(dataHolder.shipName);
		} else if (this.name.Equals ("heavy toggle")) 
		{
			light.isOn = false; 
			medium.isOn = false; 
			dataHolder.shipName = "heavy";
			Debug.Log(dataHolder.shipName);
		}
	}
	#endregion
}