using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem splash;

    public void PlaySplash()
    {
        splash.Play();
    }
}
