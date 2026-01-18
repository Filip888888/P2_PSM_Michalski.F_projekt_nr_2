using UnityEngine;


public class Rocket : MonoBehaviour
{

    private Transform back_rotor;
    public float speed = 20f;
    private Rigidbody bullet_rb;
    public GameObject fire;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        back_rotor = GameObject.Find("Back_Rotor").transform;
        bullet_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (back_rotor.position - transform.position).normalized;
        bullet_rb.velocity = direction * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Back_Rotor")
        {
            Destroy(gameObject);
        }

        fire.SetActive(true);

    }

}
