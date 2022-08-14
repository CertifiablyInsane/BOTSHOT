using UnityEngine;

public class projectile_handler : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int[] inclusiveDamageAmount; //ex. [5, 40]
    public Vector3 destination;
    private Vector3 vectorAngleToPlayer;
    public string projectileCreator;
    public string robotName;

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
        tags tags = collider.gameObject.GetComponent<tags>();
        if(tags.collideWithProjectiles && collider.gameObject.name != robotName) //Target must have collision on and not be itself
        {
            if(tags.hurtable && projectileCreator != tags.type) //Target must be hurtable and not same type as self
            {
                int damageAmount = RollDamageNumbers(inclusiveDamageAmount[0], inclusiveDamageAmount[1]);
                collider.gameObject.BroadcastMessage("TakeDamage", damageAmount);
            }
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
