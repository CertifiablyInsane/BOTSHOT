using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_shotgun : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().shotgunAmmo += 8;
            other.gameObject.GetComponent<playerSounds>().PlaySound(1); //ammo pickup sound
            Destroy(gameObject);
        }
    }
}
