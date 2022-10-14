using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    private float moveSpeed = 30f;
    private float maxSpeed = 5;
    private Vector3 input;
    public AudioClip collectSound;
    public AudioClip deadSound;

    void Start(){}

    void FixedUpdate(){
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed){
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }

    void OnTriggerEnter(Collider other){
        // Restartowanie poziomu po dotknieciu wroga
        if(other.transform.tag == "ENEMY"){
            // Nie dziala, zagrac w tle podczas przelaczania sceny
            AudioSource.PlayClipAtPoint(deadSound, other.transform.position);
            Scene scene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(scene.name);
            SceneManager.LoadScene("Main");
            GameController.Restart();
        }
        if(other.transform.tag == "POINT"){
            Destroy(other);
            other.GetComponent<MeshRenderer>().enabled = false;
            GameController.AddPoint();
            AudioSource.PlayClipAtPoint(collectSound, other.transform.position);
        }
    }
}
