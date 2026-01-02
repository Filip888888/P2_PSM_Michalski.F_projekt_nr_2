using UnityEngine;

public class Max_Ammo_Chest : MonoBehaviour
{

    M4_Shoot m4;
    Ak_Shoot ak;
    Snipe_SHoot snipe;
    Shotgun_Shoot shotgun;
    Pistol_Shoot pistol;
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
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m4.current_ammo = m4.max_ammo;
            ak.current_ammo = ak.max_ammo;
            snipe.current_ammo = snipe.max_ammo;
            shotgun.current_ammo = shotgun.max_ammo;
            pistol.current_ammo = pistol.max_ammo;
        }
    }

}
