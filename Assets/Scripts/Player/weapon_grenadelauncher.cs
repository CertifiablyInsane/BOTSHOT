using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_grenadelauncher : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float weaponFireCooldownTime = 0.75f;
    [SerializeField] private float weaponAltfireCooldownTime = 2.5f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject gm;
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Camera fpsCam;

    private Animator animator;
    private playerController playerController;
    private player playerScript;
    public bool weaponFireCooldown = true;
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
            if(playerScript.grenadeAmmo > 0)
            {
                S_Fire.pitch = GetRandomPitch(1.0f);
                S_Fire.volume = 1.0f;
                S_Fire.Play();

                playerScript.grenadeAmmo--;
                StartCoroutine(WeaponFireDelay());
                GameObject newProjectile = Instantiate(projectile, bulletSpawnPos.position, fpsCam.transform.rotation, gm.transform);
            }
        }
    }
    private void Altfire()
    {
        if (weaponFireCooldown)
        {
            if(playerScript.grenadeAmmo >= 5)
            {
                playerScript.grenadeAmmo -= 5;
                StartCoroutine(WeaponAltfireDelay());
                StartCoroutine(AltfireShoot());
            }
        }
    }
    private float GetRandomPitch(float f)
    {
        float value = Random.Range(-0.05f, 0.05f) + f;
        return value;
    }
    IEnumerator AltfireShoot()
    {
        yield return new WaitForSeconds(1f);
        S_Fire.pitch = GetRandomPitch(0.8f);
        S_Fire.volume = 1.2f;
        S_Fire.Play();
        for (int i = 0; i < 5; i++)
        {
            GameObject newProjectile = Instantiate(projectile, bulletSpawnPos.position, fpsCam.transform.rotation, gm.transform);
            float spreadValue = (i - 2) * 0.075f;
            newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.right * spreadValue * 50f);
        }
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
