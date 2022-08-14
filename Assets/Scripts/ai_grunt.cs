using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_grunt : MonoBehaviour
{
    [SerializeField] GameObject gm;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject ragdoll;

    private NavMeshAgent navAgent;
    private Animator animator;
    private CapsuleCollider hitbox;
    private string behaviourState = "A_IDLE";
    private bool AIUpdatesEnabled = true;
    private int attackCooldown = 60;
    private int projectileID = 0;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent >();
        animator = GetComponent<Animator>();
        hitbox = GetComponent<CapsuleCollider>();
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
                case "A_MELEE":
                    //A_MELEE();
                    break;
                case "A_DEATH":
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
            animator.SetBool("Active", true);
        }
        else
        {
            StartCoroutine("SuspendAIForTime", 0.25f);
        }
    }

    private void A_CHASE()
    {
        navAgent.isStopped = false;
        animator.SetBool("Attacking", false);
        animator.SetBool("Pain", false);
        navAgent.SetDestination(playerPos.position);
        DecrementAndTryAttack();
    }

    private void A_ATTACK()
    {
        navAgent.isStopped = true;
        StartCoroutine("FireProjectile");
        StartCoroutine("SuspendAIForTime", 2.125f);
        behaviourState = "A_CHASE";
    }
    private void DecrementAndTryAttack()
    {
        if (attackCooldown == 0)
        {
            float distanceFromTarget = Vector3.Distance(transform.position, playerPos.position);
            attackCooldown += 30; //try again in 30 tics
            if (1f / distanceFromTarget * 2.5f > Random.Range(0f, 1f)) //at 5 it's 50%, at 10 it's 25%, etc.
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
        StartCoroutine("SuspendAIForTime", 2f);
        StartCoroutine("PainStun");
    }

    private void OnDeath()
    {
        GameObject newRagdoll = Instantiate(ragdoll, transform.position, transform.rotation, GameObject.Find("gm").transform);
        newRagdoll.GetComponent<Rigidbody>().AddExplosionForce(15f, newRagdoll.transform.position, 1f, 0.2f);
        newRagdoll.GetComponent<Rigidbody>().AddForce(-newRagdoll.transform.forward * 25f);
        newRagdoll.GetComponent<Rigidbody>().AddTorque(-newRagdoll.transform.right * 5f);
        Destroy(gameObject);
    }

    private IEnumerator FireProjectile()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + hitbox.height / 2, transform.position.z);
        animator.SetBool("Pain", false);
        animator.SetBool("Attacking", true);

        yield return new WaitForSeconds(0.75f);
        GameObject newProjectile = Instantiate(projectile, spawnPos, Quaternion.identity, GameObject.Find("gm").transform);
        newProjectile.name = transform.name + " Projectile " + projectileID;
        projectileID++;
        string targetName = GetComponentInChildren<enemy>().targetName;
        newProjectile.GetComponent<projectile_lightningball>().destination = GameObject.Find(targetName).transform.position;
        attackCooldown = Random.Range(120, 300);
    }

    private IEnumerator PainStun()
    {
        animator.SetBool("Attacking", false);
        animator.SetBool("Pain", true);
        navAgent.isStopped = true;
        yield return new WaitForSeconds(2f);
        behaviourState = "A_ATTACK";
    }
    private IEnumerator SuspendAIForTime(float suspensionTime) //suspend AI for time in seconds
    {
        AIUpdatesEnabled = false;
        yield return new WaitForSeconds(suspensionTime);
        AIUpdatesEnabled = true;
    }
}
