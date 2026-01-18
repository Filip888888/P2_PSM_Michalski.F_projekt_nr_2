using UnityEngine;

public class Victim : MonoBehaviour
{
    public int health = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int amount)
    {
        health -= amount;
    }

}