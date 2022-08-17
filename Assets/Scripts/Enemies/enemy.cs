using System.Collections;
using UnityEngine;

public class enemy: MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private float painChance = 25f;
    public string targetName = "Player";

    private bool isDead = false;
    private bool painCooldown = true;

    public void TakeDamage(int amount)
    {
        RollPainChance(painChance);
        health -= amount;
        Debug.Log(health);
        if(health <= 0 && !isDead)
        {
            isDead = true;
            BroadcastMessage("OnDeath"); //tell ai code you're freaking dead
        }
    }

    private void RollPainChance(float painChance)
    {
        if(painCooldown)
        {
            float randomNum = Random.Range(0, 100);
            if(painChance > randomNum)
            {
                StartCoroutine("RunPainCooldown");
                BroadcastMessage("OnPainTriggered");
            }
        }
    }

    private IEnumerator RunPainCooldown()
    {
        painCooldown = false;
        yield return new WaitForSeconds(2.5f);
        painCooldown = true;
    }
}
