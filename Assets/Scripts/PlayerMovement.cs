using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    
    private float moveSpeed = 30f;
    private float maxSpeed = 5;
    private Vector3 input;
    public AudioClip collectSound;
    public AudioClip deadSound;

    void Start(){}

    void FixedUpdate(){
        if (GameManager.showCompleteLevelWindow) return;
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed){
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.tag == "ENEMY"){
            GetComponent<AudioSource>().clip = deadSound;
            GetComponent<AudioSource>().Play();
            GameManager.RestartLevel();
        }
        if(other.transform.tag == "POINT"){
            Destroy(other);
            other.GetComponent<MeshRenderer>().enabled = false;
            GameManager.AddPoint();
            GetComponent<AudioSource>().clip = collectSound;
            GetComponent<AudioSource>().Play();
        }
        if (other.transform.tag == "DOOR"){
            if (GameManager.IsNextLevelUnlocked()){
                GameManager.showCompleteLevelWindow = true;
            }
        }
    }
}
