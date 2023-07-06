using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 2;
    public bool slerp;

    Quaternion rotation;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        CharacterController characterController = GetComponent<CharacterController>();
        characterController.SimpleMove(movement * moveSpeed);

        if (animator != null)
            animator.SetFloat("Speed", movement.magnitude);

        


        if (slerp) 
        {
            rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement, Vector3.up), 0.015f);

        }
        else
        {
            rotation = Quaternion.LookRotation(movement, Vector3.up);
        }

        if (movement.magnitude != 0)
        {
            transform.rotation = rotation;
        }

    }
}
