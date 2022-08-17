using System.Collections;
using UnityEngine;

public class weapon_pistol : MonoBehaviour
{

    [SerializeField] private int avgDamage = 10;
    [SerializeField] private float range = 100f;
    [SerializeField] private float weaponFireCooldownTime = 0.50f;
    [SerializeField] private float weaponAltfireCooldownTime = 0.167f;
    [SerializeField] private Vector3 altBulletSpead = new Vector3(0.01f, 0.01f, 0.01f);
    public bool weaponFireCooldown = true;

    [SerializeField] private ParticleSystem shootingParticle;
    [SerializeField] private GameObject impactParticle;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private Transform player;
    [SerializeField] private Transform bulletSpawnPos;

    private Animator animator;
    private playerController playerController;
    private player playerScript;


    private void Awake()
    {
        playerController = player.GetComponent<playerController>();
        animator = GetComponent<Animator>();
        playerScript = player.GetComponent<player>();
    }
    void Update()
    {
        animator.SetFloat("Velocity", player.GetComponent<CharacterController>().velocity.magnitude);
    }
    private void Shoot()
    {
        if (weaponFireCooldown)
        {
            //requires no ammo to use
            StartCoroutine(WeaponFireDelay());
            shootingParticle.Play();

            //fire single bullet
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
    private void Altfire()
    {
        if(weaponFireCooldown)
        {
            if(playerScript.pistolAmmo > 0)
            {
                playerScript.pistolAmmo--;
                StartCoroutine(WeaponAltfireDelay());
                shootingParticle.Play();

                Vector3 direction = GetAltfireDirection();
                RaycastHit hit;

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
            else
            {
                //out of ammo
            }
        }
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = fpsCam.transform.forward;
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
        yield return new WaitForSeconds(weaponAltfireCooldownTime);
        weaponFireCooldown = true;
        animator.SetBool("Altfire", false);
        playerController.isOnWeaponCooldown = false;
    }
}
