using System.Collections;
using UnityEngine;

public class grenade : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject gm;
    [SerializeField] private int fireForce = 40;
    [SerializeField] private float fuseTime = 1.5f;
    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private int explosionMaxDamage = 80;
    [SerializeField] private GameObject explosionParticle;

    private bool airborne = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.AddForce(transform.forward * fireForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(airborne) //only call this once
        {
            airborne = false;
            if(collision.gameObject.tag == "Enemy")
            {
                //Explode instantly
                string directHitTargetName = collision.gameObject.name;
                Explode(directHitTargetName);
            }
            else
            {
                StartCoroutine(explodeAfterTime());
            }
        }
    }

    private IEnumerator explodeAfterTime()
    {
        yield return new WaitForSeconds(fuseTime);
        Explode(null);
    }

    private void Explode(string directHitTargetName)
    {
        explosionParticle.GetComponent<ParticleSystem>().Play();
        string[] validLayers = {"Enemy", "Player"};
        LayerMask mask = LayerMask.GetMask(validLayers);
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius, mask);
        foreach (Collider target in targets)
        {
            if(target.name != directHitTargetName) //indirect damage
            {
                float distanceBetween = Mathf.Clamp(Vector3.Distance(transform.position, target.transform.position), 0f, 2.5f); //return distance clamped to 2.5f
                Debug.Log(distanceBetween);
                int damage = Mathf.RoundToInt(explosionMaxDamage - explosionMaxDamage * (distanceBetween / explosionRadius));
                target.gameObject.BroadcastMessage("TakeDamage", damage); //min damage 13, max damage 80
            }
            else //direct damage
            {
                target.gameObject.BroadcastMessage("TakeDamage", explosionMaxDamage);
            }
        }
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }
}
