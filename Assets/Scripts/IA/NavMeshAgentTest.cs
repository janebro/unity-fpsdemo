using UnityEngine;
using System.Collections;

public class NavMeshAgentTest : MonoBehaviour {


    public Transform goal;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        agent.speed = 10f;
    }

    void Update()
    {
        agent.destination = goal.position;
    }
}
