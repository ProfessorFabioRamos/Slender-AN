using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int objects = 0;
    public Transform waterTransform;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(transform.position.y < waterTransform.position.y)
            RenderSettings.fog = true;
        else    
           RenderSettings.fog = false; 
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Collectible"){
            //objects = objects+1;
            //objects += 1;
            objects++;
            Destroy(other.gameObject);
        }   
    }
}
