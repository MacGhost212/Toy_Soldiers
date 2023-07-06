using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermanFlaK38_Loader : MonoBehaviour {

    private Animator myAnim;
    public Rigidbody emptyMag;
    public float magThrowSpeed = 100f;
    public Transform magThrower;
    private AudioSource myAudio;
    public AudioClip cockingSound;
	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
	}
	
	public void ReloadGun()
    {
        myAnim.SetTrigger("reload");
    }

    public void ProduceEmptyShell()
    {
        Rigidbody emptyShellInstance;
        emptyShellInstance = Instantiate(emptyMag, magThrower.position, magThrower.rotation) as Rigidbody;
        emptyShellInstance.AddForce(magThrower.forward * magThrowSpeed);
    }

    public void MakeCockingSound()
    {
        myAudio.clip = cockingSound;
        myAudio.Play();
    }
}
