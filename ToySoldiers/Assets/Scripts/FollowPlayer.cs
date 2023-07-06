using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;

    int MaxDist = 5;
    int MinDist = 1;
    Animator animator;
    public NavMeshAgent navMeshAgent;
    public float movementMultuplier;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.SetDestination(Player.transform.position);
        }
    }

    void Update()
    {
        //float vertical = Input.GetAxis("Vertical");

        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            //transform.position += transform.forward * Movespeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) >= MaxDist)
            {

            }
        }

        //float currentSpeed = movementMultuplier * vertical;
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
    }
}
