using UnityEngine;

public class Rocket_Zombie : MonoBehaviour
{

    private Transform back_rotor;
    public float health = 200f;
    GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        back_rotor = GameObject.Find("Back_Rotor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(back_rotor.position);

        if(health <= 0f)
        {
            manager.kill_count++;
            Destroy(gameObject);
        }

    }
}
