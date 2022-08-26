using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_turret : MonoBehaviour
{
    [SerializeField] private int avgDamage = 10;
    [SerializeField] private float range = 100f;
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

    private AudioSource currentSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hitbox = GetComponent<Collider>();
        currentSound = GetComponent<AudioSource>();
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
                    //A_ACTIVE();
                    break;
                case "A_FACEPLAYER":
                    //A_FACEPLAYER();
                    break;
                case "A_FIRE":
                    //A_FIRE();
                    break;
            }
        }
    }
    private void A_IDLE()
    {
        if(!Physics.Linecast(transform.position, playerPos.position))
        {
            //Player is visible
        }
    }
    private void OnPainTriggered()
    {
        StartCoroutine("SuspendAIForTime", 1f);
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
