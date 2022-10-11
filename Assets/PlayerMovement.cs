using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 4f;
    private float maxSpeed = 5;
    private Vector3 input;

    void Start()
    {
        
    }

    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed){
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }
}
