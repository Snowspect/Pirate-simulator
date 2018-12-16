﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShipData : MonoBehaviour {

    public GameObject lightShip,mediumShip,heavyShip;
    private void Update()
    {
        string ship = ShipData.shipType;
        if(ship.Equals("Light") || ship.Equals(""))
        {
            lightShip.SetActive(true);
            mediumShip.SetActive(false);
            heavyShip.SetActive(false);
			SetShipType ("light");
        }
        else if(ship.Equals("Medium"))
        {
            lightShip.SetActive(false);
            mediumShip.SetActive(true);
            heavyShip.SetActive(false);
			SetShipType ("medium");
        }
        else if(ship.Equals("Heavy"))
        {
            lightShip.SetActive(false);
            mediumShip.SetActive(false);
            heavyShip.SetActive(true);
			SetShipType ("heavy");
        }

        lightShip.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        mediumShip.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        heavyShip.transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }
    public void SetShipType( string type)
    {
        ShipData.shipType = type;
    }
}
