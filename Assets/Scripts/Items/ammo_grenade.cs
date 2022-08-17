using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_grenade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().grenadeAmmo += 1;
            Destroy(gameObject);
        }
    }
}
