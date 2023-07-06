using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBelt : MonoBehaviour {

    
    public Transform gunBarrel;
    private Animator myAnim;
    public float aimpointVal = .5f;
    public float azmuth = 0f;
    

    // Use this for initialization
    void Start () {
        myAnim = GetComponent<Animator>();
       

    }
	
	// Update is called once per frame
	void Update () {
        azmuth = gunBarrel.transform.localEulerAngles.y;
        if (azmuth > 200f)
        {
            azmuth = azmuth - 360f;
        }
        aimpointVal = Mathf.InverseLerp(-30, 30, azmuth);

        myAnim.SetFloat("aimpoint", aimpointVal);

	}

    public void Firing()
    {
        myAnim.SetBool("isfiring", true);
    }

    public void Ceasefire()
    {
        myAnim.SetBool("isfiring", false);
    }
}
