using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlenderBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerPosition;
    public SkinnedMeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPosition.position);

        if(rend.isVisible)
            agent.speed = 0;
        else    
            agent.speed = 2;
    }
}
