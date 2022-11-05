using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public Transform target;
    public float smoothSpeed = 10;
    public Vector3 offset = new Vector3(0, 4, -6);
    private Vector3 newOffset;

    void Update(){
        if (PlayerMovement.moveDirection == 0) newOffset = offset;
        if (PlayerMovement.moveDirection == 1) newOffset = new Vector3(offset.z, offset.y, offset.x);
        if (PlayerMovement.moveDirection == 2) newOffset = new Vector3(-offset.x, offset.y, -offset.z);
        if (PlayerMovement.moveDirection == 3) newOffset = new Vector3(-offset.z, offset.y, -offset.x);
    }

    void FixedUpdate(){
        transform.position = Vector3.Lerp(transform.position, target.position + newOffset, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
