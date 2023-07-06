using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun_Loader : MonoBehaviour {

    private Animator myAnim;

    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();

    }

    public void GunIsFiring()
    {
        myAnim.SetBool("isFiring", true);
    }

    public void CeaseFire()
    {
        myAnim.SetBool("isFiring", false);
    }
}
