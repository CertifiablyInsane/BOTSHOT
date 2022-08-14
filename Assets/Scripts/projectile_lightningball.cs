using UnityEngine;

public class projectile_lightningball : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int[] inclusiveDamageAmount; //ex. [5, 40]
    public Vector3 destination;
    private Vector3 vectorAngleToPlayer;

    void Start()
    {
        vectorAngleToPlayer = CalculateVectorToPlayer();
    }
    private void FixedUpdate()
    {
        transform.Translate(vectorAngleToPlayer * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Geometry") //Walls and ground
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Player") //Target must be hurtable and not same type as self
        {
            int damageAmount = RollDamageNumbers(inclusiveDamageAmount[0], inclusiveDamageAmount[1]);
            collider.gameObject.BroadcastMessage("TakeDamage", damageAmount);
            Destroy(gameObject);
        }
    }
    private Vector3 CalculateVectorToPlayer()
    {
        Vector3 dir = destination - transform.position;
        dir = dir.normalized;
        return dir;
    }
    private int RollDamageNumbers(int lowValue, int highValue)
    {
        int value = Random.Range(lowValue, highValue + 1);
        return value;
    }
}
