using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_turret : MonoBehaviour
{
    [SerializeField] private int avgDamage = 10;
    [SerializeField] private float range = 100f;
    [SerializeField] private float turnSpeed = 2f;
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private ParticleSystem shootingParticle;
    [SerializeField] private GameObject impactParticle;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private Vector3 bulletSpread = new Vector3(0.03f, 0.03f, 0.03f);

    [SerializeField] GameObject gm;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private AudioClip[] soundLibrary;

    private Animator animator;
    private Collider hitbox;
    private string behaviourState = "A_IDLE";
    private bool AIUpdatesEnabled = true;
    private int attackCooldown = 60;
    private LayerMask visionMask;

    private AudioSource currentSound;

    //MANUAL ANIMATION BODY PARTS
    [SerializeField] private Transform B_Connector;
    [SerializeField] private Transform B_Neck;
    [SerializeField] private Transform B_Head;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hitbox = GetComponent<Collider>();
        currentSound = GetComponent<AudioSource>();
        visionMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if(AIUpdatesEnabled)
        {
            switch(behaviourState)
            {
                case "A_IDLE":
                    A_IDLE();
                    break;
                case "A_ACTIVE":
                    A_ACTIVE();
                    break;
            }
        }
    }
    private void A_IDLE()
    {
        if(Physics.Linecast(transform.position, playerPos.position, visionMask))
        {
            behaviourState = "A_ACTIVE"; //Wake up!
        }
        else
        {
            StartCoroutine(SuspendAIForTime(0.25f)); //Check again in 0.25 seconds
        }
    }
    private void A_ACTIVE()
    {
        if (!Physics.Linecast(transform.position, playerPos.position, visionMask))
        {
            RaycastHit hit;
            if(Physics.Raycast(bulletSpawnPos.position, B_Head.forward, out hit, range))
            {
                if(hit.transform.tag == "Player")
                {
                    A_FIRE();
                }
                else
                {
                    A_FACEPLAYER();
                }
            }
        }
        else
        {
            A_FACEFRONT();
        }
    }
    private void A_FACEPLAYER()
    {
        Vector3 targetDirection = playerPos.position - transform.position;
        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(B_Connector.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        B_Connector.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0f, newDirection.z));
    }
    private void A_FACEFRONT()
    {

    }

    private void A_FIRE()
    {
        StartCoroutine(SuspendAIForTime(0.5f));
        currentSound.Play();
        Vector3 direction = GetDirection();
        RaycastHit hit;
        //Cast hitscan ray
        if (Physics.Raycast(bulletSpawnPos.position, direction, out hit, range))
        {
            TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPos.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));

            int damageMod = Random.Range(-1, 2); //-1, 0, 1
            int damage = avgDamage + damageMod * 5;
            if (hit.transform.tag == "Player")
            {
                hit.transform.BroadcastMessage("TakeDamage", damage);
            }

        }
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = B_Head.forward;
        direction += new Vector3(
            Random.Range(-bulletSpread.x, bulletSpread.x),
            Random.Range(-bulletSpread.y, bulletSpread.y),
            Random.Range(-bulletSpread.z, bulletSpread.z)
            );
        direction.Normalize();
        return direction;
    }
    private void OnPainTriggered()
    {
        StartCoroutine(SuspendAIForTime(1f));
        StartCoroutine(PainStun());
    }
    private void OnDeath()
    {
        GameObject newRagdoll = Instantiate(ragdoll, transform.position, B_Head.rotation, GameObject.Find("gm").transform);
        Rigidbody[] gibs = newRagdoll.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody gib in gibs)
        {
            gib.AddExplosionForce(15f, newRagdoll.transform.position, 1f, 0.2f);
            gib.AddForce(-newRagdoll.transform.forward * 25f);
            gib.AddTorque(-newRagdoll.transform.right * 5f);
        }
        Destroy(gameObject);
    }
    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;
        float distanceBetween = Vector3.Distance(startPosition, hit.point);

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += 1.5f / distanceBetween;

            yield return null;
        }
        trail.transform.position = hit.point;
        //Instantiate(impactParticle, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(trail.gameObject, 0.125f);

    }
    private IEnumerator PainStun()
    {
        animator.SetBool("Attacking", false);
        animator.SetBool("Pain", true);
        yield return new WaitForSeconds(1f);
        behaviourState = "A_ACTIVE";
    }
    private IEnumerator SuspendAIForTime(float suspensionTime) //suspend AI for time in seconds
    {
        AIUpdatesEnabled = false;
        yield return new WaitForSeconds(suspensionTime);
        AIUpdatesEnabled = true;
    }
}
