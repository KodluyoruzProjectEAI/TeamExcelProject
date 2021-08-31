using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : ASingleton<SoundManager>
{
    [SerializeField] AudioSource superRunSound;
    void Awake()
    {
        StartSingleton(this);
    }
    public void PlaySuperRunSound()
    {
        if (!superRunSound.isPlaying)
        {
            superRunSound.Play();
        }
    }
}
