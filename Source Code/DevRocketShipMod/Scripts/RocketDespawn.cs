using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDespawn : MonoBehaviour
{

    //Mod programmed by Dev (dev.#9998)
    //Do not use in any other mod (Reusing code, models, sounds, etc. Or using in mod menus.)

    //this script removes the rocket when it reaches a certain point on the Y axis

    void Update()
    {
        if (gameObject.transform.position.y < -24.7f)
        {
            DevRocketShipMod.Plugin.currentRocket--;
            GameObject.Destroy(gameObject);
            this.enabled = false;
        }
    }
}