using UnityEngine;
using UnityEngine.UI;
using System;

public class Refueler : MonoBehaviour
{

    public float health = 100f;
    //Zombie zombie;
    public Text player_health;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //zombie = FindObjectOfType<Zombie>();
        //zombie.hit_event += Damage;
        player_health.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        player_health.text = health.ToString();
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    
    public void Damage(float amount)
        {
         //Debug.Log("Refueler took damage");
            health -= amount;
            player_health.text = health.ToString();
            if(health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    
                    
}
