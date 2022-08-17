using UnityEngine;

public class ammo_pistol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().pistolAmmo += 8;
            Destroy(gameObject);
        }
    }
}
