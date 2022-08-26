using UnityEngine;

public class item_shotgun : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().shotgunAmmo += 8;
            other.gameObject.GetComponent<playerInventory>().hasShotgun = true;
            other.gameObject.GetComponent<playerInventory>().WeaponSwap("Shotgun");
            other.gameObject.GetComponent<playerSounds>().PlaySound(0); //weapon pickup sound
            Destroy(gameObject);
        }
    }
}
