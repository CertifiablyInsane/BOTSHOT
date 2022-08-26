using System.Collections;
using UnityEngine;

public class weapon_shotgun : MonoBehaviour
{

    [SerializeField] private int avgDamage = 10;
    [SerializeField] private float range = 100f;
    [SerializeField] private float weaponFireCooldownTime = 0.75f;
    public bool weaponFireCooldown = true;
    [SerializeField] private Vector3 bulletSpead = new Vector3(0.125f, 0.125f, 0.125f);
    [SerializeField] private Vector3 altBulletSpead = new Vector3(0.04f, 0.025f, 0.04f);

    [SerializeField] private ParticleSystem shootingParticle;
    [SerializeField] private GameObject impactParticle;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private Transform player;
    [SerializeField] private Transform bulletSpawnPos;
    private playerController playerController;

    private Animator animator;
    private player playerScript;
    private AudioSource S_Fire;

    private void Awake()
    {
        playerController = player.GetComponent<playerController>();
        animator = GetComponent<Animator>();
        playerScript = player.GetComponent<player>();
        S_Fire = GetComponent<AudioSource>();
    }
    void Update()
    {
        animator.SetFloat("Velocity", player.GetComponent<CharacterController>().velocity.magnitude);
    }
    private void Shoot()
    {
        if(weaponFireCooldown)
        {
            if(playerScript.shotgunAmmo > 0)
            {
                playerScript.shotgunAmmo--;
                StartCoroutine(WeaponFireDelay());
                shootingParticle.Play();
                S_Fire.pitch = GetRandomPitch(1.0f);
                S_Fire.volume = 1.0f;
                S_Fire.Play();

                for (int i = 0; i < 8; i++) //8 pellets
                {
                    Vector3 direction = GetDirection();
                    RaycastHit hit;
                    //Cast hitscan ray
                    if (Physics.Raycast(bulletSpawnPos.position, direction, out hit, range))
                    {
                        TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPos.position, Quaternion.identity);
                        StartCoroutine(SpawnTrail(trail, hit));

                        int damageMod = Random.Range(-1, 2); //-1, 0, 1
                        int damage = avgDamage + damageMod * 5;
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.BroadcastMessage("TakeDamage", damage);
                        }

                    }
                }
            }
        }
    }
    private void Altfire()
    {
        if(weaponFireCooldown)
        {
            if(playerScript.shotgunAmmo > 0)
            {
                playerScript.shotgunAmmo--;
                StartCoroutine(WeaponAltfireDelay());
                shootingParticle.Play();
                S_Fire.pitch = GetRandomPitch(1.0f);
                S_Fire.volume = 0.6f;
                S_Fire.Play();

                for (int i = 0; i < 6; i++) //6 pellets
                {
                    Vector3 direction = GetAltfireDirection();
                    RaycastHit hit;
                    //Cast hitscan ray
                    if (Physics.Raycast(bulletSpawnPos.position, direction, out hit, range))
                    {
                        TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPos.position, Quaternion.identity);
                        StartCoroutine(SpawnTrail(trail, hit));

                        int damageMod = Random.Range(-1, 2); //-1, 0, 1
                        int damage = avgDamage + damageMod * 5;
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.BroadcastMessage("TakeDamage", damage);
                        }

                    }
                }
            }
        }
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = fpsCam.transform.forward;
        direction += new Vector3(
            Random.Range(-bulletSpead.x, bulletSpead.x),
            Random.Range(-bulletSpead.y, bulletSpead.y),
            Random.Range(-bulletSpead.z, bulletSpead.z)
            );
        direction.Normalize();
        return direction;
    }

    private Vector3 GetAltfireDirection()
    {
        Vector3 direction = fpsCam.transform.forward;
        direction += new Vector3(
            Random.Range(-altBulletSpead.x, altBulletSpead.x),
            Random.Range(-altBulletSpead.y, altBulletSpead.y),
            Random.Range(-altBulletSpead.z, altBulletSpead.z)
            );
        direction.Normalize();
        return direction;
    }
    private float GetRandomPitch(float f)
    {
        float value = Random.Range(-0.05f, 0.05f) + f;
        return value;
    }
    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;
        float distanceBetween = Vector3.Distance(startPosition, hit.point);

        while(time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += 1.5f / distanceBetween;

            yield return null;
        }
        trail.transform.position = hit.point;
        //Instantiate(impactParticle, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(trail.gameObject, 0.125f);

    }

    IEnumerator WeaponFireDelay()
    {
        weaponFireCooldown = false;
        animator.SetBool("Shooting", true);
        playerController.isOnWeaponCooldown = true;
        yield return new WaitForSeconds(weaponFireCooldownTime);
        weaponFireCooldown = true;
        animator.SetBool("Shooting", false);
        playerController.isOnWeaponCooldown = false;
    }

    IEnumerator WeaponAltfireDelay()
    {
        weaponFireCooldown = false;
        animator.SetBool("Altfire", true);
        playerController.isOnWeaponCooldown = true;
        yield return new WaitForSeconds(weaponFireCooldownTime);
        weaponFireCooldown = true;
        animator.SetBool("Altfire", false);
        playerController.isOnWeaponCooldown = false;
    }
}
