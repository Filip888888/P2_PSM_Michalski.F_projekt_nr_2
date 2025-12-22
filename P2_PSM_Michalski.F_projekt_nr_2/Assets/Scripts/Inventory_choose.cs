using UnityEngine;

public class Inventory_choose : MonoBehaviour
{
    public GameObject pistol;
    public GameObject m4;
    public GameObject snipe;
    public GameObject ak;
    public GameObject shotgun;
    public GameObject currentWeapon;
    public string curretWeapon_name;

    void Start()
    {
        currentWeapon = pistol;
    }

    void Update()
    {
        ChooseWeapon();
    }

    void ChooseWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(pistol, "Pistol");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(m4, "M4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(snipe, "Snipe");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetWeapon(ak, "AK");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetWeapon(shotgun, "Shotgun");
        }
    }

    void SetWeapon(GameObject weapon, string weaponName)
    {
        pistol.SetActive(false);
        m4.SetActive(false);
        snipe.SetActive(false);
        ak.SetActive(false);
        shotgun.SetActive(false);

        weapon.SetActive(true);
        currentWeapon = weapon;
        curretWeapon_name = weaponName;
    }

}
