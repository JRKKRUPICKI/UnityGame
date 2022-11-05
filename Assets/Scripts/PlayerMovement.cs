using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
    private float moveSpeed = 30f;
    private float maxSpeed = 5;
    public AudioClip collectSound;
    public AudioClip deadSound;

    private SoundManager soundManager;

    public static int moveDirection;

    void Start(){
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.LeftBracket)){
            if (--moveDirection < 0) moveDirection = 3;
        }
        if (Input.GetKeyDown(KeyCode.RightBracket)){
            if (++moveDirection > 3) moveDirection = 0;
        }
        print(moveDirection);
    }

    void FixedUpdate(){
        if (GameManager.showCompleteLevelWindow || GameManager.showLoseLevelWindow) return;
        Vector3 input = new Vector3();
        if(moveDirection == 0) input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (moveDirection == 1) input = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
        if (moveDirection == 2) input = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, -Input.GetAxisRaw("Vertical"));
        if (moveDirection == 3) input = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed){
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.tag == "ENEMY"){
            soundManager.PlaySound(SoundManager.Sound.death, transform.position);
            GameManager.showLoseLevelWindow = true;
        }
        if(other.transform.tag == "POINT"){
            Destroy(other);
            other.GetComponent<MeshRenderer>().enabled = false;
            GameManager.AddPoint();
            soundManager.PlaySound(SoundManager.Sound.point, other.transform.position);
        }
        if (other.transform.tag == "DOOR"){
            if (GameManager.IsNextLevelUnlocked()){
                GameManager.showCompleteLevelWindow = true;
                GameManager.SetNextLevel();
            }
        }
    }
}
