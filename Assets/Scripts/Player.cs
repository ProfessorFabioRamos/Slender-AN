using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int objects = 0;
    public Transform waterTransform;

    public GameObject grabShotgunPanel;
    public GameObject shotgun;

    [SerializeField]
    private int lives = 3;

    //private bool canGrab=false;

    // Start is called before the first frame update
    void Start(){
        grabShotgunPanel.SetActive(false);
        shotgun.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if(transform.position.y < waterTransform.position.y)
            RenderSettings.fog = true;
        else    
           RenderSettings.fog = false; 
    }

    public void TakeDamage(){
        lives--;
        if(lives <=0){
            SceneManager.LoadScene(2);
        }
    }
    
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Collectible"){
            //objects = objects+1;
            //objects += 1;
            objects++;
            Destroy(other.gameObject);
        } 
        if(other.gameObject.tag == "Gun"){
            grabShotgunPanel.SetActive(true);
            grabShotgunPanel.GetComponentInChildren<Text>().text = "Pressione 'E' para pegar";
            //canGrab=true;
        } 
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Gun"){
            grabShotgunPanel.SetActive(false);
            //canGrab = false;
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Gun"){
            if(Input.GetKeyDown(KeyCode.E)){
                Destroy(other.gameObject);
                grabShotgunPanel.SetActive(false);
                shotgun.SetActive(true);
            }
        }
    }
}
