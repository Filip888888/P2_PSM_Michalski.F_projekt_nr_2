using UnityEngine;
using UnityEngine.UIElements;

public class Pistol_Shoot : MonoBehaviour
{

    public Transform pointer;
    public Transform shoot_point;
    public Transform bullet;
    public float bullet_speed = 1000f;
    private float shoot_delay = 2f;
    private Vector3 pointer_Offset = new Vector3(0f, 0f, 2f);
    private float maxBullet_Life = 1f;
    private float shoot_timer = 0f;
    public Transform player;
    public Transform Camera;
    private Vector3 Gun_Offset = new Vector3(0f, 0f, 2f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointer.SetParent(shoot_point.transform);
        transform.SetParent(Camera.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.identity;
        transform.position = player.position + Gun_Offset;
        shoot_timer += Time.deltaTime;
        pointer.localPosition = shoot_point.position + pointer_Offset;

        if(shoot_timer >= shoot_delay && Input.GetMouseButton(0))
        {
            Shoot();
            shoot_timer = 0f;
        }
      
    }
    
    void Shoot()
    {
        Vector3 Direction = (pointer.position - shoot_point.position).normalized;

        Transform newBullet = Instantiate(bullet, shoot_point.position + Direction * 0.5f, Quaternion.LookRotation(Direction));

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.velocity = Direction * bullet_speed;

        Destroy(newBullet.gameObject, maxBullet_Life);
    }

}
