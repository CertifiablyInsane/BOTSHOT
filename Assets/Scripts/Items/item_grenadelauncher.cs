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
            Destroy(gameObject);
        }
    }
}
