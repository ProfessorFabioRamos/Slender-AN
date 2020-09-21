using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen= false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player" && !isOpen){
            int objs = other.gameObject.GetComponent<Player>().objects;
            if(objs ==  8){
                transform.parent.GetComponent<Animation>().Play();
                isOpen = true;
            }
        }
    }
}
