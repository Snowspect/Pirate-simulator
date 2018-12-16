using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRightRechargeTime : MonoBehaviour {

	GameObject player;
	Text RightRechargeTimeText;
	ShipShootRight localScriptRef;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerShip");
		RightRechargeTimeText = GameObject.Find ("RechargeRightTime").GetComponent<Text> ();
		localScriptRef = player.GetComponent<ShipShootRight> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (localScriptRef.localRecharge <= 0) {
			RightRechargeTimeText.color = Color.green;
			RightRechargeTimeText.text = "Right ready!";
		} else 
		{
			RightRechargeTimeText.color = Color.red;
			RightRechargeTimeText.text = "" + (int) localScriptRef.localRecharge;
		}
	}
}
