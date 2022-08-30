using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_gunner : MonoBehaviour
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
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private AudioClip[] soundLibrary;

    private NavMeshAgent navAgent;
    private Animator animator;
    private CapsuleCollider hitbox;
    private string behaviourState = "A_IDLE";
    private bool AIUpdatesEnabled = true;
    private int attackCooldown = 60;
    private int projectileID = 0;

    private AudioSource currentSound;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        hitbox = GetComponent<CapsuleCollider>();
        currentSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (AIUpdatesEnabled)
        {
            switch (behaviourState)
            {
                case "A_IDLE":
                    A_IDLE();
                    break;
                case "A_CHASE":
                    A_CHASE();
                    break;
                case "A_ATTACK":
                    A_ATTACK();
                    break;
            }
        }
    }
    private void A_IDLE()
    {
        float angle = GetAngleFromPlayer(transform.position, playerPos.position);
        if (angle > 5.1051f | angle < 1.1781f)
        {
            behaviourState = "A_CHASE";
        }
        else
        {
            StartCoroutine("SuspendAIForTime", 0.25f);
        }
    }

    private void A_CHASE()
    {
        navAgent.isStopped = false;
        navAgent.SetDestination(playerPos.position);
        currentSound.clip = soundLibrary[0];
        currentSound.loop = true;
        if (!currentSound.isPlaying)
        {
            currentSound.Play();
        }
        DecrementAndTryAttack();
    }

    private void A_ATTACK()
    {
        navAgent.isStopped = true;
        currentSound.clip = soundLibrary[1];
        currentSound.loop = false;
        currentSound.Play();
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
        StartCoroutine("SuspendAIForTime", 1.0625f);
        behaviourState = "A_CHASE";
        attackCooldown = Random.Range(120, 300);
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        direction += new Vector3(
            Random.Range(-bulletSpread.x, bulletSpread.x),
            Random.Range(-bulletSpread.y, bulletSpread.y),
            Random.Range(-bulletSpread.z, bulletSpread.z)
            );
        direction.Normalize();
        return direction;
    }
    private void DecrementAndTryAttack()
    {
        if (attackCooldown == 0)
        {
            float distanceFromTarget = Vector3.Distance(transform.position, playerPos.position);
            attackCooldown += 30; //try again in 30 tics
            if (1f / distanceFromTarget * 4f > Random.Range(0f, 1f)) //at 5 it's 50%, at 10 it's 25%, etc.
            {
                behaviourState = "A_ATTACK";
            }

        }
        else
        {
            attackCooldown--;
        }
    }
    private float GetAngleFromPlayer(Vector3 myPos, Vector3 playerPos)
    {
        float distX = playerPos.x - myPos.x;
        float distZ = playerPos.z - myPos.z;
        float tanAngle = Mathf.Atan2(distZ, distX) - 1.57f + (Mathf.Deg2Rad * transform.eulerAngles.y); //angle to player - pi/2 + rotation in rads
        if (tanAngle >= 6.28)
        {
            tanAngle -= 6.28f;
        }
        else if (tanAngle < 0)
        {
            tanAngle += 6.28f;
        }

        return tanAngle;

    }
    private void OnPainTriggered()
    {
        StartCoroutine("SuspendAIForTime", 1f);
        StartCoroutine("PainStun");
    }

    private void OnDeath()
    {
        GameObject newRagdoll = Instantiate(ragdoll, transform.position, transform.rotation, GameObject.Find("gm").transform);
        Rigidbody[] gibs = newRagdoll.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody gib in gibs)
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
        navAgent.isStopped = true;
        yield return new WaitForSeconds(1f);
        behaviourState = "A_ATTACK";
    }
    private IEnumerator SuspendAIForTime(float suspensionTime) //suspend AI for time in seconds
    {
        AIUpdatesEnabled = false;
        yield return new WaitForSeconds(suspensionTime);
        AIUpdatesEnabled = true;
    }
}
