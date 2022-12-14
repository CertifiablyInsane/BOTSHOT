using UnityEngine;

public class item_grenadelauncher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().grenadeAmmo += 5;
            other.gameObject.GetComponent<playerInventory>().hasGrenadeLauncher = true;
            other.gameObject.GetComponent<playerInventory>().WeaponSwap("GrenadeLauncher");
            other.gameObject.GetComponent<playerSounds>().PlaySound(0); //weapon pickup sound
            Destroy(gameObject);
        }
    }
}
