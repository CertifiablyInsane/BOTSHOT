using UnityEngine;

public class player : MonoBehaviour
{
    public int health = 100;

    public int pistolAmmo;
    public int shotgunAmmo;
    public int grenadeAmmo;

    [SerializeField] private Transform cameraBody;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > 100)
        {
            health = 100;
        }
    }
    private void Die()
    {
        GetComponent<playerController>().enabled = false;
        cameraBody.position -= new Vector3(0, -1, 0); 
    }
}
