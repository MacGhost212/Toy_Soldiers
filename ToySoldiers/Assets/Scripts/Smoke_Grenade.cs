using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_Grenade : MonoBehaviour
{

    public float delay = 5f;


    public GameObject smokeEffect;

    float countdown;
    bool hasExplopde = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExplopde)
        {
            Explode();
            hasExplopde = true;
        }
    }

    void Explode()
    {
        //Debug.Log("Boom");
        Instantiate(smokeEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
