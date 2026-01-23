using UnityEngine;

public class M4_bullet : MonoBehaviour
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
        Second_Zombie secons_zombie = collision.gameObject.GetComponent<Second_Zombie>();
        Rocket_Zombie rocket_zombie = collision.gameObject.GetComponent<Rocket_Zombie>();
        Rocket rocket = collision.gameObject.GetComponent<Rocket>();

        if (zombie != null)
        {
            zombie.health -= 20f;
            //Debug.Log("Hit.");
        }

        if (secons_zombie != null)
        {
            secons_zombie.health -= 10f;
        }

        if( rocket_zombie != null)
        {
            rocket_zombie.health -= 10f;
        }

        if(rocket != null)
        {
            rocket.health -= 100f;
        }

    }

}