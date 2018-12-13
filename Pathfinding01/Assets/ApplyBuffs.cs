using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ApplyBuffs
{
    //0 = Mass                 
    //1 = Smaller Cannon Delay     
    //2 = Cannon Recharge Time
    //3 = Armor
    //4 = Health Pool       
    //5 = Cannonball Fly Time
    //6 = Cannonball Damage    
    //7 = Cannonball Piercing
    //8 = Cannon Range
    //9 = Cannon Spread
    
    void Start()
    {
        //GameObject shipobj = this.Game
        //CanonBallTrigger cannonballScript = cannonball.GetComponent<CanonBallTrigger>();
        
        //cannonballDmg = ShipData.getShipMultiplier(0);

    }

    public void apply(GameObject ship)
    {

        ShipIntegrity shipIntegrityScript = ship.GetComponent<ShipIntegrity>();

        shipIntegrityScript.health = shipIntegrityScript.health * ShipData.getShipMultiplier(4);
        shipIntegrityScript.armor = shipIntegrityScript.armor * ShipData.getShipMultiplier(3);

        CanonBallTrigger cannonBallTriggerScript = ship.GetComponent<CanonBallTrigger>();
        cannonBallTriggerScript.cannonballDamage = cannonBallTriggerScript.cannonballDamage * ShipData.getShipMultiplier(6);
        cannonBallTriggerScript.cannonballArmorDamage = cannonBallTriggerScript.cannonballArmorDamage * ShipData.getShipMultiplier(7);

        PlayerController playerControllerScript = ship.GetComponent<PlayerController>();
        playerControllerScript.mass = playerControllerScript.mass * ShipData.getShipMultiplier(0);


        ShipShootLeft shipShootLeftScript = ship.GetComponent<ShipShootLeft>();
        shipShootLeftScript.m_MaxLaunchForce = shipShootLeftScript.m_MaxLaunchForce * ShipData.getShipMultiplier(5);
        shipShootLeftScript.minDelay = shipShootLeftScript.minDelay * ShipData.getShipMultiplier(1);
        shipShootLeftScript.maxDelay = shipShootLeftScript.maxDelay * ShipData.getShipMultiplier(1);
        shipShootLeftScript.rechargeLeftSideTime = shipShootLeftScript.rechargeLeftSideTime * ShipData.getShipMultiplier(2);
        shipShootLeftScript.cannonAngleLeftSide = shipShootLeftScript.cannonAngleLeftSide * ShipData.getShipMultiplier(8);

        ShipShootRight shipShootRightScript = ship.GetComponent<ShipShootRight>();
        shipShootRightScript.m_MaxLaunchForce = shipShootRightScript.m_MaxLaunchForce * ShipData.getShipMultiplier(5);
        shipShootRightScript.minDelay = shipShootRightScript.minDelay * ShipData.getShipMultiplier(1);
        shipShootRightScript.maxDelay = shipShootRightScript.maxDelay * ShipData.getShipMultiplier(1);
        shipShootRightScript.rechargeRightSideTime = shipShootRightScript.rechargeRightSideTime * ShipData.getShipMultiplier(2);
        shipShootRightScript.cannonAngleRightSide = shipShootRightScript.cannonAngleRightSide * ShipData.getShipMultiplier(8);



    }
}

