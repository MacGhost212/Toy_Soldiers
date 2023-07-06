using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpentShell : MonoBehaviour {

    Vector3 torque;
    private Rigidbody rb;
    public float torqueAmount = 200f;
    public AudioClip crashSoft;
    public AudioClip crashHard;
    private AudioSource myAudio;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        torque.x = Random.Range(-torqueAmount*2f, torqueAmount*2f);
        torque.y = Random.Range(-torqueAmount, torqueAmount);
        torque.z = Random.Range(-torqueAmount, torqueAmount);
        rb.AddTorque(torque);
    }

    void OnCollisionEnter(Collision coll)
    {
        myAudio.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = coll.relativeVelocity.magnitude * velToVol;
        if (coll.relativeVelocity.magnitude < velocityClipSplit)
             myAudio.PlayOneShot(crashSoft, hitVol);
        else 
            myAudio.PlayOneShot(crashHard, hitVol);
    }


}
