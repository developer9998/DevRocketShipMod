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
        if (!DevRocketShipMod.Plugin.blastOff)
        {
            if (other.name == "RightHandTriggerCollider" || other.name == "LeftHandTriggerCollider")
            {
                DevRocketShipMod.Plugin.findThisRocket = gameObject.transform.parent.transform.parent.name.ToString();
                DevRocketShipMod.Plugin.findThisRocket = gameObject.transform.parent.transform.parent.name.ToString();
                DevRocketShipMod.Plugin.blastOff = true;
                gameObject.transform.parent.gameObject.SetActive(false); // no spam
            }
        }
    }

}