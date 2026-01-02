using UnityEngine;

public class Ak_bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Zombie zombie = collision.gameObject.GetComponent<Zombie>();

        if (zombie != null)
        {
            zombie.health -= 25f;
            Debug.Log("Hit.");
        }
    }

}
