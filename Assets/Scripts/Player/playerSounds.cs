using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds : MonoBehaviour
{
    private AudioSource currentSound;

    [SerializeField] private AudioClip[] library;

    private void Awake()
    {
        currentSound = GetComponent<AudioSource>();
    }
    ///<summary>
    ///0 = weapon pickup, 1 = ammo pickup
    ///</summary>
    public void PlaySound(int index)
    {
        currentSound.clip = library[index];
        currentSound.Play();
    }
}
