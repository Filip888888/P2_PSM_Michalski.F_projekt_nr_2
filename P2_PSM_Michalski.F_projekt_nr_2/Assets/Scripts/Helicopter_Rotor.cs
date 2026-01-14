using UnityEngine;

public class Helicopter_Rotor : MonoBehaviour
{
    public float speed = 400f;
    public float angle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
