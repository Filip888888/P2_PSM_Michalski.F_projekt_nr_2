using UnityEngine;


public class Rocket : MonoBehaviour
{

    private Transform back_rotor;
    public float speed = 20f;
    private Rigidbody bullet_rb;
    public GameObject fire;
    public Transform rocekt_position;
    public float health = 100f;
    Follor_Player_NavMesh helicopter;
    private float shoot_delay = 5f;
    [SerializeField]
    float shooted;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        back_rotor = GameObject.Find("Back_Rotor").transform;
        bullet_rb = GetComponent<Rigidbody>();
        transform.position = rocekt_position.position;
        helicopter = FindObjectOfType<Follor_Player_NavMesh>();
        shooted = 10f;
    }

    // Update is called once per fram
    void Update()
    {

        shooted += Time.deltaTime;

        Vector3 direction = (back_rotor.position - transform.position).normalized;

        if (shooted >= shoot_delay)
        {
            bullet_rb.velocity = direction * speed;
        }

        if(health <= 0f)
        {
            transform.position = rocekt_position.position;
            shooted = 0f;
            bullet_rb.velocity = Vector3.zero;
            health = 100f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Back_Rotor")
        {
            transform.position = rocekt_position.position;

            helicopter.health -= 20f;

            shooted = 10f;

            //Destroy(gameObject);
        }
            fire.SetActive(true);
    }

}
