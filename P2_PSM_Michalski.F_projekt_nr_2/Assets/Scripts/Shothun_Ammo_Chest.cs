using UnityEngine;

public class Shothun_Ammo_Chest : MonoBehaviour
{
    Shotgun_Shoot shotgun;
    private bool Opened = false;
    private float min_angle = -130f;
    private float alpha = -90f;
    private float speed = 4f;
    public GameObject case_door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shotgun = FindObjectOfType<Shotgun_Shoot>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Opened)
        {
            alpha -= speed * Time.deltaTime;

            if (alpha <= min_angle)
            {
                alpha = min_angle;
            }
        }

        case_door.transform.localRotation = Quaternion.Euler(alpha, 0f, 0f);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !Opened && shotgun.current_ammo != shotgun.max_ammo)
        {
            shotgun.current_ammo = shotgun.max_ammo;
            shotgun.ammo.text = shotgun.max_ammo.ToString() + "/" + shotgun.max_ammo.ToString();
            Opened = true;
        }
    }

}
