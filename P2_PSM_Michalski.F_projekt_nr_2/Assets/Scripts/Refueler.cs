using UnityEngine;
using System;

public class Refueler : MonoBehaviour
{

    public float health = 100f;
    Zombie zombie;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombie = FindObjectOfType<Zombie>();
        zombie.hit_event += Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage()
    {
        if (zombie.target_refueler)
        {
            Debug.Log("Refueler took damage");
            health -= 1f;
        }
        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }

                    
}
