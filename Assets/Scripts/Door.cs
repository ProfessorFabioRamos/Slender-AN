using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    private bool isOpen= false;
    public GameObject feedbackPanel;

    // Start is called before the first frame update
    void Start()
    {
        feedbackPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player" && !isOpen){
            int objs = other.gameObject.GetComponent<Player>().objects;
            feedbackPanel.SetActive(true);
            feedbackPanel.GetComponentInChildren<Text>().text = "Você possui "+objs+"/8 caveiras";
            if(objs ==  8){
                feedbackPanel.SetActive(false);
                transform.parent.GetComponent<Animation>().Play();
                isOpen = true;
            }
        }
    }

     void OnTriggerExit(Collider other){
        if(other.gameObject.name == "Player" && !isOpen){  
            feedbackPanel.SetActive(false);
        }
    }
}
