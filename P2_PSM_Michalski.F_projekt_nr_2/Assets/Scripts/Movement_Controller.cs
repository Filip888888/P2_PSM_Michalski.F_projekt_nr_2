using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.InputSystem;
//using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Movement_Controller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2f;
    public float thrust = 5f;
    private float jumpforce = 5f;
    public bool isClimbing = false;
    private bool isGrounded = true;
    private Transform cam;
    CameraController camControll;

    [SerializeField]
    Vector3 moveDIrection;
    [SerializeField]
    float moveX, moveZ;

    void Start()
    {
        camControll = FindObjectOfType<CameraController>();
        cam = camControll.Camera.transform;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        GetButtonToMove();
    }

    private void Update()
    {
     
    }

    void GetButtonToMove()
    {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
            Vector3 forward = cam.forward;
            Vector3 right = cam.right;

            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            moveDIrection = forward * moveZ + right * moveX;
            Vector3 newVelocity = moveDIrection * (speed + 3);
            newVelocity.y = rb.velocity.y;
            rb.velocity = newVelocity;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * (jumpforce - 2), ForceMode.Impulse);
                isGrounded = false;
            }

        if (isClimbing)
        {
            if (Input.GetKey(KeyCode.W) && isClimbing)
            {
                 rb.AddForce(Vector3.up * thrust);
            }

            if(Input.GetKey(KeyCode.S) && isClimbing)
            {
                rb.AddForce(Vector3.down * thrust);
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag("platform"))
        {
            transform.SetParent(collision.transform);
        }

        if (collision.gameObject.CompareTag("ladder"))
        {
            isClimbing = true;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("ladder"))
        {
            isClimbing = false;
        }

        if (collision.gameObject.CompareTag("platform"))
        {
            transform.SetParent(null);
        }

    }

}

 