﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SlenderBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerPosition;
    public SkinnedMeshRenderer rend;
    public Image noiseEffect;
    public float dangerDistance = 5.0f;
    private float distance = 0;
    public GameObject explosion;
    private bool canDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        noiseEffect.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPosition.position);
        distance = Vector3.Distance(playerPosition.position, transform.position);
        //Debug.Log("Distance: "+distance);

        if(rend.isVisible)
            agent.speed = 0;
        else    
            agent.speed = 2;

        if(distance <= dangerDistance && canDamage){
            noiseEffect.enabled = true;
            playerPosition.GetComponent<Player>().TakeDamage();
            canDamage = false;
        }
        else if(distance > dangerDistance){
            noiseEffect.enabled = false;
            canDamage = true;
        }         
    }

    void OnDestroy(){
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
