﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float range = 8;
    private Camera fpsCam;
    private AudioSource aud;
    public AudioClip shootingSound;

    // Start is called before the first frame update
    void Start()
    {
       fpsCam = transform.GetComponentInParent<Camera>();
       aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            aud.clip = shootingSound;
            aud.Play();
            RaycastHit hit;

            Vector3 origin = fpsCam.ViewportToWorldPoint(new Vector3(0,0,0));

            if(Physics.Raycast(origin, fpsCam.transform.forward, out hit, range)){
                //Debug.Log(hit.transform.name);
                if(hit.transform.tag == "Enemy"){
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
