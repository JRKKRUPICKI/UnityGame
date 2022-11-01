using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCylinder : MonoBehaviour{

    public int spinningSpeed;

    void Start(){}

    void Update(){
        transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime * spinningSpeed);
    }
}
