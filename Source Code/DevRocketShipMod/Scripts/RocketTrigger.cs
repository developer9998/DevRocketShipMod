using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTrigger : MonoBehaviour
{
    //Mod programmed by Dev (dev.#9998)
    //Do not use in any other mod (Reusing code, models, sounds, etc. Or using in mod menus.)

    //this script changes a few variables in Plugin.cs to launch the rocket

    void Start()
    {
        gameObject.layer = 18;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "RightHandTriggerCollider" && !DevRocketShipMod.Plugin.blastOff)
        {
            DevRocketShipMod.Plugin.findThisRocket = gameObject.transform.parent.transform.parent.name.ToString();
            DevRocketShipMod.Plugin.blastOff = true;
            DevRocketShipMod.Plugin.handUsed = "r";
            gameObject.transform.parent.gameObject.SetActive(false); // no spam
        }
        else if (other.name == "LeftHandTriggerCollider" && !DevRocketShipMod.Plugin.blastOff)
        {
            DevRocketShipMod.Plugin.findThisRocket = gameObject.transform.parent.transform.parent.name.ToString();
            DevRocketShipMod.Plugin.blastOff = true;
            DevRocketShipMod.Plugin.handUsed = "l";
            gameObject.transform.parent.gameObject.SetActive(false); // no spam (again)
        }
    }

}