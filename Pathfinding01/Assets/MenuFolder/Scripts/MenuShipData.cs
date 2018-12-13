using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShipData : MonoBehaviour {

    public GameObject lightShip,mediumShip,heavyShip;
    private void Update()
    {
        string ship = UserData.shipType;
        if(ship == "Light" || true)
        {
            lightShip.SetActive(true);
            mediumShip.SetActive(false);
            heavyShip.SetActive(false);
            lightShip.transform.Rotate(Vector3.up * Time.deltaTime*20);
        }
        else if(ship == "Medium")
        {
            lightShip.SetActive(false);
            mediumShip.SetActive(true);
            heavyShip.SetActive(false);
            mediumShip.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }
        else if(ship == "Heavy")
        {
            lightShip.SetActive(false);
            mediumShip.SetActive(false);
            heavyShip.SetActive(true);
            heavyShip.transform.Rotate(Vector3.up * Time.deltaTime * 20);
        }
    }
    public void SetShipType( string type)
    {
        UserData.shipType = type;
//        Shipdata.shiptype = type;
    }
}
