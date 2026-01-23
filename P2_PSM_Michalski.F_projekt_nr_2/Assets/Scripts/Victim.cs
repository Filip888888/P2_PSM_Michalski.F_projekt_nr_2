using UnityEngine;

public class Victim : MonoBehaviour
{
    public int health = 100;
    GameManager manager;
    
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            manager.victims_alive -= 1;
        }
    }

    public void Damage(int amount)
    {
        health -= amount;
    }

}