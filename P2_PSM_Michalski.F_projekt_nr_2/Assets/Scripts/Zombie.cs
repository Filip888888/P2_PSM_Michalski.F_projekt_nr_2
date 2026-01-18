using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using System;

public class Zombie : MonoBehaviour
{
    public float speed = 3f;
    public Transform max_ammo_chest;
    public Transform player;
    public float health = 100f;
    public event Action hit_event;
    private NavMeshAgent agent;
    Animator anim;
    Gameplay game;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
        game = FindObjectOfType<Gameplay>();
        anim = GetComponent<Animator>();
        transform.position = new Vector3(-331.2f, 1.3f, -41.0f);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        anim.SetFloat("Speed", speed);
        Vector3 zomibie_position = transform.position;

        agent.SetDestination(player.position);

        if (Vector3.Distance(zomibie_position, player.position) < 2f)
        {
            anim.SetBool("isAttacking", true);
            speed = 0f;
            anim.SetFloat("Speed", speed);
            agent.isStopped = true;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            speed = 3f;
            anim.SetFloat("Speed", speed);
            agent.isStopped = false;
        }

        if (health <= 0f)
        {
            //game.kill_count += 1;

            int a = Random.Range(0, 8);

            if (a == 2)
            {
                Transform max_ammo_chest_spawn = Instantiate(max_ammo_chest, transform.position, Quaternion.identity);
            }

            game.AddKill();
            Destroy(gameObject);
        }

    }

    public void Hit()
    {
        Refueler refueler = player.GetComponent<Refueler>();

        if (refueler != null)
        {
            refueler.Damage(1f);
        }

        //Debug.Log("Player hit event");
        //hit_event?.Invoke();
    }

}