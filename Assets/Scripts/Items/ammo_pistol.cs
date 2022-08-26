using UnityEngine;

public class ammo_pistol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().pistolAmmo += 8;
            other.gameObject.GetComponent<playerSounds>().PlaySound(1); //ammo pickup sound
            Destroy(gameObject);
        }
    }
}
