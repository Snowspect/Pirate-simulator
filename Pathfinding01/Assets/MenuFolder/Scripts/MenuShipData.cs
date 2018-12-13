using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShipData : MonoBehaviour {

    public GameObject lightShip,mediumShip,heavyShip;
    private void Update()
    {
        string ship = ShipData.shipType;
        if(ship.Equals("Light"))
        {
            lightShip.SetActive(true);
            mediumShip.SetActive(false);
            heavyShip.SetActive(false);
            lightShip.transform.Rotate(Vector3.up * Time.deltaTime*20);
        }
        else if(ship.Equals("Medium"))
        {
            lightShip.SetActive(false);
            mediumShip.SetActive(true);
            heavyShip.SetActive(false);
            mediumShip.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }
        else if(ship.Equals("Heavy"))
        {
            lightShip.SetActive(false);
            mediumShip.SetActive(false);
            heavyShip.SetActive(true);
            heavyShip.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }
    }
    public void SetShipType( string type)
    {
        ShipData.shipType = type;
//        Shipdata.shiptype = type;
    }
}
