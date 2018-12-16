using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLeftRechargeTime : MonoBehaviour {

	GameObject player;
	Text leftRechargeTimeText;
	ShipShootLeft localScriptRef;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerShip");
		leftRechargeTimeText = GameObject.Find ("RechargeLeftTime").GetComponent<Text> ();
		localScriptRef = player.GetComponent<ShipShootLeft> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (localScriptRef.localRecharge <= 0) {
			leftRechargeTimeText.color = Color.green;
			leftRechargeTimeText.text = "Left ready!";
		} else 
		{
			leftRechargeTimeText.color = Color.red;
			leftRechargeTimeText.text = "" + (int) localScriptRef.localRecharge;
		}
	}
}
