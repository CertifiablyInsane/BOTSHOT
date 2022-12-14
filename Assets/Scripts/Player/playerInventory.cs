using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public bool hasPistol;
    public bool hasShotgun;
    public bool hasGrenadeLauncher;

    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject grenadeLauncher;

    [SerializeField] ui_manager UIManager;

    private weapon_pistol pistolScript;
    private weapon_shotgun shotgunScript;
    private weapon_grenadelauncher grenadeLauncherScript;

    private void Start()
    {
        pistolScript = pistol.GetComponent<weapon_pistol>();
        shotgunScript = shotgun.GetComponent<weapon_shotgun>();
        grenadeLauncherScript = grenadeLauncher.GetComponent<weapon_grenadelauncher>();

        pistol.SetActive(true); //make this pistol later when it is in the game
    }

    public void WeaponSwap(string weapon)
    {
        StopAllCoroutines();
        switch(weapon)
        {
            case "Pistol":
                if (hasPistol)
                {
                    StartCoroutine("Pistol");
                }
                break;
            case "Shotgun":
                if(hasShotgun)
                {
                    StartCoroutine("Shotgun");
                }
                break;
            case "GrenadeLauncher":
                if(hasGrenadeLauncher)
                {
                    StartCoroutine("GrenadeLauncher");
                }
                break;
        }
    }
    private void Pistol()
    {
        if(hasPistol)
        {
            DisableAll();
            pistol.SetActive(true);
            UIManager.activeWeapon = "Pistol";
        }
    }
    private void Shotgun()
    {
        if(hasShotgun)
        {
            DisableAll();
            shotgun.SetActive(true);
            UIManager.activeWeapon = "Shotgun";
        }
    }
    private void GrenadeLauncher()
    {
        if(hasGrenadeLauncher)
        {
            DisableAll();
            grenadeLauncher.SetActive(true);
            UIManager.activeWeapon = "GrenadeLauncher";
        }
    }
    private void DisableAll()
    {
        pistol.SetActive(false);
        shotgun.SetActive(false);
        grenadeLauncher.SetActive(false);
    }

}
