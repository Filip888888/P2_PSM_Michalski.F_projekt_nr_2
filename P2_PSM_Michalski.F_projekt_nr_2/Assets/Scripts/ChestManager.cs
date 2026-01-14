using UnityEngine;

public class ChestManager : MonoBehaviour
{

    public int gun_number;
    Ak_Shoot ak;
    M4_Shoot m4;
    Pistol_Shoot pistol;
    Snipe_SHoot snipe;
    Shotgun_Shoot shotgun;
    private bool Opened = false;
    private float min_angle = -130f;
    private float alpha = -90f;
    private float speed = 4f;
    public GameObject case_door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pistol = FindObjectOfType<Pistol_Shoot>();
        ak = FindObjectOfType<Ak_Shoot>();
        snipe = FindObjectOfType<Snipe_SHoot>();
        shotgun = FindObjectOfType<Shotgun_Shoot>();
        m4 = FindObjectOfType<M4_Shoot>();
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
        if(collision.gameObject.CompareTag("Player") && !Opened)
        {
            switch (gun_number)
            {
                case 1:
                    ak.current_ammo = ak.max_ammo;
                    ak.ammo.text = ak.max_ammo.ToString() + "/" + ak.max_ammo.ToString();
                    Opened = true; 
                    break;
                case 2:
                    pistol.current_ammo = pistol.max_ammo;
                    pistol.ammo.text = pistol.max_ammo.ToString() + "/" + pistol.max_ammo.ToString();
                    Opened = true;
                    break;
                case 3:
                    shotgun.current_ammo = shotgun.max_ammo;
                    shotgun.ammo.text = shotgun.max_ammo.ToString() + "/" + shotgun.max_ammo.ToString();
                    Opened = true;
                    break;
                case 4:
                    snipe.current_ammo = snipe.max_ammo;
                    snipe.ammo.text = snipe.max_ammo.ToString() + "/" + snipe.max_ammo.ToString();
                    Opened = true;
                    break;
                case 5:
                    m4.current_ammo = m4.max_ammo;
                    m4.ammo.text = m4.max_ammo.ToString() + "/" + m4.max_ammo.ToString();
                    Opened = true;
                    break;
            }
        }
    }

}
