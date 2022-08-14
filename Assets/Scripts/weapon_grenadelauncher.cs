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
    public bool weaponFireCooldown = true;


    private void Awake()
    {
        playerController = player.GetComponent<playerController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetFloat("Velocity", player.GetComponent<CharacterController>().velocity.magnitude);
    }
    private void Shoot()
    {
        if(weaponFireCooldown)
        {
            StartCoroutine(WeaponFireDelay());
            GameObject newProjectile = Instantiate(projectile, bulletSpawnPos.position, fpsCam.transform.rotation, gm.transform);
        }
    }
    private void Altfire()
    {
        if (weaponFireCooldown)
        {
            StartCoroutine(WeaponAltfireDelay());
            for(int i = 0; i < 5; i++)
            {
                GameObject newProjectile = Instantiate(projectile, bulletSpawnPos.position, fpsCam.transform.rotation, gm.transform);
                float spreadValue = (i - 2) * 0.1f;
                newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.right * spreadValue * 50f);
            }
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
