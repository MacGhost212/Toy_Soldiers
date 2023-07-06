using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTester : MonoBehaviour {
    private AudioSource myAudio;
    public ParticleSystem[] gunFx;
    public AudioClip fireSound;
    public bool inZone = false;
    public bool isFiring = false;
    public Rigidbody mortarPrefab;
    public Transform mortarBarrelEnd;
    public float shellVelocity = 1000f;
    public float azmuthSlop = 10f;
    private Quaternion originalBarrelEndRot;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        originalBarrelEndRot = mortarBarrelEnd.rotation;
    }

    private void Update()
    {
        if (inZone)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }
    }


    public void Fire()
    {
        isFiring = true;
        myAudio.clip = fireSound;
        myAudio.loop = false;
        myAudio.Play();
        foreach (ParticleSystem fire in gunFx)
        {
            fire.Play();

        }

        ShootMortarRound();
    }

    public void ShootMortarRound()
    {
        float randomSlop = Random.Range(-azmuthSlop, azmuthSlop);
        Quaternion slop = Quaternion.Euler(randomSlop, Random.Range(-azmuthSlop, azmuthSlop), 0);
        mortarBarrelEnd.rotation = mortarBarrelEnd.rotation * slop;
        Rigidbody emptyShellInstance;
        emptyShellInstance = Instantiate(mortarPrefab, mortarBarrelEnd.position, (mortarBarrelEnd.rotation)) as Rigidbody;
        emptyShellInstance.AddForce(mortarBarrelEnd.forward * shellVelocity);
        mortarBarrelEnd.rotation = originalBarrelEndRot;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inZone = false;
        }
    }
}
