using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class Second_Zombie : MonoBehaviour
{
    public Transform victim1;
    public Transform victim2;
    private NavMeshAgent agent;
    private Animator anim;
    public float speed = 5f;
    public float health = 100f;
    private bool victim_one_alive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victim1 = GameObject.Find("MP_Female_A1F Woman").transform;
        victim2 = GameObject.Find("MP_Male_A1F Man").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (victim1 != null)
        {
            agent.SetDestination(victim1.position);
        }
        else
        {
            agent.SetDestination(victim2.position);
        }

        Vector3 zombie_position = transform.position;

        if (victim1 != null && Vector3.Distance(zombie_position, victim1.position) < 2f || victim2 != null && Vector3.Distance(zombie_position, victim2.position) < 2f)
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
            Destroy(gameObject);
        }

        if (victim1 == null) victim_one_alive = false;

    }

    public void Hit()
    {
        if (victim1 != null)
        {
            Victim victim = victim1.GetComponent<Victim>();
            victim.Damage(30);
        }
        else if (!victim_one_alive && victim2 != null)
        {
            Victim victimm = victim2.GetComponent<Victim>();
            victimm.Damage(30);
        }

    }

}