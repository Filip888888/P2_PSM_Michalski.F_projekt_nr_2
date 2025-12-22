using UnityEngine;

public class Snipe_Ammo_Chest : MonoBehaviour
{
    Snipe_SHoot snipe;
    private bool Opened = false;
    private float min_angle = -130f;
    private float alpha = -90f;
    private float speed = 4f;
    public GameObject case_door;
    public GameObject snipe_gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        snipe = FindObjectOfType<Snipe_SHoot>();
        snipe_gun = GameObject.Find("L96_Sniper_Rifle");
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
        if (collision.gameObject.CompareTag("Player") && !Opened && snipe.current_ammo != snipe.max_ammo && snipe_gun.activeSelf && snipe != null)
        {
            snipe.current_ammo = snipe.max_ammo;
            snipe.ammo.text = snipe.max_ammo.ToString() + "/" + snipe.max_ammo.ToString();
            Opened = true;
        }
    }

}
