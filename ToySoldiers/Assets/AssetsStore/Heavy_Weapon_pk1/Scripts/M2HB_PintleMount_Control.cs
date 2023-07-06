using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2HB_PintleMount_Control : MonoBehaviour {

    public M2HB_PintleMount_Guy myShooter;
    public AmmoBeltScroll myAmmo;
    public ParticleSystem[] myParticles;
    private AudioSource myAudio;
    public AudioClip fireSound;
    public AudioClip stopFireSound;
    public AudioClip cockingSound;

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	
    public void Walk()
    {
        myShooter.Walk();
    }
    public void Fire()
    {
        myShooter.Fire();
        myAmmo.ScrollAmmo();
        foreach(ParticleSystem GunFx in myParticles)
        {
            GunFx.Play();
        }
        myAudio.clip = fireSound;
        myAudio.loop = true;
        myAudio.Play();
    }
    public void CeaseFire()
    {
        myShooter.CeaseFire();
        myAmmo.StopAmmo();
        foreach(ParticleSystem GunFx in myParticles)
        {
            GunFx.Stop();
        }
        myAudio.clip = stopFireSound;
        myAudio.loop = false;
        myAudio.Play();
    }
    public void StopWalking()
    {
        myShooter.StopWalking();
    }
    public void Charge()
    {
        myShooter.Charge();
        myAudio.clip = cockingSound;
        myAudio.loop = false;
        myAudio.Play();
    }
}
