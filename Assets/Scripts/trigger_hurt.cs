using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_hurt : MonoBehaviour
{
    [SerializeField] float damageCooldownTime;
    [SerializeField] float damageAmount;
    [SerializeField] string[] damagableTags;

    private void OnTriggerEnter(Collider collider)
    {
        foreach(string tag in damagableTags)
        {
            if(collider.tag == tag)
            {
                StartCoroutine(EnableTrigger(collider));
                Debug.Log("Trigger Enabled");
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        foreach (string tag in damagableTags)
        {
            if (collider.tag == tag)
            {
                StopAllCoroutines();
                Debug.Log("Trigger Disabled");
            }
        }
    }
    private IEnumerator EnableTrigger(Collider collider)
    {
        while (true)
        {
            collider.BroadcastMessage("TakeDamage", damageAmount);
            Debug.Log("Damage Done");
            yield return new WaitForSeconds(damageCooldownTime);
        }
    }
}
