using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayerNew : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 2;
    Quaternion rotation;
    public float movementMultiplier;
    public float rotateSpeed = 0.5f;




    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0, horizontal * rotateSpeed, 0);
        Vector3 movement = new Vector3(0, 0, vertical);
        Vector3 forward = transform.TransformDirection( Vector3.forward);


        CharacterController characterController = GetComponent<CharacterController>();

        float speed = movementMultiplier * vertical;
        characterController.SimpleMove(forward * speed);
        animator.SetFloat("Speed", vertical);
    }

}
