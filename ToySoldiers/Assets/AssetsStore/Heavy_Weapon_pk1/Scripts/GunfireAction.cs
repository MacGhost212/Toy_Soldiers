using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunfireAction : MonoBehaviour {

    private AudioSource myAudio;
    public ParticleSystem[] gunFx;
    public AudioClip fireSound;
    public AudioClip CeaseFireSound;
    public bool isFiring = false;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    

    public void Fire()
    {
        isFiring = true;
        myAudio.clip = fireSound;
        myAudio.loop = true;
        myAudio.Play();
        foreach (ParticleSystem fire in gunFx)
        {
            fire.Play();

        }
    }

    public void CeaseFire()
    {
        isFiring = false;
        myAudio.clip = CeaseFireSound;
        myAudio.loop = false;
        myAudio.Play();
        foreach (ParticleSystem fire in gunFx)
        {
            fire.Stop();

        }

    }
}
