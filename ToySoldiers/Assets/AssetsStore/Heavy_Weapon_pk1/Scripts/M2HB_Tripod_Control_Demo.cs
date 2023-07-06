using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2HB_Tripod_Control_Demo : MonoBehaviour {

    public US_MachineGunner myGunner;
    public US_MG_Loader myLoader;
    public AmmoBelt myAmmoBelt;
    public AmmoBeltScroll myAmmoScroll;
    public ParticleSystem[] myFireFx;
    private AudioSource myAudio;
    public AudioClip fireLoopSound;
    public AudioClip ceaseFireSound;
    public AudioClip chargingHandleSound;


	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	
	public void FireGun()
    {
        foreach(ParticleSystem fx in myFireFx)
        {
            fx.Play();
        }
        myAmmoScroll.ScrollAmmo();
        myLoader.GunIsFiring();
        myAudio.clip = fireLoopSound;
        myAudio.loop = true;
        myAudio.Play();
    }

    public void CeaseFire()
    {
        foreach(ParticleSystem fx in myFireFx)
        {
            fx.Stop();
        }
        myAmmoScroll.StopAmmo();
        myLoader.CeaseFire();
        myAudio.clip = ceaseFireSound;
        myAudio.loop = false;
        myAudio.Play();
    }

    public void ChargeGun()
    {
        myGunner.ChargeGun();
        myAudio.clip = chargingHandleSound;
        myAudio.loop = false;
        myAudio.Play();
    }
   
}
