using UnityEngine;

public class item_medikit : MonoBehaviour
{
    [SerializeField] private int healAmount = 25;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
