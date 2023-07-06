using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaK38_Control : MonoBehaviour {


    private AudioSource myAudio;
    public ParticleSystem[] myParticles;
    public AudioClip fireLoop;
    public AudioClip finishFiring;
    public FlaK38_Gunner myGunner;
    public GermanFlaK38_Loader myLoader;
	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
    }
   
    public void CeaseFire()
    {
        foreach(ParticleSystem fx in myParticles)
        {
            fx.Stop();
        }
        myAudio.clip = finishFiring;
        myAudio.loop = false;
        myAudio.Play();
    }
    public void FIRE_LongBurst()
    {
        foreach (ParticleSystem fx in myParticles)
        {
            fx.Play();
        }
        myAudio.clip = fireLoop;
        myAudio.loop = true;
        myAudio.Play();
    }

    public void RotateRight()
    {
        myGunner.MoveTurretRight();
    }

    public void RotateLeft()
    {
        myGunner.MoveTurretLeft();
    }

    public void STOPMovement()
    {
        myGunner.StopMoving();
    }

    public void ReloadGun()
    {
        myLoader.ReloadGun();
    }
}
