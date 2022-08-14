using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour
{
    [SerializeField] private GameObject gm;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject gameticCounter;
    [SerializeField] private GameObject healthCounter;

    private Text gameticText;
    private Text healthText;
    private void Start()
    {
        gameticText = gameticCounter.GetComponent<Text>();
        healthText = healthCounter.GetComponent<Text>();
    }
    void Update()
    {        
        gameticText.text = "gametic " + Time.frameCount.ToString();
        healthText.text = "HEALTH " + player.GetComponent<player>().health.ToString();
    }
}
