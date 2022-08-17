using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour
{
    [SerializeField] private GameObject gm;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject gameticCounter;
    [SerializeField] private GameObject healthCounter;
    [SerializeField] private GameObject ammoCounter;

    private Text gameticText;
    private Text healthText;
    private Text ammoText;

    private player playerScript;
    private playerInventory playerInventory;

    public string activeWeapon = "Pistol";
    private void Start()
    {
        gameticText = gameticCounter.GetComponent<Text>();
        healthText = healthCounter.GetComponent<Text>();
        ammoText = ammoCounter.GetComponent<Text>();
        playerScript = player.GetComponent<player>();
    }
    void Update()
    {        
        gameticText.text = "gametic " + Time.frameCount.ToString();
        healthText.text = "HEALTH " + playerScript.health.ToString();

        switch(activeWeapon)
        {
            case "Pistol":
                ammoText.text = playerScript.pistolAmmo.ToString();
                break;
            case "Shotgun":
                ammoText.text = playerScript.shotgunAmmo.ToString();
                break;
            case "GrenadeLauncher":
                ammoText.text = playerScript.grenadeAmmo.ToString();
                break;
        }
    }
}
