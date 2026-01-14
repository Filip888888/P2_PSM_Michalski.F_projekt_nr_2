using UnityEngine;
using UnityEngine.AI;

public class Follor_Player_NavMesh : MonoBehaviour
{
    public Transform ObJeCt;
    private NavMeshAgent agent;
    public float health = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(ObJeCt.position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(ObJeCt.position);
    }
}
