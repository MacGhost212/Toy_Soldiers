using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaK38_Gunner : MonoBehaviour {

    private Animator myAnim;

	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveTurretRight()
    {
        myAnim.SetBool("right", true);
    }

    public void MoveTurretLeft()
    {
        myAnim.SetBool("left", true);
    }

    public void StopMoving()
    {
        myAnim.SetBool("right", false);
        myAnim.SetBool("left", false);
    }
}
