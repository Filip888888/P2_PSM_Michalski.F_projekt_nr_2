using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float rotationX = 0f;
    public float verticalSensitivity = 3f;
    public float horizontalSensitivity = 3f;
    public float minVerticalAngle = -60f;
    public float maxVerticalAngle = 60f;
    public GameObject Camera;
    public float rotatecamera = 0f;
    public float camera_rotate_angle = 90f;
    private Vector3 FirstPerson = new Vector3(0f, 1.5f, 0.2f);
    Movement_Controller movement;

    Vector3 offset;


   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = FirstPerson;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Camera.transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = player.transform.position + offset;

        if (Input.GetMouseButton(1))
        {

            float mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity;

            Camera.transform.RotateAround(player.position, Vector3.up, mouseX);

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

            Camera.transform.localEulerAngles = new Vector3(rotationX, Camera.transform.localEulerAngles.y, 0f);

        }
    }
}
