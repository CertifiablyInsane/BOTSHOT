using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class func_button : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private string[] outputs;
    [SerializeField] private float[] timeDelays;
    [SerializeField] private bool canBePressedMoreThanOnce= false;
    [SerializeField] private float timeBeforeReset = 3.0f;
    [SerializeField] private bool active = true;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.tag = "Usable";
    }

    public void OnUsed()
    {
        if(active)
        {
            audioSource.Play();
            int i = 0;
            foreach(GameObject target in targets)
            {
                if(timeDelays[i] > 0) //If output should have a time delay
                {
                    StartCoroutine(CallAfterDelay(target, outputs[i], timeDelays[i]));
                }
                else
                {
                    target.BroadcastMessage(outputs[i]); //If there's no time delay, call it immediately
                }
                i++;
            }
            active = false;
            if(canBePressedMoreThanOnce)
            {
                StartCoroutine(ResetButton());
            }
        }
    }

    //calls output after given time
    private IEnumerator CallAfterDelay(GameObject target, string output, float time)
    {
        yield return new WaitForSeconds(time);
        target.BroadcastMessage(output);
    }
    private IEnumerator ResetButton()
    {
        yield return new WaitForSeconds(timeBeforeReset);
        active = true;
    }
}
