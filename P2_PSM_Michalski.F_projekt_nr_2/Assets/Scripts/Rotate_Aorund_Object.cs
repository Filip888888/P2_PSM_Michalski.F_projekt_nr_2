using UnityEngine;

public class Rotate_Aorund_Object : MonoBehaviour
{

    public Transform center;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, Vector3.up, speed*Time.deltaTime);
    }
}
