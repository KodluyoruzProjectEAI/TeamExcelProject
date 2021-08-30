using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem splash;
    
    [SerializeField] ParticleSystem speedParticle;

    public void PlaySplash()
    {
        splash.Play();
    }
    
    public void PlaySpeedParticle()
    {
        speedParticle.Play();
    }
}
