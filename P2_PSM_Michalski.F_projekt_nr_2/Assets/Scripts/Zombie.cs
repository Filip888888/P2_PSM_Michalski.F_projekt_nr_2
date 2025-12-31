using UnityEngine;
using System;

public class Zombie : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    public Transform refueler;
    public float health = 100f;
    public event Action hit_event;
    public bool target_refueler = false;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = new Vector3(-331.2f, 1.3f, -41.0f);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", speed);
        Vector3 zomibie_position = transform.position;

        float move = speed * Time.deltaTime;

        void Update()
        {
            if (target_refueler && refueler == null)
            {
                StopAttack();
                return;
            }
        }


        if (Vector3.Distance(zomibie_position, player.position) < 5f)
        {
            transform.position = Vector3.MoveTowards(zomibie_position, player.position, move);
            transform.LookAt(player.position);
            target_refueler = false;
        }else if(Vector3.Distance(zomibie_position, player.position) > 5f)
        {
            if (refueler != null)
            {
                transform.position = Vector3.MoveTowards(zomibie_position, refueler.position, move);
                transform.LookAt(refueler.position);
                target_refueler = true;
            }
        }

        if(Vector3.Distance(zomibie_position, player.position) < 2f)
        {
            anim.SetBool("isAttacking", true);
            speed = 0f;
            anim.SetFloat("Speed", speed);
        }else if(Vector3.Distance(zomibie_position, refueler.position) < 1f)
        {
            if (refueler != null)
            {
                anim.SetBool("isAttacking", true);
                speed = 0f;
                anim.SetFloat("Speed", speed);
            }
        }
        else
        {
            anim.SetBool("isAttacking", false);
            speed = 3f;
            anim.SetFloat("Speed", speed);
        }

    }

    public void Hit()
    {
        Debug.Log("refueler hit event");

        if (!target_refueler) return;
        if (refueler == null) return;
        
        hit_event?.Invoke();
    }

    void StopAttack()
    {
        target_refueler = false;
        anim.SetBool("isAttacking", false);
        speed = 3f;
    }


}
