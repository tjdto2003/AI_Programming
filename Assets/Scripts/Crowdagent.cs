using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Crowdagent : MonoBehaviour
{


    public Transform target;
    private NavMeshAgent agent;
    public float agentSpeedMin;
    public float agentSpeedMax;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(agentSpeedMin, agentSpeedMax);
        agent.SetDestination(target.position);
    }
}

