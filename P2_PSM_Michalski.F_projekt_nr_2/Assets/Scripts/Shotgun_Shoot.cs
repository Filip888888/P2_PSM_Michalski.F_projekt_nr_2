using UnityEngine;
using UnityEngine.UI;

public class Shotgun_Shoot : MonoBehaviour
{
    public Transform bullet;
    public float bullet_speed = 500f;
    public float shoot_delay = 1f;
    public Transform barrel_location;
    private float shoot_timer;
    private bool bullet_ready = true;
    public Transform cam;
    private Vector3 gun_placement = new Vector3(-1f, -1f, 2f);
    public float maxLifeTime = 1f;
    public Text ammo;
    public int pellets = 8;
    public float spread = 0.1f;
    public int max_ammo = 8;
    public int current_ammo;
    public AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.SetParent(cam.transform);
        sound = GameObject.Find("ShotgunSound").GetComponent<AudioSource>();
        ammo.text = max_ammo.ToString() + "/" + max_ammo.ToString();
        current_ammo = max_ammo;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = gun_placement;
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);

        shoot_timer += Time.deltaTime;

        if (shoot_timer >= shoot_delay && bullet_ready && Input.GetMouseButton(0) && current_ammo > 0)
        {
            Debug.Log("Shoot");
            Shoot();
            sound.Play();
            shoot_timer = 0f;
        }

    }

    void Shoot()
    {

        Ray ray = new Ray(cam.position, cam.forward);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = cam.position + cam.forward * 100f;
        }

        Vector3 direction = (targetPoint - barrel_location.position).normalized;

        for (int i = 0; i < pellets; i++) {

            Vector3 spreadDirection = direction;

            spreadDirection += new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));

            Transform newBullet = Instantiate(bullet, barrel_location.position, Quaternion.LookRotation(spreadDirection));

            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.velocity = spreadDirection * bullet_speed;

            

            Destroy(newBullet.gameObject, maxLifeTime);
        }
        current_ammo -= 1;
        UpadetAmmoText();
    }

    void UpadetAmmoText()
    {
        ammo.text = current_ammo.ToString() + "/" + max_ammo.ToString();
    }

    void Reload()
    {
        current_ammo = max_ammo;
        UpadetAmmoText();
    }

}