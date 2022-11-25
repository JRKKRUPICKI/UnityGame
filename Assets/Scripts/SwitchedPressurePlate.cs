using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchedPressurePlate : MonoBehaviour{

    public bool isActive;

    void Start(){
        UpdateColor();
    }

    void OnTriggerEnter(Collider other){
        isActive = !isActive;
        UpdateColor();
    }

    void UpdateColor(){
        if (isActive) gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(11f / 256f, 207f / 256f, 0f / 256f));
        else gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(21f / 256f, 84f / 256f, 0f / 256f));
    }
}
