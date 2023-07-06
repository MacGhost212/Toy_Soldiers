using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    LineRenderer laserLineRenderer;
    public float laserWidth;
    public Transform firePoint;
    private float nextFire;

    [Range(0.1f, 10.5f)]
    public float fireRate;

    [Range(5, 15)]
    public int damage = 1;

    [SerializeField]
    private AudioSource gunFireSound;

    [SerializeField]
    private ParticleSystem muzzleFlash;

    public float impactForce = 30f;

    public bool laserBolt;
    RaycastHit hit;

    public int counter;


    void Start()
    {
        fireRate = 0.25f;

        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
    }
    void FixedUpdate()
    {
        //Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
    }
    void fireRifle()
    {
        gunFireSound.Play();
        muzzleFlash.Play();
        counter = 1;

        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        
        //laserLineRenderer.SetPosition(0, firePoint.position);
        //laserLineRenderer.SetPosition(1, firePoint.position + firePoint.forward * 100);
       
        StartCoroutine(ActivateLaser());

       //Ray ray = Camera.main.ViewportToRay(Vector3.one * 0.5f);
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fireRifle();
            

            {
                if (Physics.Raycast(transform.position, transform.forward * 50, out hit, 1000))
                {
                    Debug.Log("Hit");
                    Health health = hit.collider.gameObject.GetComponent<Health>();

                    if (health != null)
                    {
                        health.TakeDamage(damage);
                    }

                    var Boxhealth = hit.collider.gameObject.GetComponent<BoxHealth>();

                    if (Boxhealth != null)
                    {
                        Boxhealth.TakeDamage(damage);
                    }

                }
                else
                {
                    Debug.Log("Miss");
                }
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        
        }
    }
    IEnumerator ActivateLaser()
    {
        if (laserBolt)
        {
            float laserDistance = 0;

            if (hit.distance == 0)
            {
                laserDistance = 100;
            }
            else
            {
                laserDistance = hit.distance;
            }

            while (counter <= laserDistance)
            {
                laserLineRenderer.enabled = true;
                laserLineRenderer.SetPosition(0,  firePoint.position + firePoint.forward * counter);
                laserLineRenderer.SetPosition(1,  firePoint.position + firePoint.forward * (counter + 1));

                counter++;
                yield return new WaitForSeconds(0.1f);
                laserLineRenderer.enabled = false;

            }

            laserLineRenderer.SetPosition(0, firePoint.position);
        }

        else
        {
            laserLineRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            laserLineRenderer.enabled = false;
        }
    }
   
}
