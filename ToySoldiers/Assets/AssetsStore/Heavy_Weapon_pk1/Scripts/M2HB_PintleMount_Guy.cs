using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2HB_PintleMount_Guy : MonoBehaviour {

    private Animator myAnim;

	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
		
	}
	
	public void Walk()
    {
        myAnim.SetBool("walk", true);
    }
    public void StopWalking()
    {
        myAnim.SetBool("walk", false);
    }
    public void Fire()
    {
        myAnim.SetBool("fire", true);
    }
    public void CeaseFire()
    {
        myAnim.SetBool("fire", false);
    }
    public void Charge()
    {
        myAnim.SetTrigger("charge");
    }
}
